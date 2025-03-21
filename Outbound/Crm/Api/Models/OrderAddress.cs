using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class OrderAddress : Address
{
	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the latitude.
	/// </summary>
	[JsonPropertyName("latitude")]
	public decimal? Latitude { get; set; }

	/// <summary>
	/// Gets or sets the longitude.
	/// </summary>
	[JsonPropertyName("longitude")]
	public decimal? Longitude { get; set; }

	/// <summary>
	/// Gets or sets the phone number.
	/// </summary>
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	/// <summary>
	/// Gets or sets the company name.
	/// </summary>
	[JsonPropertyName("company")]
	public string? Company { get; set; }

}