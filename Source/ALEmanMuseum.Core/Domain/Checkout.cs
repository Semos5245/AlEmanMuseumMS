using ALEmanMuseum.Core.Enums;
using System.Collections.Generic;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a checkout in the application
    /// </summary>
    public class Checkout : BaseEntity
    {
        public Checkout()
        {
            CheckoutItems = new List<CheckoutItem>();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the customer name
        /// Used for when a checkout is to be added without
        /// the customer being registered in the system
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the customer phone
        /// Used for when a checkout is to be added without
        /// the customer being registered in the system
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// The checkout status id value
        /// </summary>
        public int CheckoutStatusId { get; set; } = (int)CheckoutStatus.Processing;

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int? CustomerId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related customer (if existed)
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Navigation Property to the checkout items
        /// </summary>
        public virtual ICollection<CheckoutItem> CheckoutItems { get; set; }

        #endregion
    }
}
