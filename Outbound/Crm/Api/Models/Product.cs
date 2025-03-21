using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class Product
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("title")]
	public string? Title { get; set; }

	[JsonPropertyName("handle")]
	public string? Handle { get; set; }

	[JsonPropertyName("url")]
	public string? Url { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("type")]
	public string? Type { get; set; }

	[JsonPropertyName("vendor")]
	public string? Vendor { get; set; }

	[JsonPropertyName("image_url")]
	public string? ImageUrl { get; set; }

	[JsonPropertyName("variants")]
	public IList<ProductVariant> Variants { get; set; } = default!; 

	[JsonPropertyName("published_at_foreign")]
	public string? PublishedAtForeign { get; set; }

	[JsonPropertyName("images")]
	public IList<Image>? Images { get; set; }

	[JsonPropertyName("_links")]
	public IList<Link>? Links { get; set; }
}
