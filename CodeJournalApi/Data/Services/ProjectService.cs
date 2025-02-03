using CodeJournalApi.Entities;
using CodeJournalApi.DTOs;
using CodeJournalApi.Data.Repositories;

namespace CodeJournalApi.Data.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetProjects();
        Task<Project> GetProjectById(int id);
        Task InsertProject(Project project);
        Task DeleteProject(int id);
        Task UpdateProject(Project project);
        // void Save();
    }

    public class ProjectService: IProjectService
    {
        private IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjects()
        {
            IEnumerable<Project> projectEntities = await _projectRepo.GetProjects();
            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();

            foreach (Project project in projectEntities)
            {
                ProjectDTO dto = new ProjectDTO
                {
                    Title = project.Title,
                    Language = project.Language,
                    Description = project.Description
                };

                projectDTOs.Add(dto);
            }

            return projectDTOs;
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _projectRepo.GetProjectById(id);
        }

        public async Task InsertProject(Project project)
        {
            await _projectRepo.InsertProject(project);
        }

        public async Task UpdateProject(Project project)
        {
            await _projectRepo.UpdateProject(project);
        }

        public async Task DeleteProject(int id)
        {
            await _projectRepo.DeleteProject(id);
        }
    }
}