using System;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a slider image in the application
    /// </summary>
    public class SliderImage : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the image name
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or sets the added date
        /// </summary>
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the slider identifier
        /// </summary>
        public int SliderId { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related slider
        /// </summary>
        public virtual Slider Slider { get; set; }

        #endregion
    }
}
