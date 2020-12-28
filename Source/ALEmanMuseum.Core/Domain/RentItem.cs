using ALEmanMuseum.Core.Enums;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a rent item data in the system
    /// </summary>
    public class RentItem : BaseEntity
    {
        #region Properties

        /// <summary>
        /// The quantity of the rented item
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the rent item status identifier
        /// </summary>
        public int RentItemStatusId { get; set; } = (int)RentItemStatus.NotYetReturned;

        /// <summary>
        /// Gets or sets the rent identifier
        /// </summary>
        public int RentId { get; set; }

        /// <summary>
        /// Gets or sets the item identifier
        /// </summary>
        public int ItemId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related rent
        /// </summary>
        public virtual Rent Rent { get; set; }

        /// <summary>
        /// Navigation Property to the related item
        /// </summary>
        public virtual Item Item { get; set; }

        #endregion
    }
}
