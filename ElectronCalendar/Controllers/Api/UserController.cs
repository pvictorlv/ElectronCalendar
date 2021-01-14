using System;
using System.Threading.Tasks;
using ElectronCalendar.Database.Services;
using ElectronCalendar.Shared.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronCalendar.Controllers.Api
{
    [ApiController, Route("api/[controller]"), Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(LoginRequest loginRequest)
        {
            var session = await _userService.Login(loginRequest.Username, loginRequest.Password);
            if (session == null)
                return Unauthorized();
            
            var authenticationProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddDays(7),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, session,
                authenticationProperties);

            return Ok();
        }
    }
}