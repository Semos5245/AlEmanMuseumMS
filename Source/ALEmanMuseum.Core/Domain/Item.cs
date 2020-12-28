
namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents an item in the application
    /// </summary>
    public class Item : BaseEntity
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Item()
        {
            Guid = System.Guid.NewGuid().ToString().Substring(0, 9);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the guid
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// The sequential unique item number
        /// </summary>
        public int UniqueNumber { get; set; }

        /// <summary>
        /// Gets or sets the English name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// Gets or sets the Arabic name
        /// </summary>
        public string ArabicName { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// Gets or sets the English description
        /// </summary>
        public string EnglishDescription { get; set; }

        /// <summary>
        /// Gets or sets the Arabic description
        /// </summary>
        public string ArabicDescription { get; set; }

        /// <summary>
        /// The original price of the item
        /// </summary>
        public decimal OriginalPrice { get; set; }

        /// <summary>
        /// The Selling price of the item
        /// </summary>
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// The bar-code image path of the item
        /// </summary>
        public string BarcodeImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the available flag
        /// </summary>
        public bool Available => Quantity > 0;

        /// <summary>
        /// Gets or sets the hidden flag
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Gets or sets the views
        /// </summary>
        public int Views { get; set; } = 0;

        /// <summary>
        /// Gets or sets the tags
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the related category identifier
        /// </summary>
        public int CategoryId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related category
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Navigation Property to the related item images
        /// </summary>
        public virtual ItemImage ItemImage { get; set; }

        #endregion
    }
}
