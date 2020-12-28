namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents an address data in the system
    /// </summary>
    public class Address : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the area 
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the building name
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// Gets or sets the floor
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related customer
        /// </summary>
        public virtual Customer Customer { get; set; }

        #endregion
    }
}
