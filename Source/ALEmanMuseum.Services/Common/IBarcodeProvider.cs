using System.Drawing;

namespace ALEmanMuseum.Services.Common
{
    public interface IBarcodeProvider
    {
        /// <summary>
        /// Creates a barcode
        /// </summary>
        /// <param name="content">Content to create the barcode for</param>
        /// <param name="path">Path to save the barcode image to</param>
        /// <returns>True if operation succeeded, false ortherwise</returns>
        bool CreateBarcodeAndSaveTo(string content, string path);
    }
}
