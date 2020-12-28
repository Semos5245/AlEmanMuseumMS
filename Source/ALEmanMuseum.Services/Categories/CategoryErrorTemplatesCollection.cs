using ALEmanMuseum.Core.Domain;
using System.Collections.Generic;

namespace ALEmanMuseum.Services.Categories
{
    public abstract class CategoryErrorTemplatesCollection
    {
        protected static Dictionary<CategoryErrors, string> MErrorTemplates
            = new Dictionary<CategoryErrors, string>
            {
                { CategoryErrors.CategoryNotExist, "Category does not exist" },
                { CategoryErrors.CategoryAlreadExist, "Category already exist" },
                { CategoryErrors.DatabaseError, "Operation failed" },
            };

        public static string GetTemplateForError(CategoryErrors categoryError)
            => MErrorTemplates.GetValueOrDefault(categoryError);
    }
}
