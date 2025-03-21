using System.Text.Json.Serialization;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class ProductResponse : BaseResponse
{
	[JsonPropertyName("store_id")]
	public string StoreId { get; set; } = default!;

	[JsonPropertyName("products")]
	public IList<Product> Products { get; set; } = new List<Product>();
}
