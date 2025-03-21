using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class MailChimpApiError
{
	[JsonPropertyName("type")]
	public string Type { get; set; } = default!;

	[JsonPropertyName("title")]
	public string Title { get; set; } = default!;

	[JsonPropertyName("status")]
	public int Status { get; set; }

	[JsonPropertyName("detail")]
	public string Detail { get; set; } = default!;

	[JsonPropertyName("instance")]
	public string Instance { get; set; } = default!;
	
	[JsonPropertyName("errors")]
	public List<MailChimpError> Errors { get; set; } = new List<MailChimpError>();
}
