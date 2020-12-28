
namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents the favorite data in the system
    /// </summary>
    public class Favorite : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the item identifier
        /// </summary>
        public int ItemId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related customer
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Navigation Property to the related item
        /// </summary>
        public virtual Item Item { get; set; }

        #endregion
    }
}
