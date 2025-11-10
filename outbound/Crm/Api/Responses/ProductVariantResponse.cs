using System.Text.Json.Serialization;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class ProductVariantResponse : BaseResponse
{
	public ProductVariantResponse()
	{
		Variants = new List<ProductVariant>();
	}

	[JsonPropertyName("store_id")]
	public string StoreId { get; set; } = default!;

	[JsonPropertyName("product_id")]
	public string ProductId { get; set; } = default!;

	[JsonPropertyName("variants")]
	public IList<ProductVariant> Variants { get; set; }
}
