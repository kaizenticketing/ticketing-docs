using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class MemberStats
{
	[JsonPropertyName("avg_open_rate")]
	public double AverageOpenRate { get; set; }
	[JsonPropertyName("avg_click_rate")]
	public double AverageClickRate { get; set; }
}
