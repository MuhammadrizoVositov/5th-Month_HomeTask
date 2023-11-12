using Microsoft.AspNetCore.Mvc;
using N71BlogPost.Application.Services;
using N71BlogPost.Domain.Entity;

namespace N71BlogPost.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_blogService.Get());
    [HttpPost]
    public IActionResult Create([FromBody] Blog blog) => Ok(_blogService.CreateAsync(blog));

}
