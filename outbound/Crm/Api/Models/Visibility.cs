using System.ComponentModel;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public enum Visibility
{
	[Description("pub")]
	Public,
	[Description("prv")]
	Private
}