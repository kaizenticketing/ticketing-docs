using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

/// <summary>
/// The tag for a member
/// This one differs from the MemberTag model because it has status field and no id field.
/// This is the format expected by MailChimp's API for managing member tags.
/// </summary>
public class Tag
{
	/// <summary>
	/// Gets or sets the tag's name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Gets or sets the tag's status(active/inactive).
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

}

/// <summary>
/// We need this only for the serialization purpose, to wrap the list of type Tag into a list with JsonProperty "tags"
/// expected format: {tags: [{name: "tagName1", status: "active"}, {name: "tagName2", status: "inactive"}]}
/// </summary>
public class Tags
{
	public Tags()
	{
		MemberTags = new List<Tag>();
	}

	[JsonPropertyName("tags")]
	public List<Tag> MemberTags { get; set; }
}
