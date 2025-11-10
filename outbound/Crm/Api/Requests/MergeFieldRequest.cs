namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class MergeFieldRequest : BaseQueryableRequest
{
	[QueryString("type")]
	public string? Type { get; set; }
	
	[QueryString("required")]
	public string? Required { get; set; }
}
