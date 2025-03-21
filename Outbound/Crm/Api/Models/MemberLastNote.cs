using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class MemberLastNote
{
	/// <summary>
	/// Gets or sets the id.
	/// </summary>
	[JsonPropertyName("note_id")]
	public int Id { get; set; }

	/// <summary>
	/// Gets or sets the body.
	/// </summary>
	[JsonPropertyName("note")]
	public string Body { get; set; } = "";

	/// <summary>
	/// Gets or sets the created at.
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the created by.
	/// </summary>
	[JsonPropertyName("created_by")]
	public string CreatedBy { get; set; } = "";

}
