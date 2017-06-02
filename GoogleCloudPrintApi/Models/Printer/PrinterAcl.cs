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
        public Role Role { get; set; }

        /// <summary>
        /// id of the scope (user or group email or domain) to which access rights are granted
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// scope display name (can be empty)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// entry type, can be one of the following: USER/ GROUP/ DOMAIN
        /// </summary>
        public EntryType Type { get; set; }

        /// <summary>
        /// rights the logged-in user is granted with within this entry. Note that these rights have nothing to do with the printer access; they indicate what the logged-in user can do with this entry. Only a MANAGER can remove the entry from printer's ACL. Can be one of the following: NONE/ MEMBER/ MANAGER
        /// </summary>
        public MembershipType Membership { get; set; }

        /// <summary>
        /// set to true when the scope owner this printer was shared with has not accepted the invitation yet. Optional, omitted when set to false.
        /// </summary>
        public bool IsPending { get; set; }

        /// <summary>
        /// Gets or sets the email. (By response)
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }
    }
}
