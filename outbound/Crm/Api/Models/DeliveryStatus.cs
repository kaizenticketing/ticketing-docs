using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

/// <summary>
/// The delivery status.
/// </summary>
public class DeliveryStatus
{
	/// <summary>
	/// Gets or sets a value indicating whether enabled.
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }

	[JsonPropertyName("can_cancel")]
	public bool? CanCancel { get; set; }

	[JsonPropertyName("status")]
	public string? Status { get; set; }

	[JsonPropertyName("emails_sent")]
	public int? EmailsSent { get; set; }

	[JsonPropertyName("emails_canceled")]
	public int? EmailsCanceled { get; set; }
}