using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SuggestionAppLibrary.DataAccess;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web.UI;

namespace SuggestionWebApplication
{
    public static class RegisterServices
    {
        
        public static void ConfigureServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
            services.AddMemoryCache();
            services.AddControllersWithViews().AddMicrosoftIdentityUI();

            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
               .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAdB2C"));

            services.AddAuthorization(options =>
            {
                options.AddPolicy(name: "Admin", policy =>
                 {
                     policy.RequireClaim(claimType: "jobTitle", allowedValues: "Admin");
                 });
            }
            );

            services.AddSingleton<IDbconnection, Dbconnection>();
            services.AddSingleton<ICategoryData, MongoCategoryData>();
            services.AddSingleton<ISuggestionData, MongoSuggestionData>();
            services.AddSingleton<IStatusData, MongoStatusData>();
            services.AddSingleton<IUserData, MongoUserData>();

        }
    }
}
