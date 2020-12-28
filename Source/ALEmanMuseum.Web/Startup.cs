using ALEmanMuseum.Core.Domain;
using ALEmanMuseum.Data;
using ALEmanMuseum.Web.ExtensionMethods;
using ALEmanMuseum.Web.Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace ALEmanMuseum.Web
{
    /// <summary>
    /// Represents the startup of the application for configuring application services
    /// and request pip-line
    /// </summary>
    public class Startup
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="configuration">Application configuration</param>
        public Startup(IConfiguration configuration)
        {
            // Set the configuration
            Configuration = configuration;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The Configuration object to be used for gets application configuration data
        /// </summary>
        public IConfiguration Configuration { get; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Configures the application services
        /// </summary>
        /// <param name="services">the services container to be used</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add application controllers and their related views
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling 
                        = ReferenceLoopHandling.Ignore)
                .AddRazorRuntimeCompilation()
                .AddDataAnnotationsLocalization();

            // Add the application DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                        op => op.MigrationsAssembly("ALEmanMuseum.Web"));
            });

            // Add identity services for using built-in helper classes like (SignInManager...etc)
            services.AddIdentity<SystemUser, IdentityRole>()
                // Bind the identity with the application's DbContext
                .AddEntityFrameworkStores<ApplicationDbContext>()
                // Add default token provides
                .AddDefaultTokenProviders();

            services.AddScoped<IViewLocalizer, ViewLocalizer>();
            services.AddScoped<IHtmlLocalizerFactory, HtmlLocalizerFactory>();
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });

            services.AddCors(builder =>
            {
                builder.AddPolicy("defaultCorsPolicy",
                    options =>
                    {
                        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build();
                    });
            });

            services.AddHttpsRedirection(opts => {
                opts.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                opts.HttpsPort = 44300;
            });

            // Add application helpers
            services.RegisterCommonHelpers();

            // Add application services for being injected later when needed
            services.AddApplicationServices();
        }

        /// <summary>
        /// Configures the request pip-line
        /// </summary>
        /// <param name="app">Application builder to be used for configuration</param>
        /// <param name="env">Environment we are currently in</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // If we are in development mode
            if (env.IsDevelopment())
            {
                // Use the default exception page in case of any errors and exceptions for debugging
                app.UseDeveloperExceptionPage();

            }
            // Else we are in other modes like (Production, Staging... etc)
            else
            {
                // Use the default exception handler to redirect to the specified page
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"));
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("ar") };
                options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("ar") };

                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new CookieRequestCultureProvider()
                };
            });

            // Redirection
            app.UseHttpsRedirection();

            // Serve static files like plain html files.. images.. etc
            app.UseStaticFiles();

            // use authentication (signed in.. )
            app.UseAuthentication();

            // Routing
            app.UseRouting();

            // User cors
            app.UseCors("defaultCorsPolicy");

            // Use authorization (roles, claims, policies..)
            app.UseAuthorization();

            // Configure endpoints mapping to map requests to specific action inside controllers..
            app.UseEndpoints(endpoints =>
            {
                // Map the Cms area for admin website
                endpoints.MapControllerRoute(
                // Area name
                name: AreaNames.Cms,
                // Pattern to match 
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                // Map default request
                endpoints.MapControllerRoute(
                // Pattern name
                name: "default",
                // Pattern (template)
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #endregion
    }
}
