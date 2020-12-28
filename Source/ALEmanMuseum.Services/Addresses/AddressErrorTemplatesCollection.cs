using System.Collections.Generic;

namespace ALEmanMuseum.Services.Addresses
{
    public abstract class AddressErrorTemplatesCollection
    {
        private static readonly Dictionary<AddressErrors, string> MAddressErrorTemplates
            = new Dictionary<AddressErrors, string>
            {
                { AddressErrors.AddressNotExist, "Address does not exist" },
                { AddressErrors.AddressNotExist, "Address already exist" },
                { AddressErrors.DatabaseError, "Operation failed" }
            };

        public static string GetTemplateForError(AddressErrors addressError)
        {
            return MAddressErrorTemplates.GetValueOrDefault(addressError);
        }
    }
}
