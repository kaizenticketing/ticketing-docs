using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public partial class MailchimpClient : IMailchimpClient
{
	private static readonly JsonSerializerOptions Options = new()
	{
		// if a value is 'null' just don't serialize the key (good for PATCH)
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	};

	public const int Limit = 100;

	//

	private readonly ILifetimeScope container;
	private readonly ILogger<MailchimpClient> log;
	private readonly IClock clock;
	private readonly MailchimpContext context;

	private readonly HttpClient httpClient;

	public MailchimpClient(
		ILifetimeScope container,
		ILogger<MailchimpClient> log,
		IClock clock,
		IHttpClientFactory httpClientFactory,
		//
		MailchimpContext context)
	{
		this.container = container;
		this.log = log;
		this.clock = clock;
		//
		this.context = context;
		this.httpClient = GetClient();

		//

		HttpClient GetClient()
		{
			// grab a new httpclient using a pooled HttpClientMessageHandler
			var client = httpClientFactory.CreateClient(nameof(MailchimpClient));

			// customise the httpclient with defaults
			string apiKey = context.Configuration.ApiKey;
			string dataCenter = string.IsNullOrWhiteSpace(apiKey)
				? string.Empty
				: apiKey.Substring(
					apiKey.LastIndexOf('-') + 1,
					apiKey.Length - apiKey.LastIndexOf('-') - 1
				);

			// set the base address to the right 'data center'
			client.BaseAddress = new Uri($"https://{dataCenter}.api.mailchimp.com/3.0/");

			// if an access token is configured, use that, if not fall back on an API key - using an access token
			// .. allows us to explicitly show that 'members' came from us and not another source
			if (!string.IsNullOrEmpty(context.Configuration.AccessToken))
				client.DefaultRequestHeaders.Add("Authorization", $"OAuth {context.Configuration.AccessToken}");
			else
				client.DefaultRequestHeaders.Add("Authorization", $"apikey {context.Configuration.ApiKey}");

			return client;
		}
	}

	public static async ValueTask EnsureMailChimpSuccessAsync(
		HttpResponseMessage response,
		CancellationToken cancellationToken = default)
	{
		if (!response.IsSuccessStatusCode)
		{
			// deserialize 'api error' response from MC and wrap in an exception
			try
			{
				var error = await response.Content.ReadFromJsonAsync<MailChimpApiError>(
					Options, cancellationToken
				);

				throw new MailChimpException(error ?? throw new InvalidOperationException(), response);
			}
			catch (JsonException jex)
			{
				// if its an error like a 404 - then it can come back in XML!! but doesn't set Content-Type!
				// .. so we just let the json parse fail and capture here
				throw new MailChimpException(
					new MailChimpApiError()
					{
						Type = "Unable to parse JSON / wrong content type",
						Title = "Unable to parse JSON / wrong content type",
						Status = 400, // i think in all cases ive seen we get these errors when our requests are bad?
						Detail = jex.ToString()
					},
					response
				);
			}
		}
	}
}