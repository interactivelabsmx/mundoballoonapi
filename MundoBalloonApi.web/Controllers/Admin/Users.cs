﻿using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateProfile([FromBody] CreateUserProfileRequest userProfileRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = _service.Create(userProfileRequest);
            return new ObjectResult(user);
        }
    }
}
