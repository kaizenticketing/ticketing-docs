using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using Kaizen.Text;
using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public partial class MailchimpClient
{
	static readonly string[] MemberExceptionsToSwallow = new[] {
			"Please provide a valid email address.", // mailchimp considers the email invalid (can't do anything)
			"looks fake or invalid, please enter a real email address.", // as above
			"is in a compliance state due to unsubscribe, bounce, or compliance review and cannot be subscribed.", // they unsubscribed OUTSIDE of our integration
			// TODO: unsure what is causing this since examples seen are NOT registered on multiple lists AND have right email casing - ignoring
			// "is already a list member. Use PUT to insert or update list members.", 
			// // TODO: silencing as not sure how to fix when this gives an error of "Please enter a complete address" - example failure (redacted) is: "Apartment x, x back mersey view, A22 2aa, United Kingdom"
			// "Your merge fields were invalid" 
			"was permanently deleted and cannot be re-imported. The contact must re-subscribe to get back on the list."
		};

	public async ValueTask<Member> AddOrUpdateAsync(
		string audienceId,
		Member member,
		CancellationToken cancellationToken = default)
	{
		try
		{
			// NOTE: bit different from most other object types, as MC API supports a single PUT that will handle
			// .. add or update as appropriate - we have to generate an Id for the member
			// TODO: handle accounts with no email address - hash accountId instead? but for now we don't actually
			// TODO: .. WANT to have accounts with no email make it over
			var subscriberHash = member.Id
				?? GetSubscriberHash(member.EmailAddress?.ToLower() ?? throw new InvalidOperationException("Required"));
			
			var existingMember = await GetMemberAsync(audienceId, member.EmailAddress!, cancellationToken);
			
			if (existingMember == null && member.Status == MemberStatus.Unsubscribed)
			{
				return member;
			}

			var response = await httpClient.PutAsJsonAsync(
				$"lists/{audienceId}/members/{subscriberHash}", member,
				Options, cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			return await response.Content.ReadFromJsonAsync<Member>(
					Options, cancellationToken
				) ?? throw new InvalidOperationException("Response required");
		}
		catch (MailChimpException mex) when (mex.Detail.ContainsAny(MemberExceptionsToSwallow))
		{
			// nop - ok we might have missed one but latest will win anyway
			log.LogWarning(mex, "Failed to update/add a member to mailchimp: listId = {listId}, memberId = {memberId}", audienceId, member.Id);
			return member;
		}
	}

	public async ValueTask<int> GetMemberCountAsync(
		string audienceId,
		MemberStatus? status,
		CancellationToken cancellationToken = default)
	{
		var memberRequest = new MemberRequest { Status = status, FieldsToInclude = "total_items" };

		var response = await httpClient.GetAsync(
			$"lists/{audienceId}/members{memberRequest.ToQueryString()}",
			cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);

		var memberResponse = await response.Content.ReadFromJsonAsync<MemberResponse>(
			Options, cancellationToken
		);

		return memberResponse?.TotalItems ?? throw new InvalidOperationException("Response required");
	}

	public async ValueTask<Member?> GetMemberAsync(
		string audienceId,
		string emailAddressOrHash,
		CancellationToken cancellationToken = default)
	{
		try
		{
			var response = await httpClient.GetAsync(
				$"lists/{audienceId}/members/{GetSubscriberHash(emailAddressOrHash)}",
				cancellationToken
			);
			await EnsureMailChimpSuccessAsync(response, cancellationToken);

			var member = await response.Content.ReadFromJsonAsync<Member>(
				Options, cancellationToken
			);
			
			return member;
		}
		catch (MailChimpException mex) when (mex.Status == 404)
		{
			return null;
		}
	}

	public async ValueTask DeleteMemberAsync(
		string audienceId,
		string emailAddressOrHash,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.DeleteAsync(
			$"lists/{audienceId}/members/{GetSubscriberHash(emailAddressOrHash)}",
			cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}

	public async ValueTask PermanentDeleteMemberAsync(
		string audienceId,
		string emailAddressOrHash,
		CancellationToken cancellationToken = default)
	{
		var response = await httpClient.PostAsync(
			$"lists/{audienceId}/members/{GetSubscriberHash(emailAddressOrHash)}/actions/delete-permanent", content: null,
			cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}

	#region Member Tags

	public async ValueTask UpdateMemberTagsAsync(
		string listId,
		string emailAddressOrHash,
		Tags tags,
		CancellationToken cancellationToken = default)
	{
		// NOTE: bit different from most other object types, as MC API supports a single POST that will handle
		// .. add or update as appropriate - we have to generate an Id for the member
		// .. doubly weird as same effect with a PUT above, but here its a POST!
		var response = await httpClient.PostAsJsonAsync(
			$"lists/{listId}/members/{GetSubscriberHash(emailAddressOrHash)}/tags", tags,
			Options, cancellationToken
		);
		await EnsureMailChimpSuccessAsync(response, cancellationToken);
	}

	#endregion

	#region Internal Implementation

	private static string GetSubscriberHash(string emailAddressOrHash)
	{
		if (!emailAddressOrHash.Contains('@', StringComparison.Ordinal))
			return emailAddressOrHash; //this is hashed already

#pragma warning disable CA5351
		using (var md5 = MD5.Create())
			return GetHash(md5, emailAddressOrHash.ToLower());
#pragma warning restore CA5351

		//

		static string GetHash(HashAlgorithm md5Hash, string input)
		{
			// Convert the input string to a byte array and compute the hash.
			var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
			var builder = new StringBuilder();
			foreach (var t in data)
			{
				builder.Append(t.ToString("x2"));
			}

			return builder.ToString();
		}
	}

	#endregion
}
