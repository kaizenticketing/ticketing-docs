

using System.Net.Http;
using System.Net.Http.Json;
using Kaizen.Http;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

/*
	Audiences used to be called Lists in their UI.
*/
public partial class MailchimpClient
{
	public async ValueTask<Audience> AddOrUpdateAsync(
		Audience audience,
		CancellationToken cancellationToken = default)
	{
		HttpResponseMessage response;
		if (string.IsNullOrWhiteSpace(audience.Id))
		{
			response = await httpClient.PostAsJsonAsync(
				$"lists", audience, Options, cancellationToken
			);
		}
		else
		{
			response = await httpClient.PatchAsJsonAsync(
				$"lists/{audience.Id}", audience, Options, cancellationToken
			);
		}

		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		return await response.Content.ReadFromJsonAsync<Audience>(
				Options, cancellationToken
			) ?? throw new InvalidOperationException("Response required");
	}

	public async ValueTask<IEnumerable<Audience>> GetAllAudiencesAsync(
		AudienceRequest? request = null,
		CancellationToken cancellationToken = default)
	{
		return (await GetResponseAsync(request)).Lists;

		//

		async ValueTask<AudienceResponse> GetResponseAsync(
			AudienceRequest? request = null)
		{
			request ??= new AudienceRequest
			{
				Limit = Limit
			};

			var response = await httpClient.GetAsync($"lists{request.ToQueryString()}", cancellationToken);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var audienceResponse = await response.Content.ReadFromJsonAsync<AudienceResponse>(
				Options, cancellationToken
			);

			return audienceResponse ?? throw new InvalidOperationException("Response required");
		}
	}

	public async ValueTask<Audience?> GetAudienceAsync(
		string id,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var response = await httpClient.GetAsync($"lists/{id}", cancellationToken);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Audience?>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}
		catch (MailChimpException mex) when (mex.Status == 404)
		{
			return null;
		}
	}

	public async ValueTask DeleteAudienceAsync(
		string audienceId,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync($"lists/{audienceId}", cancellationToken);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}
}