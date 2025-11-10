
using System;

using System.ComponentModel;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

[Flags]
public enum CampaignSortOrder
{
	/// <summary>
	/// ASC
	/// </summary>
	[Description("ASC")]
	ASC = 1,

	/// <summary>
	/// ASC
	/// </summary>
	[Description("DESC")]
	DESC = 2
}

