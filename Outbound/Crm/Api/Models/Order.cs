using Kaizen.Serialization.JsonConverters.SystemText;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class Order
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = default!; 

	[JsonPropertyName("customer")]
	public Customer? Customer { get; set; }

	[JsonPropertyName("store_id")]
	public string? StoreId { get; set; }

	[JsonPropertyName("campaign_id")]
	public string? CampaignId { get; set; }

	[JsonPropertyName("landing_site")]
	public string? LandingSite { get; set; }

	[JsonPropertyName("financial_status")]
	public string? FinancialStatus { get; set; }

	[JsonPropertyName("fulfillment_status")]
	public string? FulfillmentStatus { get; set; }

	[JsonPropertyName("currency_code")]
	[JsonConverter(typeof(EnumDescriptionJsonConverter<CurrencyCode>))]
	public CurrencyCode CurrencyCode { get; set; }

	[JsonPropertyName("order_total")]
	public decimal OrderTotal { get; set; }

	[JsonPropertyName("order_url")]
	public string? OrderUrl { get; set; }

	[JsonPropertyName("discount_total")]
	public decimal? DiscountTotal { get; set; }

	[JsonPropertyName("tax_total")]
	public decimal? TaxTotal { get; set; }

	[JsonPropertyName("shipping_total")]
	public decimal? ShippingTotal { get; set; }

	[JsonPropertyName("tracking_code")]
	public string? TrackingCode { get; set; }

	[JsonPropertyName("processed_at_foreign")]
	public string? ProcessedAtForeign { get; set; }

	[JsonPropertyName("cancelled_at_foreign")]
	public string? CancelledAtForeign { get; set; }

	[JsonPropertyName("shipping_address")]
	public OrderAddress? ShippingAddress { get; set; }

	[JsonPropertyName("billing_address")]
	public OrderAddress? BillingAddress { get; set; }

	[JsonPropertyName("updated_at_foreign")]
	public string? UpdatedAtForeign { get; set; }

	[JsonPropertyName("promos")]
	public IList<Promo> Promos { get; set; } = new List<Promo>();

	[JsonPropertyName("lines")]
	public IList<OrderLine> Lines { get; set; } = new List<OrderLine>();

	[JsonPropertyName("outreach")]
	public Outreach? Outreach { get; set; }

	[JsonPropertyName("_links")]
	public IList<Link> Links { get; set; } = new List<Link>();
}
