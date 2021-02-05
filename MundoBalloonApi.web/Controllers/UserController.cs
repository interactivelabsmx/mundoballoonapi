using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MundoBalloonApi.web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
