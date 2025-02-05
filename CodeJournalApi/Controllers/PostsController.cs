using Microsoft.AspNetCore.Mvc;
using CodeJournalApi.Data.Services;
using CodeJournalApi.DTOs;

namespace CodeJournalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase 
    {
        private IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            IEnumerable<PostDTO> posts = await _postService.GetAllPosts();
            var returnValue = new { status = "success", posts };
            return Ok(returnValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            PostDTO post = await _postService.GetPostById(id);
            var returnValue = new { status = "success", post };
            return Ok(returnValue);
        }
    }
}