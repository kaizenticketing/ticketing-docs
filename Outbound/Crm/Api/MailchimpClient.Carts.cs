

using System.Net.Http;
using System.Net.Http.Json;
using Kaizen.Http;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public partial class MailchimpClient
{
	public async ValueTask<Cart> AddAsync(
		string storeId,
		Cart cart,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.PostAsJsonAsync(
			$"ecommerce/stores/{storeId}/carts", cart, Options, cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		return await response.Content.ReadFromJsonAsync<Cart>(
				Options, cancellationToken
			) ?? throw new InvalidOperationException("Response required");
	}

	public async ValueTask<Cart?> GetCartAsync(
		string storeId,
		string id,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var response = await httpClient.GetAsync(
				$"ecommerce/stores/{storeId}/carts/{id}", cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Cart>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}
		catch (MailChimpException mex) when (mex.Status == 404)
		{
			return null;
		}
	}

	public async ValueTask<Cart> UpdateAsync(
		string storeId,
		Cart cart,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.PatchAsJsonAsync(
				$"ecommerce/stores/{storeId}/carts/{cart.Id}", cart, 
				Options, cancellationToken
			);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		return await response.Content.ReadFromJsonAsync<Cart>(
				Options, cancellationToken
			) ?? throw new InvalidOperationException("Response required");
	}
	
	public async ValueTask DeleteCartAsync(
		string storeId,
		string id,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync(
			$"ecommerce/stores/{storeId}/carts/{id}", cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}
}
