

using System.Net.Http.Json;
using Kaizen.Http;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public partial class MailchimpClient
{
	// NOTE: can't do AddOrUpdateAsync as CLIENT SUPPLIES THE ID

	public async ValueTask<Store> AddAsync(
		Store store,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.PostAsJsonAsync(
			$"ecommerce/stores", store, Options, cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		return await response.Content.ReadFromJsonAsync<Store>(
				Options, cancellationToken
			) ?? throw new InvalidOperationException("Response required");
	}

	public async ValueTask<IEnumerable<Store>> GetAllStoresAsync(
		BaseQueryableRequest? request = null,
		CancellationToken cancellationToken = default)
	{
		return (await GetResponseAsync(request)).Stores;

		//

		async ValueTask<ECommerceResponse> GetResponseAsync(
			BaseQueryableRequest? request = null)
		{
			request ??= new BaseQueryableRequest
			{
				Limit = Limit
			};

			var response = await httpClient.GetAsync(
				$"ecommerce/stores/{request.ToQueryString()}", cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var listResponse = await response.Content.ReadFromJsonAsync<ECommerceResponse>(
				Options, cancellationToken
			);

			return listResponse ?? throw new InvalidOperationException("Response required");
		}
	}

	public async ValueTask<Store?> GetStoreAsync(
		string storeId,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var response = await httpClient.GetAsync(
				$"ecommerce/stores/{storeId}", cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Store>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}
		catch (MailChimpException mex) when (mex.Status == 404)
		{
			return null;
		}
	}

	public async ValueTask<Store> UpdateAsync(
		Store store,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.PatchAsJsonAsync(
				$"ecommerce/stores/{store.Id}", store, Options, cancellationToken
			);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		return await response.Content.ReadFromJsonAsync<Store>(
				Options, cancellationToken
			) ?? throw new InvalidOperationException("Response required");
	}

	public async ValueTask DeleteStoreAsync(
		string storeId,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync(
			$"ecommerce/stores/{storeId}", cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}
}