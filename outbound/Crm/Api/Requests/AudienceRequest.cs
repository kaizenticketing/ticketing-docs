namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class AudienceRequest : BaseQueryableRequest
{
	[QueryString("before_date_created")]
	public DateTime? BeforeDateCreated { get; set; }

	[QueryString("since_date_created")]
	public DateTime? SinceDateCreated { get; set; }

	[QueryString("before_campaign_last_sent")]
	public string? BeforeCampaignLastSent { get; set; }

	[QueryString("since_campaign_last_sent")]
	public string? SinceCampaignLastSent { get; set; }

	[QueryString("email")]
	public string? Email { get; set; }
}