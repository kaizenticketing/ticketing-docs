using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class Outreach
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }
}