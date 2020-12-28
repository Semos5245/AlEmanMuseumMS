using System;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a notification in the application
    /// </summary>
    public class Notification : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Arabic title
        /// </summary>
        public string ArabicTitle { get; set; }

        /// <summary>
        /// Gets or sets the English title
        /// </summary>
        public string EnglishTitle { get; set; }

        /// <summary>
        /// Gets or sets the URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the received flag
        /// </summary>
        public bool Received { get; set; }

        /// <summary>
        /// Gets or sets the opened flag
        /// </summary>
        public bool Opened { get; set; }

        /// <summary>
        /// Gets or sets the notification date
        /// </summary>
        public DateTime NotificationDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the only for admin flag
        /// </summary>
        public bool OnlyForAdmin { get; set; }

        #endregion
    }
}
