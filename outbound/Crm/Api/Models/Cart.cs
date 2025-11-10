using System.Text.Json.Serialization;
using Kaizen.Serialization.JsonConverters.SystemText;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class Cart
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = default!; 

	[JsonPropertyName("customer")]
	public Customer? Customer { get; set; }

	[JsonPropertyName("campaign_id")]
	public string? CampaignId { get; set; }

	[JsonPropertyName("checkout_url")]
	public string? CheckoutUrl { get; set; }

	[JsonPropertyName("currency_code")]
	[JsonConverter(typeof(EnumDescriptionJsonConverter<CurrencyCode>))]
	public CurrencyCode? CurrencyCode { get; set; }

	[JsonPropertyName("order_total")]
	public decimal? OrderTotal { get; set; }

	[JsonPropertyName("tax_total")]
	public decimal? TaxTotal { get; set; }

	[JsonPropertyName("lines")]
	public ICollection<OrderLine> Lines { get; set; } = new HashSet<OrderLine>();

	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	[JsonPropertyName("_links")]
	public ICollection<Link> Links { get; set; } = new HashSet<Link>();
}
