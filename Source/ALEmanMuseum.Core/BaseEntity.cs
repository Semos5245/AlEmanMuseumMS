using ALEmanMuseum.Core.Domain;
using System;

namespace ALEmanMuseum.Core
{
    /// <summary>
    /// Represents the base class of all domain entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created date
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the last modified date
        /// </summary>
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indicates whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// The identifier of the user who created or lastly modified the current entity
        /// </summary>
        public string CreatorModifierId { get; set; }

        #endregion

        /// <summary>
        /// Navigation property to the related user
        /// </summary>
        public virtual SystemUser CreatorModifier { get; set; }
    }
}
