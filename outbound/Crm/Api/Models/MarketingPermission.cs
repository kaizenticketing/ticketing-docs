using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class MarketingPermission
{
	/// <summary>
	/// Gets or sets the the id for the marketing permission on the list.
	/// </summary>
	[JsonPropertyName("marketing_permission_id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the text permission.
	/// </summary>
	[JsonPropertyName("text")]
	public string? Text { get; set; }

	/// <summary>
	/// Gets or sets if the subscriber has opted-in to the marketing permission.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool Enabled { get; set; }
}
