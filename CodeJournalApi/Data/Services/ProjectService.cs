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

        public async Task<IEnumerable<ProjectDTO>> GetAll()
        {
            // Get All Project Entities and convert to Project DTOs
            IEnumerable<Project> projectEntities = await _projectRepo.GetAll();
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

        public async Task<ProjectDTO> GetById(int id)
        {
            // Get Project Entity and Convert to DTO
            Project project = await _projectRepo.GetById(id);
            ProjectDTO dto = new ProjectDTO
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Language = project.Language,
                Description = project.Description
            };
            return dto;
        }

        public async Task Insert(ProjectDTO projectDto)
        {
            // Take Project DTO and convert to Project Entity
            Project project = new Project 
            {
                ProjectId = projectDto.ProjectId,
                Title = projectDto.Title,
                Language = projectDto.Language,
                Description = projectDto.Description
            };

            await _projectRepo.Insert(project);
        }

        public async Task Update(ProjectDTO projectDto)
        {
            // Take Project DTO and convert to Project Entity
            Project project = new Project 
            {
                ProjectId = projectDto.ProjectId,
                Title = projectDto.Title,
                Language = projectDto.Language,
                Description = projectDto.Description
            };
            await _projectRepo.Update(project);
        }

        public async Task Delete(int id)
        {
            await _projectRepo.Delete(id);
        }
    }
}