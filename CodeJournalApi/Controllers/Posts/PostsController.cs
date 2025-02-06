using Microsoft.AspNetCore.Mvc;
using CodeJournalApi.Services;
using CodeJournalApi.DTOs;
using CodeJournalApi.Entities;

namespace CodeJournalApi.Controllers.Posts
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

        [HttpPut]
        public async Task<IActionResult> InsertPost([FromBody] PostDTO postDto)
        {
            await _postService.InsertPost(postDto);
            return Ok(new { status = "success", message = "Post Created"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePost(id);
            return Ok(new { status = "success", message = "Post Delete"});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostDTO postDto)
        {
            await _postService.UpdatePost(id, postDto);
            return Ok(new { message = "Post Updated"});
        }
    }
}