using System.Collections.Generic;

namespace ALEmanMuseum.Services.Items
{
    public abstract class ItemErrorTemplatesCollection
    {
        private static readonly Dictionary<ItemErrors, string> MErrorTemplates
            = new Dictionary<ItemErrors, string>
            {
                { ItemErrors.ItemNotExist, "Item does not exist"},
                { ItemErrors.ItemAlreadyExist, "Item already exist"},
                { ItemErrors.BarcodeNotGenerated, "Error generating barcode"},
                { ItemErrors.CategoryNotExist, "Category does not exist"},
                { ItemErrors.NotSupportedExtension, "File extension is not supported"},
                { ItemErrors.ImageNotExist, "Image does not exist"},
                { ItemErrors.DatabaseError, "Operation failed"},
            };

        public static string GetTemplateForError(ItemErrors itemError)
            => MErrorTemplates.GetValueOrDefault(itemError);
    }
}
