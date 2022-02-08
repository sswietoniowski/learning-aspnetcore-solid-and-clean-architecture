using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Services
{
    public class AuthenticationService : BaseHttpService, Contracts.IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _tokenHandler;

        public AuthenticationService(IClient client, ILocalStorageService localStorage,
            IHttpContextAccessor httpContextAccessor) : base(client, localStorage)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authRequest = new()
                {
                    Email = email,
                    Password = password
                };

                var authResponse = await _client.LoginAsync(authRequest);

                if (authResponse?.Token != String.Empty)
                {
                    var tokenContent = _tokenHandler.ReadJwtToken(authResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    _localStorage.SetStorageValue("token", authResponse.Token);

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Logout()
        {
            try
            {
                _localStorage.ClearStorage(new List<string> { "token" });
                await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
        {
            try
            {
                RegistrationRequest registrationRequest = new()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = userName,
                    Email = email,
                    Password = password
                };

                var response = await _client.RegisterAsync(registrationRequest);

                if (!string.IsNullOrEmpty(response?.UserId))
                {
                    await Authenticate(registrationRequest.Email, registrationRequest.Password);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
