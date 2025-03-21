using System.Net.Http;
using System.Net.Http.Json;
using Kaizen.Http;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public partial class MailchimpClient
{
	public async ValueTask<Campaign> AddOrUpdateAsync(
		Campaign campaign,
		CancellationToken cancellationToken = default)
	{
		HttpResponseMessage response;
		if (string.IsNullOrWhiteSpace(campaign.Id))
		{
			response = await httpClient.PostAsJsonAsync(
				$"campaigns", campaign, Options, cancellationToken
			);
		}
		else
		{
			response = await httpClient.PatchAsJsonAsync(
				$"campaigns/{campaign.Id}", campaign, Options, cancellationToken
			);
		}

		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		return await response.Content.ReadFromJsonAsync<Campaign>(
				Options, cancellationToken
			) ?? throw new InvalidOperationException("Response required");
	}

	public async ValueTask<IEnumerable<Campaign>> GetAllCampaignsAsync(
		CampaignRequest? request = null,
		CancellationToken cancellationToken = default)
	{
		return (await GetResponseAsync(request)).Campaigns;

		//

		async ValueTask<CampaignResponse> GetResponseAsync(
			CampaignRequest? request = null)
		{
			request ??= new CampaignRequest
			{
				Limit = Limit
			};

			var response = await httpClient.GetAsync($"campaigns{request.ToQueryString()}", cancellationToken);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var campaignResponse = await response.Content.ReadFromJsonAsync<CampaignResponse>(
				Options, cancellationToken
			);

			return campaignResponse ?? throw new InvalidOperationException("Response required");
		}
	}

	public async ValueTask<Campaign?> GetCampaignAsync(
		string id,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var response = await httpClient.GetAsync($"campaigns/{id}", cancellationToken);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Campaign?>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}
		catch (MailChimpException mex) when (mex.Status == 404)
		{
			return null;
		}
	}

	public async ValueTask DeleteCampaignAsync(
		string campaignId,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync($"campaigns/{campaignId}", cancellationToken);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}
}