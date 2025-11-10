using System.Text.Json.Serialization;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class AudienceResponse : BaseResponse
{
	/// <summary>
	/// Gets or sets the lists.
	/// </summary>
	[JsonPropertyName("lists")]
	public IEnumerable<Audience> Lists { get; set; } = new HashSet<Audience>();
}