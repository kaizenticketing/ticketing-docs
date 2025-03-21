

using System.Net.Http;
using System.Net.Http.Json;
using Kaizen.Http;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public partial class MailchimpClient
{
	public async ValueTask<MergeField> AddOrUpdateAsync(
		string audienceId,
		MergeField mergeField,
		CancellationToken cancellationToken = default)
	{
		HttpResponseMessage response;
		if (mergeField.Id == null)
		{
			response = await httpClient.PostAsJsonAsync(
				$"lists/{audienceId}/merge-fields", mergeField, Options, cancellationToken
			);
		}
		else
		{
			response = await httpClient.PatchAsJsonAsync(
				$"lists/{audienceId}/merge-fields/{mergeField.Id}", mergeField, Options, cancellationToken
			);
		}

		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		return await response.Content.ReadFromJsonAsync<MergeField>(
				Options, cancellationToken
			) ?? throw new InvalidOperationException("Response required");
	}

	public async ValueTask<IEnumerable<MergeField>> GetAllMergeFieldsAsync(
		string audienceId,
		MergeFieldRequest? request = null,
		CancellationToken cancellationToken = default)
	{
		request ??= new MergeFieldRequest
		{
			Limit = Limit
		};

		return (await GetResponseAsync(audienceId, request)).MergeFields;

		//

		async ValueTask<MergeFieldResponse> GetResponseAsync(
			string audienceId,
			MergeFieldRequest? request = null)
		{
			request ??= new MergeFieldRequest
			{
				Limit = Limit
			};

			var response = await httpClient.GetAsync(
				$"lists/{audienceId}/merge-fields{request.ToQueryString()}",
				cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var mergeResponse = await response.Content.ReadFromJsonAsync<MergeFieldResponse>(
				Options, cancellationToken
			);

			return mergeResponse ?? throw new InvalidOperationException("Response required");
		}
	}

	public async ValueTask<MergeField?> GetMergeFieldAsync(
		string audienceId,
		int id,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var response = await httpClient.GetAsync(
				$"lists/{audienceId}/merge-fields/{id}",
				cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var mergeField = await response.Content.ReadFromJsonAsync<MergeField>(
				Options, cancellationToken
			);

			return mergeField;
		}
		catch (MailChimpException mex) when (mex.Status == 404)
		{
			return null;
		}
	}

	public async ValueTask DeleteMergeFieldAsync(
		string audienceId,
		int id,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync(
			$"lists/{audienceId}/merge-fields/{id}",
			cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}
}