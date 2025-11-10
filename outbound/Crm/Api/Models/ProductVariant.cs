using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class ProductVariant
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("title")]
	public string? Title { get; set; }

	[JsonPropertyName("url")]
	public string? Url { get; set; }

	[JsonPropertyName("sku")]
	public string? Sku { get; set; }

	[JsonPropertyName("price")]
	public decimal? Price { get; set; }

	[JsonPropertyName("inventory_quantity")]
	public int? InventoryQuantity { get; set; }

	[JsonPropertyName("image_url")]
	public string? ImageUrl { get; set; }

	[JsonPropertyName("backorders")]
	public string? Backorders { get; set; }

	[JsonPropertyName("visibility")]
	public string? Visibility { get; set; }

	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	[JsonPropertyName("_links")]
	public IList<Link>? Links { get; set; }
}
