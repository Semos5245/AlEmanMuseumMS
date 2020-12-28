using System;
using System.Collections.Generic;

namespace ALEmanMuseum.Core.Domain
{
    /// <summary>
    /// Represents a slider in the application
    /// </summary>
    public class Slider : BaseEntity
    {
        public Slider()
        {
            SliderImages = new List<SliderImage>();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the Arabic name 
        /// </summary>
        public string ArabicName { get; set; }

        /// <summary>
        /// Gets or sets the English name
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// Gets or sets the active flag
        /// </summary>
        public bool Active { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// Navigation Property to the related slider images
        /// </summary>
        public virtual ICollection<SliderImage> SliderImages { get; set; }

        #endregion
    }
}
