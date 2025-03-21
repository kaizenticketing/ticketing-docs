using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

[MessagePackObject]
public class Contact
{
	/// <summary>
	/// Gets or sets the address 1.
	/// </summary>
	[JsonPropertyName("address1")]
	[Key(0)]
	public string? Address1 { get; set; }

	/// <summary>
	/// Gets or sets the address 2.
	/// </summary>
	[JsonPropertyName("address2")]
	[Key(1)]
	public string? Address2 { get; set; }

	/// <summary>
	/// Gets or sets the city.
	/// </summary>
	[JsonPropertyName("city")]
	[Key(2)]
	public string? City { get; set; }

	/// <summary>
	/// Gets or sets the company.
	/// </summary>
	[JsonPropertyName("company")]
	[Key(3)]
	public string? Company { get; set; }

	/// <summary>
	/// Gets or sets the country.
	/// </summary>
	[JsonPropertyName("country")]
	[Key(4)]
	public string? Country { get; set; }

	/// <summary>
	/// Gets or sets the phone.
	/// </summary>
	[JsonPropertyName("phone")]
	[Key(5)]
	public string? Phone { get; set; }

	/// <summary>
	/// Gets or sets the state.
	/// </summary>
	[JsonPropertyName("state")]
	[Key(6)]
	public string? State { get; set; }

	/// <summary>
	/// Gets or sets the zip.
	/// </summary>
	[JsonPropertyName("zip")]
	[Key(7)]
	public string? Zip { get; set; }
}