namespace ALEmanMuseum.Core.Infrastructure
{
    public interface IWebHostHelper
    {
        string WebRootPath { get; }
        string ContentRootPath { get; }
        string ItemsImagesPath { get; }
        string BarcodesImagesPath { get; }
        string SlidersImagesPath { get; }
        string ItemsThumbnailImagesPath { get; }
    }
}
