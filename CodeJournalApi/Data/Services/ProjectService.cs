using CodeJournalApi.Entities;
using CodeJournalApi.DTOs;
using CodeJournalApi.Data.Interfaces;

namespace CodeJournalApi.Data.Services
{

    public class ProjectService: IService<ProjectDTO>
    {
        private IRepository<Project> _projectRepo;

        public ProjectService(IRepository<Project> projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjects()
        {
            // Get All Project Entities and convert to Project DTOs
            IEnumerable<Project> projectEntities = await _projectRepo.GetProjects();
            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();

            foreach (Project project in projectEntities)
            {
                ProjectDTO dto = new ProjectDTO
                {
                    ProjectId = project.ProjectId,
                    Title = project.Title,
                    Language = project.Language,
                    Description = project.Description
                };

                projectDTOs.Add(dto);
            }

            return projectDTOs;
        }

        public async Task<ProjectDTO> GetProjectById(int id)
        {
            // Get Project Entity and Convert to DTO
            Project project = await _projectRepo.GetProjectById(id);
            ProjectDTO dto = new ProjectDTO
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Language = project.Language,
                Description = project.Description
            };
            return dto;
        }

        public async Task InsertProject(ProjectDTO projectDto)
        {
            // Take Project DTO and convert to Project Entity
            Project project = new Project 
            {
                ProjectId = projectDto.ProjectId,
                Title = projectDto.Title,
                Language = projectDto.Language,
                Description = projectDto.Description
            };

            await _projectRepo.InsertProject(project);
        }

        public async Task UpdateProject(ProjectDTO projectDto)
        {
            // Take Project DTO and convert to Project Entity
            Project project = new Project 
            {
                ProjectId = projectDto.ProjectId,
                Title = projectDto.Title,
                Language = projectDto.Language,
                Description = projectDto.Description
            };
            await _projectRepo.UpdateProject(project);
        }

        public async Task DeleteProject(int id)
        {
            await _projectRepo.DeleteProject(id);
        }
    }
}