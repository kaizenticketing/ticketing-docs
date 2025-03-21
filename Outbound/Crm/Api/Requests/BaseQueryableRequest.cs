namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

/// <summary>
/// The queryable base request.
/// </summary>
public class BaseQueryableRequest : BaseRequest
{
	/// <summary>
	/// Gets or sets the limit.
	/// </summary>
	[QueryString("count")]
	public int Limit { get; set; }

	/// <summary>
	/// Gets or sets the offset.
	/// </summary>
	[QueryString("offset")]
	public int Offset { get; set; }
}