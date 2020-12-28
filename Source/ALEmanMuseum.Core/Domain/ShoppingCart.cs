using System;
using System.Collections.Generic;
using ALEmanMuseum.Core.Enums;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a shopping cart in the system
    /// </summary>
    public class ShoppingCart : BaseEntity
    {
        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the shopping cart status identifier
        /// </summary>
        public int ShoppingCartStatusId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart status
        /// </summary>
        public ShoppingCartStatus ShoppingCartStatus
        {
            get => (ShoppingCartStatus)ShoppingCartStatusId;
            set => ShoppingCartStatusId = (int)value;
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related customer
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Navigation property to the related shopping cart items
        /// </summary>
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        
        #endregion
    }
}
