using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace ALEmanMuseum.Web.ViewModels.Address
{
    public class AddressViewModel
    {
        public readonly  IStringLocalizer<AddressViewModel> mStringLocalizer;

        public AddressViewModel(string area, string buildingName, string street, string floor,
            IStringLocalizer<AddressViewModel> stringLocalizer = null)
            => (Area, BuildingName, Street, Floor, mStringLocalizer) 
            =  (area, buildingName, street,floor, stringLocalizer);

        public AddressViewModel(Core.Domain.Address address, IStringLocalizer<AddressViewModel> stringLocalizer = null)
            => (Area, BuildingName, Street, Floor, mStringLocalizer) 
            =  (address?.Area, address?.BuildingName, address?.Street, address?.Floor, stringLocalizer);
        
        /// <summary>
        /// Gets or sets the area 
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the building name
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// Gets or sets the floor
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        #region Public Methods

        public Core.Domain.Address ToAddressEntity()
        {
            return new Core.Domain.Address
            {
                Area = Area,
                BuildingName = BuildingName,
                Street = Street,
                Floor = Floor,
                CustomerId = CustomerId
            };
        }

        #endregion
    }
}
