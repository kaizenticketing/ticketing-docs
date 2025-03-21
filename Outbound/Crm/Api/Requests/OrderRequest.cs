namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public class OrderRequest : BaseQueryableRequest
{
	[QueryString("customer_id")]
	public string CustomerId { get; set; } = default!;
}
