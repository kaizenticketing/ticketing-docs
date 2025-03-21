using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

[MessagePackObject]
public class StoreAddress : Address
{
	/// <summary>
	/// Gets or sets the latitude.
	/// </summary>
	[JsonPropertyName("latitude")]
	[Key(8)]
	public decimal? Latitude { get; set; }

	/// <summary>
	/// Gets or sets the longitude.
	/// </summary>
	[JsonPropertyName("longitude")]
	[Key(9)]
	public decimal? Longitude { get; set; }
}