using CodeJournalApi.Entities;
using CodeJournalApi.DTOs;
using CodeJournalApi.Repositories;

namespace CodeJournalApi.Services
{

    public interface IProjectService
    {
        Task<IEnumerable<ProjectSummaryDTO>> GetAllProjects();
        Task<ProjectSummaryDTO> GetProjectById(int id);
        Task<ProjectDetailsDTO> GetProjectDetailsById(int id);
        Task InsertProject(ProjectSummaryDTO newObject);
        Task DeleteProject(int id);
        Task UpdateProject(ProjectSummaryDTO targetObject);
        // void Save();
    }

    public class ProjectService: IProjectService
    {
        private IProjectRepository _projectRepo;

        public ProjectService(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<IEnumerable<ProjectSummaryDTO>> GetAllProjects()
        {
            // Get All Project Entities and convert to Project DTOs
            IEnumerable<Project> projects = await _projectRepo.GetAllProjects();
            List<ProjectSummaryDTO> projectSummaries = new List<ProjectSummaryDTO>();

            foreach (Project project in projects)
            {
                ProjectSummaryDTO dto = new ProjectSummaryDTO
                {
                    Id = project.Id,
                    Title = project.Title,
                    Language = project.Language,
                    Description = project.Description
                };

                projectSummaries.Add(dto);
            }

            return projectSummaries;
        }

        public async Task<ProjectSummaryDTO> GetProjectById(int id)
        {
            // Get Project Entity and Convert to DTO
            Project project = await _projectRepo.GetProjectById(id);
            ProjectSummaryDTO dto = new ProjectSummaryDTO
            {
                Id = project.Id,
                Title = project.Title,
                Language = project.Language,
                Description = project.Description
            };
            return dto;
        }

        public async Task<ProjectDetailsDTO> GetProjectDetailsById(int id)
        {
            
            Project project = await _projectRepo.GetProjectById(id);
            IEnumerable<Post> posts = await _projectRepo.GetProjectChildPostsById(id);

            // Construct PostSummaryDTOs
            List<PostSummaryDTO> postSummaries = new List<PostSummaryDTO>();
            foreach (Post post in posts)
            {
                PostSummaryDTO dto = new PostSummaryDTO
                {
                    Id = post.Id,
                    Title = post.Title,
                    Blurb = post.Blurb,
                    DateCreated = post.DateCreated,
                    LikeCount = post.LikeCount
                };
                postSummaries.Add(dto);
            }

            ProjectDetailsDTO projectDetails = new ProjectDetailsDTO 
            {
                Id = project.Id,
                Title = project.Title,
                Language = project.Language,
                Description = project.Description,
                DateCreated = project.DateCreated,
                GithubLink = project.GithubLink,
                NumberOfPosts = postSummaries.Count,
                ChildPosts = postSummaries
            };

            return projectDetails;

        }

        public async Task InsertProject(ProjectSummaryDTO projectDto)
        {
            // Take Project DTO and convert to Project Entity
            Project project = new Project 
            {
                Id = projectDto.Id,
                Title = projectDto.Title,
                Language = projectDto.Language,
                Description = projectDto.Description
            };

            await _projectRepo.InsertProject(project);
        }

        public async Task UpdateProject(ProjectSummaryDTO projectDto)
        {
            // Take Project DTO and convert to Project Entity
            Project project = new Project 
            {
                Id = projectDto.Id,
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