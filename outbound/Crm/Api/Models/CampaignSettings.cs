using System.Text.Json.Serialization;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class CampaignSettings
{
	/// <summary>
	/// Gets or sets a value indicating whether authenticate.
	/// </summary>
	[JsonPropertyName("authenticate")]
	public bool? Authenticate { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether auto footer.
	/// </summary>
	[JsonPropertyName("auto_footer")]
	public bool? AutoFooter { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether auto tweet.
	/// </summary>
	[JsonPropertyName("auto_tweet")]
	public bool? AutoTweet { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether drag and drop.
	/// </summary>
	[JsonPropertyName("drag_and_drop")]
	public bool? DragAndDrop { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether fb comments.
	/// </summary>
	[JsonPropertyName("fb_comments")]
	public bool? FbComments { get; set; }

	/// <summary>
	/// Gets or sets the folder id.
	/// </summary>
	[JsonPropertyName("folder_id")]
	public string? FolderId { get; set; }

	/// <summary>
	/// Gets or sets the from name.
	/// </summary>
	[JsonPropertyName("from_name")]
	public string? FromName { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether inline css.
	/// </summary>
	[JsonPropertyName("inline_css")]
	public bool InlineCss { get; set; }

	/// <summary>
	/// Gets or sets the reply to.
	/// </summary>
	[JsonPropertyName("reply_to")]
	public string? ReplyTo { get; set; }

	/// <summary>
	/// Gets or sets the preview text.
	/// </summary>
	[JsonPropertyName("preview_text")]
	public string? PreviewText { get; set; }

	/// <summary>
	/// Gets or sets the subject line.
	/// </summary>
	[JsonPropertyName("subject_line")]
	public string? SubjectLine { get; set; }

	/// <summary>
	/// Gets or sets the template id.
	/// </summary>
	[JsonPropertyName("template_id")]
	public int? TemplateId { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether timewarp.
	/// </summary>
	[JsonPropertyName("timewarp")]
	public bool? Timewarp { get; set; }

	/// <summary>
	/// Gets or sets the title.
	/// </summary>
	[JsonPropertyName("title")]
	public string? Title { get; set; }

	/// <summary>
	/// Gets or sets the to name.
	/// </summary>
	[JsonPropertyName("to_name")]
	public string? ToName { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether use conversation.
	/// </summary>
	[JsonPropertyName("use_conversation")]
	public bool? UseConversation { get; set; }
}