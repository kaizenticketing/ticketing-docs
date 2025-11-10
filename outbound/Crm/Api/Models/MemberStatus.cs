using System.ComponentModel;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public enum MemberStatus
{
	/// <summary>
	/// The undefined.
	/// </summary>
	[Description("")]
	Undefined,

	/// <summary>
	/// The subscribed.
	/// </summary>
	[Description("subscribed")]
	Subscribed,

	/// <summary>
	/// The unsubscribed.
	/// </summary>
	[Description("unsubscribed")]
	Unsubscribed,

	/// <summary>
	/// The cleaned.
	/// </summary>
	[Description("cleaned")]
	Cleaned,

	/// <summary>
	/// The pending.
	/// </summary>
	[Description("pending")]
	Pending,

	/// <summary>
	/// Trajnsaction Member status
	/// </summary>
	[Description("transactional")]
	Transactional,

	/// <summary>
	/// Archived member status
	/// </summary>
	[Description("archived")]
	Archived

}