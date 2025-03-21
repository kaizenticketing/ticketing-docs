
namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class MailChimpError
{
	[JsonPropertyName("field")]
	public string Field { get; set; } = default!;
	
	[JsonPropertyName("message")]
	public string Message { get; set; } = default!;
}
