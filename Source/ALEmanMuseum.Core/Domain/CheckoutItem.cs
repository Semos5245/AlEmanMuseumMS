
namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a checkout item in the system
    /// </summary>
    public class CheckoutItem : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the prices
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the item identifier
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the checkout identifier
        /// </summary>
        public int CheckoutId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related item
        /// </summary>
        public virtual Item Item { get; set; }

        /// <summary>
        /// Navigation Property to the related checkout
        /// </summary>
        public virtual Checkout Checkout { get; set; }

        #endregion
    }
}
