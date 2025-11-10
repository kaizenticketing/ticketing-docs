using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class OrderLine
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("product_id")]
	public string? ProductId { get; set; }

	[JsonPropertyName("product_title")]
	public string? ProductTitle { get; set; }

	[JsonPropertyName("product_variant_id")]
	public string? ProductVariantId { get; set; }

	[JsonPropertyName("product_variant_title")]
	public string? ProductVariantTitle { get; set; }

	[JsonPropertyName("quantity")]
	public int Quantity { get; set; }

	[JsonPropertyName("price")]
	public decimal Price { get; set; }

	[JsonPropertyName("discount")]
	public decimal? Discount { get; set; }

	[JsonPropertyName("_links")]
	public IList<Link> Links { get; set; } = new List<Link>();
}
