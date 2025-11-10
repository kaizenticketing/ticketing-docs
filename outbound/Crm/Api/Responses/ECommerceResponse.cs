using System.Text.Json.Serialization;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class ECommerceResponse : BaseResponse
{
	[JsonPropertyName("stores")]
	public IEnumerable<Store> Stores { get; set; } = default!;
}
