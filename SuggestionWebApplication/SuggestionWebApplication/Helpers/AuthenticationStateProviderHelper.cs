using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using SuggestionAppLibrary.DataAccess;
using SuggestionAppLibrary.Models;

namespace SuggestionWebApplication.Helpers
{
    public static class AuthenticationStateProviderHelper
    {
        public static async Task<UserModel> GetUserFromAuth(
            this AuthenticationStateProvider authProvider, IUserData userData)
        {
            var authState = await authProvider.GetAuthenticationStateAsync();
            string objectId = authState.User.Claims.FirstOrDefault(x => x.Type.Contains("objectidentifier"))?.Value;
            return await userData.GetUserFromAuthentication(objectId);

        }
    }
}
