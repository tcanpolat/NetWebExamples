﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _15_Filter_Operation.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Burada basit bir kullanıcı login oldu mu kontrolü yapabiliriz.

            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                // eğer kullanıcı login olmadıysa login sayfasına yönlendir.
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
