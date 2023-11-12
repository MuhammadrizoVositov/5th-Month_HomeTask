using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N71BlogPost.Application.Services;
using N71BlogPost.Domain.Entity;

namespace N71BlogPost.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
          return Ok(_userService.Get());
        }
        [HttpPost]
        public IActionResult Create([FromBody] User user) 
        {
            return Ok(_userService.CreateAsync(user));
        }

    }
}
