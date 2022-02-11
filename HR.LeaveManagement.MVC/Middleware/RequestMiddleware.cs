using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILocalStorageService _localStorageService;

        public RequestMiddleware(RequestDelegate next, ILocalStorageService localStorageService)
        {
            _next = next;
            _localStorageService = localStorageService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
                var authAttribute = endpoint?.Metadata?.GetMetadata<AuthorizeAttribute>();
                if (authAttribute != null)
                {
                    var tokenExists = _localStorageService.Exists("token");
                    var tokenIsValid = true;
                    if (tokenExists)
                    {
                        var token = _localStorageService.GetStorageValue<string>("token");
                        JwtSecurityTokenHandler tokenHandler = new();
                        var tokenContent = tokenHandler.ReadJwtToken(token);
                        var expiry = tokenContent.ValidTo;
                        if (expiry < DateTime.Now)
                        {
                            tokenIsValid = false;
                        }
                    }

                    if (!tokenIsValid || !tokenExists)
                    {
                        await SignOutAndRedirect(context);
                    }

                    if (authAttribute.Roles.Contains("Administrator") && context.User.IsInRole("Administrator") == false)
                    {
                        var path = $"/home/notauthorized";
                        context.Response.Redirect(path);
                        return;
                    }
                }
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            switch (exception)
            {
                case ApiException apiException:
                    await SignOutAndRedirect(context);
                    break;
                default:
                    var path = $"/Home/Error";
                    context.Response.Redirect(path);
                    break;
            }
        }

        private async Task SignOutAndRedirect(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var path = $"/users/login";
            context.Response.Redirect(path);
        }
    }
}
