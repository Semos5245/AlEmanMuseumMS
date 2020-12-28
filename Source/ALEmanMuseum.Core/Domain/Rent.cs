using System;
using System.Collections.Generic;
using ALEmanMuseum.Core.Enums;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a rent data in the system
    /// </summary>
    public class Rent : BaseEntity
    {
        public Rent()
        {
            RentItems = new List<RentItem>();
            RentNotes = new List<RentNote>();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the rent date
        /// </summary>
        public DateTime RentDate { get; set; }

        /// <summary>
        /// Gets or sets the closed date
        /// </summary>
        public DateTime? ClosedDate { get; set; }

        /// <summary>
        /// Gets or sets the customer name
        /// Used for when a rent is to be added without
        /// the customer being registered in the system
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the customer phone
        /// Used for when a rent is to be added without
        /// the customer being registered in the system
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// Gets or sets the rent status identifier
        /// </summary>
        public int RentStatusId { get; set; } = (int)RentStatus.InProgress;

        /// <summary>
        /// Gets or set the customer identifier
        /// </summary>
        public int? CustomerId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related rent items
        /// </summary>
        public virtual ICollection<RentItem> RentItems { get; set; }

        /// <summary>
        /// Navigation Property to the related rent notes
        /// </summary>
        public virtual ICollection<RentNote> RentNotes { get; set; }

        /// <summary>
        /// Navigation Property to the related customer (if exists)
        /// </summary>
        public virtual Customer Customer { get; set; }

        #endregion
    }
}
