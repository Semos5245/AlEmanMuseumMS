using ALEmanMuseum.Core.Infrastructure;
using ALEmanMuseum.Services.Addresses;
using ALEmanMuseum.Services.Categories;
using ALEmanMuseum.Services.CheckoutItems;
using ALEmanMuseum.Services.Checkouts;
using ALEmanMuseum.Services.Common;
using ALEmanMuseum.Services.Countries;
using ALEmanMuseum.Services.Customers;
using ALEmanMuseum.Services.Favorites;
using ALEmanMuseum.Services.ItemImages;
using ALEmanMuseum.Services.Items;
using ALEmanMuseum.Services.RentItems;
using ALEmanMuseum.Services.Rents;
using ALEmanMuseum.Services.SearchTerms;
using ALEmanMuseum.Services.SliderImages;
using ALEmanMuseum.Services.Sliders;
using ALEmanMuseum.Services.UserActivities;
using ALEmanMuseum.Web.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ALEmanMuseum.Web.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add the application services
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ISliderImageService, SliderImageService>();
            services.AddScoped<ISearchTermService, SearchTermService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<ICheckoutItemService, CheckoutItemService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IItemImageService, ItemImageService>();
            services.AddScoped<IRentService, RentService>();
            services.AddScoped<IRentItemService, RentItemService>();
            services.AddScoped<IUserActivityService, UserActivityService>();
            //services.AddScoped<IBarcodeProvider, BarcodeProvider>();
            
            return services;
        }

        public static IServiceCollection RegisterCommonHelpers(this IServiceCollection services)
        {
            services.AddScoped<IWebHostHelper, WebHostHelper>();

            return services;
        }
    }
}
