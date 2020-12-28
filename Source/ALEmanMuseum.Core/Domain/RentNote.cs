
namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a rent note data in the system
    /// </summary>
    public class RentNote : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the rent identifier
        /// </summary>
        public int RentId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related rent
        /// </summary>
        public virtual Rent Rent { get; set; }

        #endregion
    }
}
