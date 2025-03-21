using Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api.Models;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api;

public interface IMailchimpClient
{
	// audiences
	ValueTask<Audience> AddOrUpdateAsync(Audience audience, CancellationToken cancellationToken = default);
	ValueTask<IEnumerable<Audience>> GetAllAudiencesAsync(AudienceRequest? request = null, CancellationToken cancellationToken = default);
	ValueTask<Audience?> GetAudienceAsync(string id, CancellationToken cancellationToken = default);
	ValueTask DeleteAudienceAsync(string audienceId, CancellationToken cancellationToken = default);

	// merge fields
	ValueTask<MergeField> AddOrUpdateAsync(string audienceId, MergeField mergeField, CancellationToken cancellationToken = default);
	ValueTask<IEnumerable<MergeField>> GetAllMergeFieldsAsync(string audienceId, MergeFieldRequest? request = null, CancellationToken cancellationToken = default);
	ValueTask<MergeField?> GetMergeFieldAsync(string audienceId, int id, CancellationToken cancellationToken = default);
	ValueTask DeleteMergeFieldAsync(string audienceId, int mergeId, CancellationToken cancellationToken = default);

	// interest group categories
	ValueTask<GroupCategory> AddOrUpdateAsync(string audienceId, GroupCategory category, CancellationToken cancellationToken = default);
	ValueTask<IEnumerable<GroupCategory>> GetAllGroupCategoriesAsync(string audienceId, GroupCategoryRequest? request = null, CancellationToken cancellationToken = default);
	ValueTask<GroupCategory?> GetGroupCategoryAsync(string audienceId, string id, CancellationToken cancellationToken = default);
	ValueTask DeleteGroupCategoryAsync(string audienceId, string id, CancellationToken cancellationToken = default);

	// stores
	// NOTE: can't do AddOrUpdateAsync as WE SUPPLY THE ID
	ValueTask<Store> AddAsync(Store store, CancellationToken cancellationToken = default);
	ValueTask<Store> UpdateAsync(Store store, CancellationToken cancellationToken = default);
	ValueTask<IEnumerable<Store>> GetAllStoresAsync(BaseQueryableRequest? request = null, CancellationToken cancellationToken = default);
	ValueTask<Store?> GetStoreAsync(string id, CancellationToken cancellationToken = default);
	ValueTask DeleteStoreAsync(string id, CancellationToken cancellationToken = default);

	// interest groups
	ValueTask<Group> AddOrUpdateAsync(string audienceId, string interestCategoryId, Group interest, CancellationToken cancellationToken = default);
	ValueTask<IEnumerable<Group>> GetAllGroupsAsync(string audienceId, string interestCategoryId, BaseQueryableRequest? request = null, CancellationToken cancellationToken = default);
	ValueTask<Group?> GetGroupAsync(string audienceId, string interestCategoryId, string id, CancellationToken cancellationToken = default);
	ValueTask DeleteGroupAsync(string audienceId, string interestCategoryId, string id, CancellationToken cancellationToken = default);

	// members (+tags)
	ValueTask<Member> AddOrUpdateAsync(string audienceId, Member member, CancellationToken cancellationToken = default);
	ValueTask UpdateMemberTagsAsync(string audienceId, string emailAddressOrHash, Tags tags, CancellationToken cancellationToken = default);
	ValueTask<int> GetMemberCountAsync(string audienceId, MemberStatus? status, CancellationToken cancellationToken = default);
	ValueTask<Member?> GetMemberAsync(string audienceId, string emailAddressOrHash, CancellationToken cancellationToken = default);
	ValueTask DeleteMemberAsync(string audienceId, string emailAddressOrHash, CancellationToken cancellationToken = default);
	ValueTask PermanentDeleteMemberAsync(string audienceId, string emailAddressOrHash, CancellationToken cancellationToken = default);

	// campaigns
	ValueTask<Campaign> AddOrUpdateAsync(Campaign campaign, CancellationToken cancellationToken = default);
	ValueTask<IEnumerable<Campaign>> GetAllCampaignsAsync(CampaignRequest? request = null, CancellationToken cancellationToken = default);
	ValueTask<Campaign?> GetCampaignAsync(string id, CancellationToken cancellationToken = default);
	ValueTask DeleteCampaignAsync(string id, CancellationToken cancellationToken = default);

	// products
	// NOTE: can't do AddOrUpdateAsync as WE SUPPLY THE ID
	// ValueTask<Product> AddAsync(string storeId, Product product, CancellationToken cancellationToken = default);
	ValueTask<Product> CreateOrUpdateAsync(string storeId, Product mcProduct, CancellationToken cancellationToken = default);
	ValueTask<IEnumerable<Product>> GetAllProductsAsync(string storeId, BaseQueryableRequest? request = null, CancellationToken cancellationToken = default);
	ValueTask<Product?> GetProductByIdAsync(string storeId, string id, CancellationToken cancellationToken = default);
	// ValueTask<Product> UpdateAsync(string storeId, Product product, CancellationToken cancellationToken = default);
	ValueTask DeleteProductAsync(string storeId, string id, CancellationToken cancellationToken = default);

	// carts
	ValueTask<Cart> AddAsync(string storeId, Cart cart, CancellationToken cancellationToken = default);
	ValueTask<Cart?> GetCartAsync(string storeId, string id, CancellationToken cancellationToken = default);
	ValueTask<Cart> UpdateAsync(string storeId, Cart cart, CancellationToken cancellationToken = default);
	ValueTask DeleteCartAsync(string storeId, string id, CancellationToken cancellationToken = default);

	// orders
	// ValueTask<Order> AddAsync(string storeId, Order order, CancellationToken cancellationToken = default);
	ValueTask<Order> AddOrUpdateAsync(string storeId, Order mcOrder, CancellationToken cancellationToken = default);
	ValueTask<Order?> GetOrderAsync(string storeId, string id, CancellationToken cancellationToken = default);
	// ValueTask<Order> UpdateAsync(string storeId, Order order, CancellationToken cancellationToken = default);
	ValueTask DeleteOrderAsync(string storeId, string id, CancellationToken cancellationToken = default);
}
