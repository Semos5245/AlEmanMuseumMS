using ALEmanMuseum.Core.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ALEmanMuseum.Web.Infrastructure
{
    public class WebHostHelper : IWebHostHelper
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WebHostHelper(IWebHostEnvironment webHostEnvironment)
        {
            WebRootPath = webHostEnvironment.WebRootPath;
            ContentRootPath = webHostEnvironment.ContentRootPath;
            ItemsImagesPath = Path.Combine(WebRootPath, "images", "items");
            BarcodesImagesPath = Path.Combine(WebRootPath, "images", "barcodes");
            SlidersImagesPath = Path.Combine(WebRootPath, "images", "sliders");
            ItemsThumbnailImagesPath = Path.Combine(WebRootPath, "images", "thumbs");
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The Path to the root of the current project
        /// </summary>
        public string WebRootPath { get; }

        /// <summary>
        /// The content root path to the current project
        /// </summary>
        public string ContentRootPath { get; }

        /// <summary>
        /// The path to the items images folder
        /// </summary>
        public string ItemsImagesPath { get; }

        /// <summary>
        /// The path to the items thumbnail images folder
        /// </summary>
        public string ItemsThumbnailImagesPath { get; }

        /// <summary>
        /// The path to the barcodes images folder
        /// </summary>
        public string BarcodesImagesPath { get; }

        /// <summary>
        /// The path to the barcodes images folder
        /// </summary>
        public string SlidersImagesPath { get; }

        #endregion
    }
}
