using System.ComponentModel;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

[Flags]
public enum CampaignSortField
{
	/// <summary>
	/// The send time.
	/// </summary>
	[Description("send_time")]
	SendTime = 1,

	/// <summary>
	/// The send time.
	/// </summary>
	[Description("create_time")]
	CreateTime = 2
}