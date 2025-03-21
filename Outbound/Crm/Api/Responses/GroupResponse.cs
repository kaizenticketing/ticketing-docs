using System.Text.Json.Serialization;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class GroupResponse
{
	/// <summary>
	/// Gets or sets the category id.
	/// </summary>
	[JsonPropertyName("category_id")]
	public string CategoryId { get; set; } = default!;

	/// <summary>
	/// Gets or sets the interests.
	/// </summary>
	[JsonPropertyName("interests")]
	public IEnumerable<Group> Interests { get; set; } = new HashSet<Group>();

	/// <summary>
	/// Gets or sets the links.
	/// </summary>
	[JsonPropertyName("_links")]
	public IEnumerable<Link> Links { get; set; } = new HashSet<Link>();

	/// <summary>
	/// Gets or sets the list id.
	/// </summary>
	[JsonPropertyName("list_id")]
	public string ListId { get; set; } = default!;

	/// <summary>
	/// Gets or sets the total items.
	/// </summary>
	[JsonPropertyName("total_items")]
	public int TotalItems { get; set; }
}