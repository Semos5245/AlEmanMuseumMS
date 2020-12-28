using ALEmanMuseum.Web.ViewModels.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALEmanMuseum.Web.Areas.Cms.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public string CustomerName { get; }
        public DateTime? BirthDate { get; }
        public string Phone { get; }
        public string ProfilePicturePath { get; }
        public bool Blocked { get; }
        public string Gender { get; }
        public string Country { get; }
        public string Email { get; }
        public int RentsCount { get; }
        public int RentsDone { get; }
        public int ConfirmedCheckouts { get; }
        public AddressViewModel Address { get; }
        public IEnumerable<string> FavoriteItems { get; }

        public CustomerDetailsViewModel(
            string name, string phone, string email, string picturePath, string gender,
            DateTime birthDate, bool blocked, string country, int rentsCount, int rentsDone,
            int confirmedCheckouts, AddressViewModel address, IEnumerable<string> favorites) =>
            (CustomerName, Phone, Email, ProfilePicturePath, Gender,
                BirthDate, Blocked, Country, RentsCount, RentsDone,
                ConfirmedCheckouts, Address, FavoriteItems) =
            (name, phone, email, picturePath, gender, birthDate, blocked, country, rentsCount,
             rentsDone, confirmedCheckouts, address, favorites);
    }
}
