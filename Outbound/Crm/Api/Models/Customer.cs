namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

public class Customer
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("email_address")]
	public string? EmailAddress { get; set; }

	[JsonPropertyName("opt_in_status")]
	public bool? OptInStatus { get; set; }

	[JsonPropertyName("company")]
	public string? Company { get; set; }

	[JsonPropertyName("first_name")]
	public string? FirstName { get; set; }

	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	[JsonPropertyName("orders_count")]
	public int? OrdersCount { get; set; }

	[JsonPropertyName("total_spent")]
	public decimal? TotalSpent { get; set; }

	[JsonPropertyName("address")]
	public Address? Address { get; set; }

	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	[JsonPropertyName("_links")]
	public ICollection<Link> Links { get; set; } = new HashSet<Link>();
}
