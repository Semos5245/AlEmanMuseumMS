namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents an item image in the application
    /// </summary>
    public class ItemImage : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the image name
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail name
        /// </summary>
        public string ThumbNailUrl { get; set; }

        /// <summary>
        /// Gets or sets the item identifier
        /// </summary>
        public int? ItemId { get; set; }

        /// <summary>
        /// The identifier of the related category
        /// </summary>
        public int? CategoryId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property for the related item
        /// </summary>
        public virtual Item Item { get; set; }

        /// <summary>
        /// Navigation property to the related category
        /// </summary>
        public virtual Category Category { get; set; }

        #endregion
    }
}
