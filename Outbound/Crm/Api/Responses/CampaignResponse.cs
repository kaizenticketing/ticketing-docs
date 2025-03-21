using System.Text.Json.Serialization;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class CampaignResponse : BaseResponse
{
	/// <summary>
	/// Gets or sets the campaigns.
	/// </summary>
	[JsonPropertyName("campaigns")]
	public IEnumerable<Campaign> Campaigns { get; set; } = default!;
}