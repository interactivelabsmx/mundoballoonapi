using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Requests;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.web.Controllers.Admin
{
    [Route("api/v1/admin/users")]
    public class UsersController : UserController
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json", Type = typeof(User))]
        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = _service.Create(createUserRequest);
            return new ObjectResult(user);
        }
    }
}