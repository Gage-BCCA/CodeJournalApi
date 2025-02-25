using CodeJournalApi.Services;
using CodeJournalApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CodeJournalApi.Controllers.Projects
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjects();
            return Ok(new {status = "success", projects});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectById(id);
            return Ok(new { status="success", project });
        }

        [HttpGet("{id}/all")]
        public async Task<IActionResult> GetPostsByProjectId(int id)
        {
            ProjectDetailsDTO projectDetails = await _projectService.GetProjectDetailsById(id);
            return Ok(projectDetails);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProject([FromBody] ProjectSummaryDTO projectSummaryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _projectService.InsertProject(projectSummaryDTO);
            //return Ok(new { message = "Project Created" });
            return Forbid();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectSummaryDTO projectSummaryDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Handle this part on the service layer
            projectSummaryDTO.Id = id;
            await _projectService.UpdateProject(projectSummaryDTO);
            //return Ok(new { status="success", message = "Project Updated"});
            return Forbid();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProject(id);
            //return Ok(new { status="success", message = "Project Deleted"});
            return Forbid();
        }
    }
}