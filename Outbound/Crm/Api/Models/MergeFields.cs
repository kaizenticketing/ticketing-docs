using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class MergeFields
{
	// standard
	
	public const string FORENAME = "FNAME";
	public const string SURNAME = "LNAME";
	public const string ADDRESS = "ADDRESS";
	// public const string PHONE = "PHONE";

	[JsonPropertyName(FORENAME)]
	public string? FirstName { get; set; }

	[JsonPropertyName(SURNAME)]
	public string? LastName { get; set; }

	[JsonPropertyName(ADDRESS)]
	public string? Address { get; set; }

	// [JsonPropertyName(PHONE)]
	// public string Phone { get; set; }

	// custom

	// TODO: also our custom ones in here
	public const string DATE_OF_BIRTH = "DOB";
	public const string ADDRESS_LINE1 = "LINE1";
	public const string ADDRESS_LINE2 = "LINE2";
	public const string ADDRESS_TOWN = "TOWN";
	public const string ADDRESS_COUNTY = "COUNTY";
	public const string ADDRESS_COUNTRY = "COUNTRY";
	public const string PHONE_MOBILE = "PMOBILE";
	public const string PHONE_HOME = "PHOME";
	public const string PHONE_WORK = "PWORK";

	[JsonPropertyName(DATE_OF_BIRTH)]
	public string? DateOfBirth { get; set; }

	[JsonPropertyName(ADDRESS_LINE1)]
	public string? AddressLine1 { get; set; }

	[JsonPropertyName(ADDRESS_LINE2)]
	public string? AddressLine2 { get; set; }

	[JsonPropertyName(ADDRESS_TOWN)]
	public string? AddressTown { get; set; }

	[JsonPropertyName(ADDRESS_COUNTY)]
	public string? AddressCounty { get; set; }

	[JsonPropertyName(ADDRESS_COUNTRY)]
	public string? AddressCountry { get; set; }

	[JsonPropertyName(PHONE_MOBILE)]
	public string? PhoneMobile { get; set; }
	
	[JsonPropertyName(PHONE_HOME)]
	public string? PhoneHome { get; set; }
	
	[JsonPropertyName(PHONE_WORK)]
	public string? PhoneWork { get; set; }
}