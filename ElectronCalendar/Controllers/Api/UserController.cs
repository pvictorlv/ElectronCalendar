using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronCalendar.Controllers.Api
{
    [ApiController, Route("api/[controller]"), Authorize]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            
        }

        [AllowAnonymous]
        public IActionResult Authenticate()
        {
            return Ok();
        }
    }
}