using CodeJournalApi.Data.DataModels;
using CodeJournalApi.Data.Repositories;

namespace CodeJournalApi.Data.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProjectById(int id);
        Task InsertProject(Project project);
        // void DeleteProject();
        // void UpdateProject();
        // void Save();
    }

    public class ProjectService: IProjectService
    {
        private IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _projectRepo.GetProjects();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _projectRepo.GetProjectById(id);
        }

        public async Task InsertProject(Project project)
        {
            await _projectRepo.InsertProject(project);
        }
    }
}