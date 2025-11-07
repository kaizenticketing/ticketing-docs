---
layout: default
title: Kaizen Datafeeds
---

# Kaizen Datafeeds

## What is it?

We expose a near-real-time outbound data feed over webhooks.

When things change in Kaizen (e.g. a customer is updated), we send a signed HTTP POST to your webhook URL containing a standard envelope (metadata about the event) and the payload (the object itself).

Initially, we're focusing on the customer object type, with more objects added over time.

## What we need from you

To consume the feed, we'll need:

### 1. Provide a webhook URL
* Publicly reachable over HTTPS
* This is the endpoint we will POST events to.

### 2. Provide a shared secret
* A random string you generate and share with us.
* We configure it against your integration on our side.
* We use it to sign the request body and send an `X-Kaizen-Signature` header.
* **This is critical for security**: You must verify this signature to ensure the webhook request genuinely comes from Kaizen and hasn't been tampered with or sent by a malicious third party.

### 3. A small HTTP endpoint that:
* Accepts POST requests.
* Requires `Content-Type: application/json`.
* **Verifies `X-Kaizen-Signature` using HMAC SHA-256** over the raw body + shared secret (see [Security](#security-and-shared-secret) section below).
* **Returns a quick 2xx response** (ideally within 3 seconds):
  * This should be a fast acknowledgment that you've received the webhook.
  * If you need to perform heavy processing (database writes, API calls, business logic), **queue the work asynchronously** on your side and return 2xx immediately.
  * Slow responses may trigger timeouts and unnecessary retries.

All routing (which organisations + object types you receive) is configured by us.

## Webhook envelope format

Every POST you receive will be a JSON envelope with a consistent shape, wrapping the actual payload:

```json
{
  "envelopeVersion": 1,
  "publishedAt": "2025-02-01T12:34:56.789Z",
  "eventType": "Updated",
  "organisationId": "00000000-0000-0000-0001-000000000004",
  "objectType": "customer",
  "objectVersion": 1,
  "objectId": "12345",
  "idempotencyKey": "…hash…",
  "correlationId": "…guid…",
  "sourceSystem": "Kaizen",
  "payload": {
  }
}
```

### Field descriptions

* `envelopeVersion` - Version of the envelope schema (currently `1`). This may increment if we make breaking changes to the envelope structure.
* `publishedAt` - Timestamp of when the event was published by Kaizen.
* `eventType` - The type of change that occurred:
  * `Created` - A new object was created
  * `Updated` - An existing object was modified
  * `Deleted` - Deleted events correspond to a hard deletion inside Kaizen. After a Deleted event for a given objectId, that object no longer exists in Kaizen. The payload for a Deleted event contains the last known state of the object at the time it was deleted. 
* `organisationId` - The unique identifier of the Kaizen organisation this event belongs to.
* `objectType` - The type of object (e.g. `customer`). This determines the schema of the `payload`.
* `objectVersion` - Version number of the object schema in the payload. Increments when we make changes to the object structure. Use this to handle different payload versions.
* `objectId` - The unique identifier of the specific object within Kaizen (e.g. the customer ID).
* `idempotencyKey` - A unique hash for this specific event. Use this to deduplicate if you receive the same event multiple times (see Idempotency).
* `correlationId` - A unique identifier for tracing this event through your systems.
* `sourceSystem` - Always `Kaizen`
* `payload` - The actual object data

## Headers & authentication

Each webhook POST will include the following headers:

* `X-Kaizen-Event` – mirrors `eventType` (e.g. `Updated`).
* `X-Kaizen-Source` – Always `Kaizen`.
* `X-Idempotency-Key` – mirrors `idempotencyKey` in the envelope.
* `X-Kaizen-Signature` – HMAC-SHA256 (hex) of the raw request body, computed with the shared secret. **You must verify this to ensure authenticity.**

## Retry / resilience behaviour

### Delivery guarantees

Kaizen provides **at-least-once delivery**. This means:
* Every event will be delivered to your webhook at least once.
* In rare cases (network issues, timeouts, retries), you may receive the same event multiple times.

### How retries work

When we send a webhook to your endpoint:

* **2xx response** → Success. We consider the event delivered and will not retry.
* **5xx response or network error** → Temporary failure. We will retry the delivery with exponential backoff.
* **4xx response** → Client error. We log this and generally do not retry (as it indicates a problem with the webhook endpoint or configuration).

### Retry schedule

Our retry behavior includes:
* Exponential backoff between retry attempts
* Multiple retry attempts over time
* After exhausting retries, failed events may be sent to a dead letter queue for investigation

## Retention Period

Webhook events and retry attempts are retained for **at least 7 days**. After this period:
* Failed deliveries that have exhausted retries will be moved to a dead letter queue.
* We do not guarantee redelivery of events older than 7 days.
* If your webhook endpoint is down for an extended period, coordinate with us to discuss backfilling options.

### Idempotency on your side

Because of our **at-least-once delivery** guarantee, you may receive the same event multiple times. Additionally, **events may arrive out of order** due to retries and network conditions.

**How to handle this safely:**

1. **Use `idempotencyKey` to detect duplicates:**
   - Extract the `idempotencyKey` from the incoming webhook
   - Check if you've already processed this key (e.g., look it up in your database)
   - If yes → Return 200 immediately without reprocessing
   - If no → Process the event, store the `idempotencyKey`, then return 200

**Retention of idempotency keys: (optional)**

You only need to retain `idempotencyKey` values for as long as retries are possible (at least 7 days - see [Retention Period](#retention-period)). After that, the risk of receiving duplicates is negligible.

## Security and Shared Secret

**Critical: You must verify the webhook signature to ensure requests genuinely come from Kaizen.** Without signature verification, anyone could send fake webhooks to your endpoint and inject malicious data into your system.

To make sure webhooks really come from Kaizen, we sign every request with a shared secret + HMAC signature.

### How it works

1. We agree on a shared secret string with you (generated by you, shared securely).
2. On every webhook, we compute HMAC-SHA256 of the raw request body using the shared secret and hex-encode it.
3. We send that value in the `X-Kaizen-Signature` header.

### What you need to do

**You are responsible for verifying the signature.** This is your security mechanism to prevent unauthorized or tampered webhooks.

1. Read the raw request body (before parsing JSON).
2. Read the `X-Kaizen-Signature` header.
3. Recompute HMAC-SHA256(rawBody, sharedSecret) using the same secret.
4. Compare your computed hash to the header value (use a constant-time comparison to prevent timing attacks).
5. If they match → Trust the request and process it.
6. If they don't match, treat as suspicious (log and return 4xx) 

## Object Schemas

Currently supported object types:

### Customer Object

For `objectType: "customer"` 

* [Customer Schema Sample](https://github.com/kaizenticketing/ticketing/blob/3bb03c335fff9c234d995b715b17614228748cf7/docs/DEVELOPMENT/Designs/DataFeeds/Customer.Sample.json)

### Order Object

For `objectType: "order"` 

* [Order Schema Sample](https://github.com/kaizenticketing/ticketing/blob/3bb03c335fff9c234d995b715b17614228748cf7/docs/DEVELOPMENT/Designs/DataFeeds/Order.Sample.json)

### Product Object 

For `objectType: "product"`

* [Product Schema Sample](https://github.com/kaizenticketing/ticketing/blob/3bb03c335fff9c234d995b715b17614228748cf7/docs/DEVELOPMENT/Designs/DataFeeds/Product.Sample.json)

