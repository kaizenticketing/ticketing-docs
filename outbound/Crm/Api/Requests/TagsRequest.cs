using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api
{
    public class TagsRequest : BaseQueryableRequest
    {
        [QueryString("list_id")]
        public string ListId { get; set; } = default!;
    }
}
