using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SuggestionAppLibrary.DataAccess;

namespace SuggestionWebApplication
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMemoryCache();

            services.AddSingleton<IDbconnection, Dbconnection>();
            services.AddSingleton<ICategoryData, MongoCategoryData>();
            services.AddSingleton<ISuggestionData, MongoSuggestionData>();
            services.AddSingleton<IStatusData, MongoStatusData>();
            services.AddSingleton<IUserData, MongoUserData>();

        }
    }
}
