
using System;
using System.ComponentModel;

namespace Ticketing.Integrations.AsynchronousIntegrations.Crm.Mailchimp.Api
{
    /// <summary>
    /// Sort order for sort_dir
    /// </summary>
    [Flags]
    public enum MemberSortOrder
    {
        /// <summary>
        /// ASC
        /// </summary>
        [Description("ASC")]
        ASC = 1,
        /// <summary>
        /// ASC
        /// </summary>
        [Description("DESC")]
        DESC = 2
    }

}
