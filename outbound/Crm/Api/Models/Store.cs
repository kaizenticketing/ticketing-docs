using System.Text.Json.Serialization;
using Kaizen.Serialization.JsonConverters.SystemText;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

[MessagePackObject]
public class Store
{
	/// <summary>
	/// Gets or sets the address.
	/// </summary>
	[JsonPropertyName("address")]
	[Key(0)]
	public StoreAddress? Address { get; set; }

	/// <summary>
	/// Gets or sets the created at.
	/// </summary>
	[JsonPropertyName("created_at")]
	[Key(1)]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// Gets or sets the currency code.
	/// </summary>
	[JsonPropertyName("currency_code")]
	[JsonConverter(typeof(EnumDescriptionJsonConverter<CurrencyCode>))]
	[Key(2)]
	public CurrencyCode CurrencyCode { get; set; }

	/// <summary>
	/// Gets or sets the platform.
	/// </summary>
	[JsonPropertyName("platform")]
	[Key(3)]
	public string? Platform { get; set; }

	/// <summary>
	/// Gets or sets the syncing flag.
	/// </summary>
	[JsonPropertyName("is_syncing")]
	[Key(4)]
	public bool IsSyncing { get; set; }

	/// <summary>
	/// Gets or sets the domain.
	/// </summary>
	[JsonPropertyName("domain")]
	[Key(5)]
	public string? Domain { get; set; }

	/// <summary>
	/// Gets or sets the email address.
	/// </summary>
	[JsonPropertyName("email_address")]
	[Key(6)]
	public string? EmailAddress { get; set; }

	/// <summary>
	/// The unique identifier for the store.
	/// </summary>
	[JsonPropertyName("id")]
	[Key(7)]
	public string Id { get; set; } = default!; 

	/// <summary>
	/// Gets or sets the links.
	/// </summary>
	[JsonPropertyName("_links")]
	[Key(8)]
	public IEnumerable<Link> Links { get; set; } = new HashSet<Link>();

	/// <summary>
	/// The unique identifier for the <a href="http://developer.mailchimp.com/documentation/mailchimp/reference/lists/">MailChimp List</a> associated with the store. The list_id for a specific store cannot change.
	/// </summary>
	[JsonPropertyName("list_id")]
	[Key(9)]
	public string? ListId { get; set; }

	/// <summary>
	/// Gets or sets the money format.
	/// For example: $, £, etc.
	/// </summary>
	[JsonPropertyName("money_format")]
	[Key(10)]
	public string? MoneyFormat { get; set; }

	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	[JsonPropertyName("name")]
	[Key(11)]
	public string? Name { get; set; }

	/// <summary>
	/// The store phone number.
	/// </summary>
	[JsonPropertyName("phone")]
	[Key(12)]
	public string? Phone { get; set; }

	/// <summary>
	/// Gets or sets the primary locale.
	/// For example: en, de, etc.
	/// </summary>
	[JsonPropertyName("primary_locale")]
	[Key(13)]
	public string? PrimaryLocale { get; set; }

	/// <summary>
	/// The timezone for the store.
	/// </summary>
	[JsonPropertyName("timezone")]
	[Key(14)]
	public string? Timezone { get; set; }

	/// <summary>
	/// Gets or sets the updated at.
	/// </summary>
	[JsonPropertyName("updated_at")]
	[Key(15)]
	public DateTime? UpdatedAt { get; set; }
}