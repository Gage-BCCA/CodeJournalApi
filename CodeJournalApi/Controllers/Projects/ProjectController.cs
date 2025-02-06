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
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectById(id);
            return Ok(project);
        }

        [HttpGet("{id}/all")]
        public async Task<IActionResult> GetPostsByProjectId(int id)
        {
            ProjectDetailsDTO projectDetails = await _projectService.GetProjectDetailsById(id);
            return Ok(projectDetails);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProject([FromBody] ProjectDTO projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _projectService.InsertProject(projectDto);
            return Ok(new { message = "Project Created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectDTO projectDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Handle this part on the service layer
            projectDto.ProjectId = id;
            await _projectService.UpdateProject(projectDto);
            return Ok(new { status="success", message = "Project Updated"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProject(id);
            return Ok(new { status="success", message = "Project Deleted"});
        }
    }
}