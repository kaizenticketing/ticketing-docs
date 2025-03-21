using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

[MessagePackObject]
public class CampaignDefaults
{
	/// <summary>
	/// Gets or sets the from email.
	/// </summary>
	[JsonPropertyName("from_email")]
	[Key(0)]
	public string? FromEmail { get; set; }

	/// <summary>
	/// Gets or sets the from name.
	/// </summary>
	[JsonPropertyName("from_name")]
	[Key(1)]
	public string? FromName { get; set; }

	/// <summary>
	/// Gets or sets the language.
	/// </summary>
	[JsonPropertyName("language")]
	[Key(2)]
	public string? Language { get; set; }

	/// <summary>
	/// Gets or sets the subject.
	/// </summary>
	[JsonPropertyName("subject")]
	[Key(3)]
	public string? Subject { get; set; }
}