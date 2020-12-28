using System;
using enums = ALEmanMuseum.Core.Enums;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents an action done by a user in the application
    /// </summary>
    public class UserActivity : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the action identifier
        /// </summary>
        public int ActionId { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the related entity
        /// </summary>
        public int RelatedEntityId { get; set; }

        #endregion
    }
}
