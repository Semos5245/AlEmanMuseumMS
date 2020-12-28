using System;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a shopping cart item in the application
    /// </summary>
    public class ShoppingCartItem : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the added date
        /// </summary>
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the shopping cart identifier
        /// </summary>
        public int ShoppingCartId { get; set; }

        /// <summary>
        /// Gets or sets the item identifier
        /// </summary>
        public int ItemId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related shopping cart
        /// </summary>
        public virtual ShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// Navigation Property to the related item
        /// </summary>
        public virtual Item Item { get; set; }

        #endregion
    }
}
