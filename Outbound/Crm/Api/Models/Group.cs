using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

// used to be called an Interest
public class Group
{
	/// <summary>
	/// Gets or sets the display order.
	/// </summary>
	[JsonPropertyName("display_order")]
	public int DisplayOrder { get; set; }

	/// <summary>
	/// Gets or sets the id.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets or sets the interest category id.
	/// </summary>
	[JsonPropertyName("category_id")]
	public string? InterestCategoryId { get; set; }

	/// <summary>
	/// Gets or sets the links.
	/// </summary>
	[JsonPropertyName("_links")]
	public IEnumerable<Link> Links { get; set; } = new HashSet<Link>();

	/// <summary>
	/// Gets or sets the list id.
	/// </summary>
	[JsonPropertyName("list_id")]
	public string? ListId { get; set; }

	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the subscriber count.
	/// </summary>
	[JsonPropertyName("subscriber_count")]
	public string? SubscriberCount { get; set; }
}