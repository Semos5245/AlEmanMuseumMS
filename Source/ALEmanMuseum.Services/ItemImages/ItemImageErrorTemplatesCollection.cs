using System.Collections.Generic;

namespace ALEmanMuseum.Services.ItemImages
{
    public abstract class ItemImageErrorTemplatesCollection
    {
        private static readonly Dictionary<ItemImageErrors, string> MErrorTemplates
            = new Dictionary<ItemImageErrors, string>
            {
                {ItemImageErrors.ImageNotFound ,"Image does not exist" },
                {ItemImageErrors.CategoryNotFound ,"Category does not exist" },
                {ItemImageErrors.NotSupportedExtension ,"Extension not supported" },
                {ItemImageErrors.FileTooLarge ,"File too large" },
                {ItemImageErrors.ItemNotFound ,"Item not Found" },
                {ItemImageErrors.ImageAlreadyAttachedToCategory ,"Image already attached to category" },
                {ItemImageErrors.NoFileUploaded ,"No file has been uploaded" },
                {ItemImageErrors.DatabaseError ,"Operation failed" }
            };

        public static string GetTempaletForError(ItemImageErrors itemImageError)
            => MErrorTemplates.GetValueOrDefault(itemImageError);
    }
}
