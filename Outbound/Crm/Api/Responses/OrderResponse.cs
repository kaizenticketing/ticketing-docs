using System.Text.Json.Serialization;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class OrderResponse : BaseResponse
{
	[JsonPropertyName("store_id")]
	public string StoreId { get; set; } = default!;

	[JsonPropertyName("orders")]
	public IList<Order> Orders { get; set; } = new List<Order>();
}
