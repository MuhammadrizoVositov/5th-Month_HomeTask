using HomeTask.Application;
using HomeTask.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeTask.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
public UserController(IUserService userService)
    {
        this.userService = userService;
    }
    [HttpGet]
    public IActionResult GetAll() => Ok(userService.Get(user => true));
    [HttpGet("{id:}")]
    public IActionResult GetById([FromRoute] Guid id) => Ok(userService.Get(user => true));


    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
        return Ok(userService.CreateAsync(user, true));
    }

    [HttpPut]
    public IActionResult Update([FromBody] User user)
    {
        return Ok(userService.UpdateAsync(user));
    }
    [HttpDelete]
    public IActionResult Delete([FromBody] User user)
    {
        return Ok(userService.DeleteAsync(user));
    }
}
