
# Outbound Integrations

## CRM

Included in this repository are snapshots (as of 21/3/2025) of the API calls we make, their appropriate models and DTOs that we make in order to populate Mailchimp.

As discussed, we have made a change to let the base URL we use to vary based on the configuration used for a Kaizen Organisation. This will allow us to send these same shape calls
to a different implementation of the Mailchimp API that you put in place.

The actual (server-side) documentation for these calls is documented: https://mailchimp.com/developer/marketing/api/

### Calls Required

See IMailchimpClient.cs and the 'NOTEs' included in there.

Broadly though you will need to implement add/update, get and delete calls for the following Mailchimp objects:

* audiences - 1 per club, used when we set up a new organisation
* stores - 1 per club, used for when we set up a new organisation
* merge fields - so we can add 'extra' fields to mailchimp, you can probably stub this call out and 'ignore' it
* interest group categories - you can stub these calls out and 'ignore' them
* interest groups - you can stub these calls out and 'ignore' them
* members (+tags) - customers, obviously important
* campaigns - you can stub these calls out and 'ignore' them
* products - you will need these to know the information about products people have bought
* carts - you can stub these calls out and 'ignore' them
* orders - you will need these to get the orders & order lines of what people have bought

### Limitations

Because we are mapping our internal Kaizen objects to Mailchimp's less expressive, more generic API - a lot of information is lost as part of this translation. So you are not getting 100% fidelity of the data we hold. Specifically (but not limited to):
  * No information related to attendees of events, just purchasers
  * No meta-data about products, to be able to tell the difference between season tickets/events/merchandise etc
  * Not all customer account fields
  * No fee or discount information as part of orders - it wont be financially 100% accurate with what we track internally

As discussed, this is a limited initial piece of work designed to get the integration off the ground ASAP. 

Moving forward, if more information is required and the work can be mutually scheduled, we will expose full-fidelity Kaizen data to third-parties and so at some point once this Mailchimp API based integration becomes limiting we will require you to move off of it and onto that new integration. There is unlikely to be an ability for us to incrementally improve this Mailchimp API, so be aware of that future work which will need to be done.