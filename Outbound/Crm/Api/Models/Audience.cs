using System.Text.Json.Serialization;
using Kaizen.Serialization.JsonConverters.SystemText;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

// NOTE: used to be called a 'list'
[MessagePackObject] // so that these can be cached!
public class Audience
{
	/// <summary>
	/// Gets or sets the beamer address.
	/// </summary>
	[JsonPropertyName("beamer_address")]
	[Key(0)]
	public string? BeamerAddress { get; set; }

	/// <summary>
	/// Gets or sets the campaign defaults.
	/// </summary>
	[JsonPropertyName("campaign_defaults")]
	[Key(1)]
	public CampaignDefaults? CampaignDefaults { get; set; }

	/// <summary>
	/// Gets or sets the contact.
	/// </summary>
	[JsonPropertyName("contact")]
	[Key(2)]
	public Contact? Contact { get; set; }

	/// <summary>
	/// Gets or sets the date created.
	/// </summary>
	[JsonPropertyName("date_created")]
	[Key(3)]
	public DateTime DateCreated { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether email type option.
	/// </summary>
	[JsonPropertyName("email_type_option")]
	[Key(4)]
	public bool EmailTypeOption { get; set; }

	/// <summary>
	/// Gets or sets the id.
	/// </summary>
	[JsonPropertyName("id")]
	[Key(5)]
	public string? Id { get; set; } = default!; 

	/// <summary>
	/// Gets or sets the web id.
	/// </summary>
	[JsonPropertyName("web_id")]
	[Key(6)]
	public int WebId { get; set; }

	/// <summary>
	/// Gets or sets the links.
	/// </summary>
	[JsonPropertyName("_links")]
	[Key(7)]
	public IEnumerable<Link> Links { get; set; } = new HashSet<Link>();

	/// <summary>
	/// Gets or sets the list rating.
	/// </summary>
	[JsonPropertyName("list_rating")]
	[Key(8)]
	public int ListRating { get; set; }

	/// <summary>
	/// Gets or sets the modules.
	/// </summary>
	[JsonPropertyName("modules")]
	[Key(9)]
	public object[]? Modules { get; set; }

	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	[JsonPropertyName("name")]
	[Key(10)]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the notify on subscribe.
	/// </summary>
	[JsonPropertyName("notify_on_subscribe")]
	[Key(11)]
	public string? NotifyOnSubscribe { get; set; }

	/// <summary>
	/// Gets or sets the notify on unsubscribe.
	/// </summary>
	[JsonPropertyName("notify_on_unsubscribe")]
	[Key(12)]
	public string? NotifyOnUnsubscribe { get; set; }

	/// <summary>
	/// Gets or sets the permission reminder.
	/// </summary>
	[JsonPropertyName("permission_reminder")]
	[Key(13)]
	public string? PermissionReminder { get; set; }

	/// <summary>
	/// Gets or sets the stats.
	/// </summary>
	// [JsonPropertyName("stats")]
	// [Key(14)]
	// public Stats Stats { get; set; }

	/// <summary>
	/// Gets or sets the subscribe url long.
	/// </summary>
	[JsonPropertyName("subscribe_url_long")]
	[Key(15)]
	public string? SubscribeUrlLong { get; set; }

	/// <summary>
	/// Gets or sets the subscribe url short.
	/// </summary>
	[JsonPropertyName("subscribe_url_short")]
	[Key(16)]
	public string? SubscribeUrlShort { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether use archive bar.
	/// </summary>
	[JsonPropertyName("use_archive_bar")]
	[Key(17)]
	public bool UseArchiveBar { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether or not the list 
	/// has marketing permissions (eg. GDPR) enabled.
	/// </summary>
	[JsonPropertyName("marketing_permissions")]
	[Key(18)]
	public bool MarketingPermissions { get; set; }

	/// <summary>
	/// Whether or not to require the subscriber to confirm subscription via email.
	/// </summary>
	[JsonPropertyName("double_optin")]
	[Key(19)]
	public bool DoubleOptin { get; set; }

	/// <summary>
	/// Whether or not this list has a welcome automation connected. Welcome Automations: welcomeSeries, singleWelcome, emailFollowup.
	/// </summary>
	[JsonPropertyName("has_welcome")]
	[Key(20)]
	public bool HasWelcome { get; set; }

	/// <summary>
	/// Gets or sets the visibility.
	/// </summary>
	[JsonPropertyName("visibility")]
	[Key(21)]
	[JsonConverter(typeof(EnumDescriptionJsonConverter<Visibility>))]
	public Visibility Visibility { get; set; } = Visibility.Private;
}