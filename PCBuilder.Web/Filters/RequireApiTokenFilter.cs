using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PCBuilder.Web.Filters;

public sealed class RequireApiTokenFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var endpoint = context.HttpContext.GetEndpoint();
        var allowAnonymous = endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null;
        if (allowAnonymous)
        {
            await next();
            return;
        }

        if (context.HttpContext.User.Identity?.IsAuthenticated == true)
        {
            var token = context.HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrWhiteSpace(token))
            {
                context.HttpContext.Session.Clear();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }
        }

        await next();
    }
}
