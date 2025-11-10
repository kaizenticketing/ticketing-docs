

using System.Net.Http.Json;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public partial class MailchimpClient
{
	// NOTE: can't do AddOrUpdateAsync as CLIENT SUPPLIES THE ID

	public async ValueTask<Product> CreateOrUpdateAsync(string storeId, Product mcProduct, CancellationToken cancellationToken = default)
	{
		// TODO: there can be races here - two publishes creating a product (eg. publishing and synching inventory for an event)
		// TODO: .. so we have to tolerate that
		/*
		System.AggregateException: Unable to push products to mailchimp (Title: Bad Request
		Type: https://mailchimp.com/developer/marketing/docs/errors/
		Status: 400
		Instance: 95d1b53f-d628-a8e4-73fb-a152528fc727
		Detail: We were unable to process the request. A product with the provided ID already exists in the account.
		Errors: 
		Request URI:https://us18.api.mailchimp.com/3.0/ecommerce/stores/chanl_00000000-0000-0000-0003-000000000032/products
		)
		---> Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.MailChimpException: Title: Bad Request
		Type: https://mailchimp.com/developer/marketing/docs/errors/
		Status: 400
		Instance: 95d1b53f-d628-a8e4-73fb-a152528fc727
		Detail: We were unable to process the request. A product with the provided ID already exists in the account.
		Errors: 
		Request URI:https://us18.api.mailchimp.com/3.0/ecommerce/stores/chanl_00000000-0000-0000-0003-000000000032/products
		*/

		try
		{
			// try and create first
			mcProduct = await AddAsync(
				storeId, mcProduct, cancellationToken
			);
		}
		catch (MailChimpException mce) when (mce.Status == 400)
		{
			// fallback to updating
			mcProduct = await UpdateAsync(
				storeId, mcProduct, cancellationToken
			);
		}

		return mcProduct;

		//

		async ValueTask<Product> AddAsync(
			string storeId,
			Product product,
			CancellationToken cancellationToken = default)
		{
			var response = await httpClient.PostAsJsonAsync(
				$"ecommerce/stores/{storeId}/products", product, Options, cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Product>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}

		async ValueTask<Product> UpdateAsync(
			string storeId,
			Product product,
			CancellationToken cancellationToken = default)
		{
			var response = await httpClient.PatchAsJsonAsync(
					$"ecommerce/stores/{storeId}/products/{product.Id}", product,
					Options, cancellationToken
				);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Product>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}
	}



	public async ValueTask<IEnumerable<Product>> GetAllProductsAsync(
		string storeId,
		BaseQueryableRequest? request = null,
		CancellationToken cancellationToken = default)
	{
		return (await GetResponseAsync(request)).Products;

		//

		async ValueTask<ProductResponse> GetResponseAsync(
			BaseQueryableRequest? request = null)
		{
			request ??= new BaseQueryableRequest
			{
				Limit = Limit
			};

			var response = await httpClient.GetAsync(
				$"ecommerce/stores/{storeId}/products{request.ToQueryString()}", cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var listResponse = await response.Content.ReadFromJsonAsync<ProductResponse>(
				Options, cancellationToken
			);

			return listResponse ?? throw new InvalidOperationException("Response required");
		}
	}

	public async ValueTask<Product?> GetProductByIdAsync(
		string storeId,
		string productId,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var response = await httpClient.GetAsync(
				$"ecommerce/stores/{storeId}/products/{productId}", cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Product>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}
		catch (MailChimpException mex) when (mex.Status == 404)
		{
			return null;
		}
	}

	public async ValueTask DeleteProductAsync(
		string storeId,
		string id,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync(
			$"ecommerce/stores/{storeId}/products/{id}", cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}
}
