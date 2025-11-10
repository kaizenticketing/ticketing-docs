
namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class GroupCategoryRequest : BaseQueryableRequest
{
	/// <summary>
	/// Gets or sets the type.
	/// </summary>
	[QueryString("type")]
	public string Type { get; set; } = default!; 
}