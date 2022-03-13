using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SuggestionWebApplication
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMemoryCache();

        }
    }
}
