using System.Net.Http;
using System.Net.Http.Json;
using Kaizen.Http;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public partial class MailchimpClient
{
	public async ValueTask<GroupCategory> AddOrUpdateAsync(
		string audienceId,
		GroupCategory category,
		CancellationToken cancellationToken = default)
	{
		HttpResponseMessage response;
		if (category.Id == null)
		{
			response = await httpClient.PostAsJsonAsync(
				$"lists/{audienceId}/interest-categories", category, Options, cancellationToken
			);
		}
		else
		{
			response = await httpClient.PatchAsJsonAsync(
				$"lists/{audienceId}/interest-categories/{category.Id}", category, Options, cancellationToken
			);
		}

		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		return await response.Content.ReadFromJsonAsync<GroupCategory>(
				Options, cancellationToken
			) ?? throw new InvalidOperationException("Response required");
	}

	public async ValueTask<IEnumerable<GroupCategory>> GetAllGroupCategoriesAsync(
		string listId,
		GroupCategoryRequest? request = null,
		CancellationToken cancellationToken = default)
	{
		return (await GetResponseAsync(listId, request)).Categories;

		//

		async ValueTask<GroupCategoryResponse> GetResponseAsync(
			string audienceId,
			GroupCategoryRequest? request = null)
		{
			request ??= new GroupCategoryRequest
			{
				Limit = Limit
			};

			var response = await httpClient.GetAsync(
				$"lists/{audienceId}/interest-categories{request.ToQueryString()}",
				cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var groupCategoryResponse = await response.Content.ReadFromJsonAsync<GroupCategoryResponse>(
				Options, cancellationToken
			);
			return groupCategoryResponse ?? throw new InvalidOperationException("Response required");
		}
	}

	public async ValueTask<GroupCategory?> GetGroupCategoryAsync(
		string audienceId,
		string id,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var response = await httpClient.GetAsync(
				$"lists/{audienceId}/interest-categories/{id}",
				cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var groupCategory = await response.Content.ReadFromJsonAsync<GroupCategory?>(
				Options, cancellationToken
			);
			return groupCategory;
		}
		catch (MailChimpException mex) when (mex.Status == 404)
		{
			return null;
		}
	}

	public async ValueTask DeleteGroupCategoryAsync(
		string audienceId,
		string id,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync(
			$"lists/{audienceId}/interest-categories/{id}",
			cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}

	//

	public async ValueTask<Group> AddOrUpdateAsync(
		string audienceId,
		string groupCategoryId,
		Group group,
		CancellationToken cancellationToken = default)
	{
		HttpResponseMessage response;
		if (group.Id == null)
		{
			response = await httpClient.PostAsJsonAsync(
				$"lists/{audienceId}/interest-categories/{groupCategoryId}/interests", group,
				Options, cancellationToken
			);
		}
		else
		{
			response = await httpClient.PatchAsJsonAsync(
				$"lists/{audienceId}/interest-categories/{groupCategoryId}/interests/{group.Id}", group,
				Options, cancellationToken
			);
		}

		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		return await response.Content.ReadFromJsonAsync<Group>(
				Options, cancellationToken
			) ?? throw new InvalidOperationException("Response required");
	}

	public async ValueTask<IEnumerable<Group>> GetAllGroupsAsync(
		string audienceId,
		string groupCategoryId,
		BaseQueryableRequest? request = null,
		CancellationToken cancellationToken = default)
	{
		return (await GetResponseAsync(audienceId, groupCategoryId, request)).Interests;

		//

		async ValueTask<GroupResponse> GetResponseAsync(
			string audienceId,
			string groupCategoryId,
			BaseQueryableRequest? request = null)
		{
			request ??= new BaseQueryableRequest
			{
				Limit = Limit
			};

			var response = await httpClient.GetAsync(
				$"lists/{audienceId}/interest-categories/{groupCategoryId}/interests{request.ToQueryString()}",
				cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var groupResponse = await response.Content.ReadFromJsonAsync<GroupResponse>(
				Options, cancellationToken
			);
			return groupResponse ?? throw new InvalidOperationException("Response required");
		}
	}

	public async ValueTask<Group?> GetGroupAsync(
		string audienceId,
		string groupCategoryId,
		string id,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.GetAsync(
			$"lists/{audienceId}/interest-categories/{groupCategoryId}/interests/{id}",
			cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		var group = await response.Content.ReadFromJsonAsync<Group?>(
			Options, cancellationToken
		);
		return group;
	}

	public async ValueTask DeleteGroupAsync(
		string audienceId,
		string categoryId,
		string id,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync(
			$"lists/{audienceId}/interest-categories/{categoryId}/interests/{id}",
			cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}
}
