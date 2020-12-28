using System.Collections.Generic;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a category in the application
    /// </summary>
    public class Category : BaseEntity
    {
        public Category()
        {
            ItemImages = new List<ItemImage>();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the English name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// Gets or sets the Arabic name
        /// </summary>
        public string ArabicName { get; set; }

        #endregion

        /// <summary>
        /// The images that are related to the current category
        /// </summary>
        public virtual ICollection<ItemImage> ItemImages { get; set; }
    }
}
