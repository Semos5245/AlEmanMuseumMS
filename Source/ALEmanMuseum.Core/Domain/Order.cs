using System;
using ALEmanMuseum.Core.Enums;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents an order in the system
    /// </summary>
    public class Order : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the order number
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the order status identifier
        /// </summary>
        public int OrderStatusId { get; set; }

        /// <summary>
        /// Gets or sets the address identifier
        /// </summary>
        public int? AddressId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart identifier
        /// </summary>
        public int ShoppingCartId { get; set; }

        /// <summary>
        /// Gets or set the order status
        /// </summary>
        public OrderStatus OrderStatus
        {
            get => (OrderStatus)OrderStatusId;
            set => OrderStatusId = (int)value;
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related customer
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Navigation Property for the related shopping cart
        /// </summary>
        public virtual ShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// Navigation Property to the related address
        /// </summary>
        public virtual Address Address { get; set; }

        #endregion
    }
}
