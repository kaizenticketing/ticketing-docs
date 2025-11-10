using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

// NOTE: used to be called InterestCategories
public class GroupCategory
{
	/// <summary>
	/// Gets or sets the display order.
	/// </summary>
	[JsonPropertyName("display_order")]
	public int DisplayOrder { get; set; }

	/// <summary>
	/// Gets or sets the display type.
	/// </summary>
	[JsonPropertyName("type")]
	public string? DisplayType { get; set; }

	/// <summary>
	/// Gets the id.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Gets the list id.
	/// </summary>
	[JsonPropertyName("list_id")]
	public string? ListId { get; set; }

	/// <summary>
	/// Gets or sets the title.
	/// </summary>
	[JsonPropertyName("title")]
	public string? Title { get; set; }
}