using System.Text.Json.Serialization;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class MemberResponse : BaseResponse
{
	/// <summary>
	/// Gets or sets the list id.
	/// </summary>
	[JsonPropertyName("list_id")]
	public string ListId { get; set; } = default!;

	/// <summary>
	/// Gets or sets the members.
	/// </summary>
	[JsonPropertyName("members")]
	public IEnumerable<Member> Members { get; set; } = new HashSet<Member>();
}