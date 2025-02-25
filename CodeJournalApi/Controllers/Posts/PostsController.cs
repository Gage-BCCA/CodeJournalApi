using Microsoft.AspNetCore.Mvc;
using CodeJournalApi.Services;
using CodeJournalApi.DTOs;

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

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPosts()
        {
            IEnumerable<PostSummaryDTO> postSummaries = await _postService.GetAllPosts();
            return Ok( new {status = "success", postSummaries=postSummaries} );
        }

        [HttpGet("parent-project")]
        public async Task<IActionResult> GetPostsByProjectId([FromQuery] int projectId)
        {
            if (projectId == 0 || projectId == null)
            {
                return Ok( new { status = "error", message = "No project ID was provided" });
            }
            IEnumerable<PostSummaryDTO> postSummaries = await _postService.GetPostsByProjectId(projectId);
            return Ok( new { status = "success", postSummaries=postSummaries });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            PostDTO post = await _postService.GetPostById(id);
            var returnValue = new {status = "success", post };
            return Ok(returnValue);
        }

        [HttpPut]
        public async Task<IActionResult> InsertPost([FromBody] PostDTO postDto)
        {
            await _postService.InsertPost(postDto);
            //return Ok(new { status = "success", message = "Post Created"});
            return Forbid();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePost(id);
            //return Ok(new { status = "success", message = "Post Delete"});
            return Forbid();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostDTO postDto)
        {
            await _postService.UpdatePost(id, postDto);
            //return Ok(new { message = "Post Updated"});
            return Forbid();
        }

        [HttpGet("summaries")]
        public async Task<IActionResult> GetAllPostSummaries()
        {
            IEnumerable<PostSummaryDTO> postSummaries = await _postService.GetAllPostSummaries();
            return Ok(new { status = "success", postSummaries=postSummaries });
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentPostSummaries() 
        {
            IEnumerable<PostSummaryDTO> postSummaries = await _postService.GetRecentPostSummaries();
            return Ok( new { status = "success", postSummaries=postSummaries });
        }
    }
}