namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

[MessagePackObject]
public class Address
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
	/// Gets or sets the country.
	/// </summary>
	[JsonPropertyName("country")]
	[Key(3)]
	public string? Country { get; set; }

	/// <summary>
	/// Gets or sets the country code.
	/// </summary>
	[JsonPropertyName("country_code")]
	[Key(4)]
	public string? CountryCode { get; set; }

	/// <summary>
	/// Gets or sets the postal code.
	/// </summary>
	[JsonPropertyName("postal_code")]
	[Key(5)]
	public string? PostalCode { get; set; }

	/// <summary>
	/// Gets or sets the province.
	/// </summary>
	[JsonPropertyName("province")]
	[Key(6)]
	public string? Province { get; set; }

	/// <summary>
	/// Gets or sets the province code.
	/// </summary>
	[JsonPropertyName("province_code")]
	[Key(7)]
	public string? ProvinceCode { get; set; }
}