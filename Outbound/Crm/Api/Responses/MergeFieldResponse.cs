using System.Text.Json.Serialization;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class MergeFieldResponse : BaseResponse
{
	/// <summary>
	/// Gets or sets the list id.
	/// </summary>
	[JsonPropertyName("list_id")]
	public string ListId { get; set; } = default!;

	/// <summary>
	/// Gets or sets the merge fields.
	/// </summary>
	[JsonPropertyName("merge_fields")]
	public IEnumerable<MergeField> MergeFields { get; set; } = new HashSet<MergeField>();
}