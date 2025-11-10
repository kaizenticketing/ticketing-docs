using System.ComponentModel;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

/// <summary>
/// The campaign status.
/// </summary>
[Flags]
public enum CampaignStatus
{
	/// <summary>
	/// The save.
	/// </summary>
	[Description("save")]
	Save = 1,

	/// <summary>
	/// The paused.
	/// </summary>
	[Description("paused")]
	Paused = 2,

	/// <summary>
	/// The schedule.
	/// </summary>
	[Description("schedule")]
	Schedule = 4,

	/// <summary>
	/// The sending.
	/// </summary>
	[Description("sending")]
	Sending = 8,

	/// <summary>
	/// The sent.
	/// </summary>
	[Description("sent")]
	Sent = 16
}