using System.Net.Http.Json;
using Kaizen.Text;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public partial class MailchimpClient
{
	private static readonly string[] OrderErrorsToRetryAsUpdates = new string[] {
		"An order with the provided ID already exists in the account", // order already exists
		"An order may not contain the same line item id more than once." // order (partially?) created whilst being updated?
	};

	public async ValueTask<Order> AddOrUpdateAsync(
		string storeId,
		Order mcOrder,
		CancellationToken cancellationToken = default)
	{
		try
		{
			// firstly - try adding the order, full in the expectation that this might fail as it already exists
			// TODO: this happens because of publishes racing around order creation, issuing, printing etc - in theory that might
			// TODO: .. cause MC data problems if we care about any of those states?
			mcOrder = await AddAsync(
				storeId, mcOrder, cancellationToken
			);
		}
		catch (MailChimpException mex) when (mex.Detail.ContainsAny(OrderErrorsToRetryAsUpdates))
		{
			// fallback to updating
			mcOrder = await UpdateAsync(
				storeId, mcOrder, cancellationToken
			);
		}

		return mcOrder;

		//

		async ValueTask<Order> AddAsync(
			string storeId,
			Order mcOrder,
			CancellationToken cancellationToken = default)
		{
			var response = await httpClient.PostAsJsonAsync(
				$"ecommerce/stores/{storeId}/orders", mcOrder, Options, cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Order>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}

		async ValueTask<Order> UpdateAsync(
			string storeId,
			Order mcOrder,
			CancellationToken cancellationToken = default)
		{
			var response = await httpClient.PatchAsJsonAsync(
					$"ecommerce/stores/{storeId}/orders/{mcOrder.Id}", mcOrder,
					Options, cancellationToken
				);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Order>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}
	}

	public async ValueTask<Order?> GetOrderAsync(
		string storeId,
		string id,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var response = await httpClient.GetAsync(
				$"ecommerce/stores/{storeId}/orders/{id}", cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Order>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}
		catch (MailChimpException mex) when (mex.Status == 404)
		{
			return null;
		}
	}

	public async ValueTask DeleteOrderAsync(
		string storeId,
		string id,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync(
			$"ecommerce/stores/{storeId}/orders/{id}", cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}
}
