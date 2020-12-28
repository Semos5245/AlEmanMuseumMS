using ALEmanMuseum.Core;
using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Core.ExensionMethods;
using ALEmanMuseum.Data.Mapping;
using ALEmanMuseum.Data.ModelConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ALEmanMuseum.Data
{
    /// <summary>
    /// Application Database context
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<SystemUser>
    {
        #region DbSets

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<CheckoutItem> CheckoutItems { get; set; }
        public DbSet<Country> Countries  { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentItem> RentItems { get; set; }
        public DbSet<RentNote> RentNotes { get; set; }
        public DbSet<SearchTerm> SearchTerms { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #endregion

        #region On Model Creating

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Add application sequences
            builder.HasSequence("OrderNumberSequence");
            builder.HasSequence("ItemNumberSequence");

            // Get all custom configuration types in the current assembly
            var customConfigurationTypes =
                //Get all types in the configuration
                Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                    // it's not a generic type or its base type is generic
                    (type.BaseType?.IsGenericType ?? false)
                    // its base type is generic and its's definition is our base mapper
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityMapper<>)));

            // Invoke each type to the current model builder
            foreach (var configType in customConfigurationTypes)
            {
                // Create an instance of the current configuration type
                // and apply its configuration
                ((ICustomModelConfiguration)Activator.CreateInstance(configType))
                    .ApplyCustomConfiguration(builder);
            }

            // Continue the flow of model creating
            base.OnModelCreating(builder);
        }

        #endregion

        #region Public Methods

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries().Where(entry => entry.State == EntityState.Modified)
                .ToList().ForEach(entry =>
                {
                    entry.Entity.As<BaseEntity>().LastModifiedDate = DateTime.UtcNow;
                });

            return base.SaveChangesAsync();
        }

        #endregion
    }
}
