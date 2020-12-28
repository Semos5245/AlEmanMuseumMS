using System.Collections.Generic;

namespace ALEmanMuseum.Services.SearchTerms
{
    public abstract class SearchTermErrorTemplatesCollection
    {
        private static readonly Dictionary<SearchTermErrors, string> MErrorTemplates
            = new Dictionary<SearchTermErrors, string>
            { 
                { SearchTermErrors.TermNotExist, "Term does not exist" },
                { SearchTermErrors.DatabaseError, "Operation failed"},
            };

        public static string GetTemplateForError(SearchTermErrors searchTermError)
            => MErrorTemplates.GetValueOrDefault(searchTermError);
    }
}
