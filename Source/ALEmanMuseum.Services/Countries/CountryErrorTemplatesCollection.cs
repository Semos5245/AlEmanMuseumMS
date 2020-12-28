using System.Collections.Generic;

namespace ALEmanMuseum.Services.Countries
{
    public abstract class CountryErrorTemplatesCollection
    {
        protected static readonly Dictionary<CountryErrors, string> MCountryErrorTemplates

            = new Dictionary<CountryErrors, string>
            {
                { CountryErrors.CountryNotExist, "Country does not exist" },
                { CountryErrors.CountryAlreadyExist, "Country already exist" },
                { CountryErrors.DatabaseError, "Operation failed" }
            };

        public static string GetTemplateForError(CountryErrors countryError)
            => MCountryErrorTemplates.GetValueOrDefault(countryError);
    }
}
