using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N71BlogPost.Application.Services;
using N71BlogPost.Domain.Entity;

namespace N71BlogPost.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_commentService.Get());
        [HttpGet("{id:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
        {
            var a = await _commentService.GetByIdAsync(id);
            return Ok(a);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Comment cm) => Ok(_commentService.CreateAsync(cm));

    }
}
