
namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a search term in the application
    /// </summary>
    public class SearchTerm : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the term
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int Count { get; set; } = 1;

        #endregion
    }
}
