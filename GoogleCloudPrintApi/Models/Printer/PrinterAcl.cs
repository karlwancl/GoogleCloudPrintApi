using GoogleCloudPrintApi.Models.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoogleCloudPrintApi.Models.Printer
{
    public class PrinterAcl
    {
        /// <summary>
        /// access level granted to the scope, can be one of the following (robot accounts are not exposed via this API): USER/ MANAGER/ OWNER
        /// </summary>
        [JsonProperty]
        public Role Role { get; private set; }

        /// <summary>
        /// id of the scope (user or group email or domain) to which access rights are granted
        /// </summary>
        [JsonProperty]
        public string Scope { get; private set; }

        /// <summary>
        /// scope display name (can be empty)
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; }

        /// <summary>
        /// entry type, can be one of the following: USER/ GROUP/ DOMAIN
        /// </summary>
        [JsonProperty]
        public EntryType Type { get; private set; }

        /// <summary>
        /// rights the logged-in user is granted with within this entry. Note that these rights have nothing to do with the printer access; they indicate what the logged-in user can do with this entry. Only a MANAGER can remove the entry from printer's ACL. Can be one of the following: NONE/ MEMBER/ MANAGER
        /// </summary>
        [JsonProperty]
        public MembershipType Membership { get; private set; }

        /// <summary>
        /// set to true when the scope owner this printer was shared with has not accepted the invitation yet. Optional, omitted when set to false.
        /// </summary>
        [JsonProperty]
        public bool IsPending { get; private set; }
    }
}
