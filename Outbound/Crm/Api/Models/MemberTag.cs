using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class MemberTag
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	[JsonPropertyName("id")]
	public int Id { get; set; }

	/// <summary>
	/// Gets or sets the tag's name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}
