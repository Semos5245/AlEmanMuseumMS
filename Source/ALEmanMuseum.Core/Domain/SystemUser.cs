using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ALEmanMuseum.Core.Domain
{
    public class SystemUser : IdentityUser
    {
        public SystemUser()
        {
            UserActivities = new List<UserActivity>();
        }

        /// <summary>
        /// Indicates whether the user is blocked or not
        /// </summary>
        public bool Blocked { get; set; }

        /// <summary>
        /// The last login date of the user
        /// </summary>
        public DateTime? LastLoginUtc { get; set; }

        /// <summary>
        /// Navigation property to the related user activities
        /// </summary>
        public virtual ICollection<UserActivity> UserActivities { get; set; }
    }
}
