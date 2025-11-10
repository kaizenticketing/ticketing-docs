namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

using System.Text.Json.Serialization;

public class MergeField
{
	[JsonPropertyName("merge_id")]
	public int? Id { get; set; }

	[JsonPropertyName("tag")]
	public string Tag { get; set; } = default!;

	[JsonPropertyName("name")]
	public string Name { get; set; } = default!;

	[JsonPropertyName("type")]
	public string Type { get; set; } = default!;

	[JsonPropertyName("required")]
	public bool Required { get; set; }

	[JsonPropertyName("default_value")]
	public string DefaultValue { get; set; } = "";

	[JsonPropertyName("public")]
	public bool Public { get; set; }

	[JsonPropertyName("display_order")]
	public int DisplayOrder { get; set; }

	[JsonPropertyName("options")]
	public Options Options { get; set; } = default!;

	[JsonPropertyName("help_text")]
	public string HelpText { get; set; } = "";

	[JsonPropertyName("list_id")]
	public string ListId { get; set; } = default!;

	[JsonPropertyName("_links")]
	public IEnumerable<Link> Links { get; set; } = new HashSet<Link>();
}
