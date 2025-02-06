using CodeJournalApi.Entities;
using Dapper;
using Microsoft.IdentityModel.Tokens;

namespace CodeJournalApi.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        Task<IEnumerable<Post>> GetProjectChildPostsById(int id);
        Task InsertProject(Project project);
        Task DeleteProject(int id);
        Task UpdateProject(Project project);
        // void Save();
    }
    
    public class ProjectRepository: IProjectRepository
    {
        private Context _context;

        public ProjectRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT *
                FROM Projects
            ";
            return await connection.QueryAsync<Project>(sql);
        }

        public async Task<Project> GetProjectById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT *
                FROM Projects
                WHERE ProjectId = @id
            ";
            return await connection.QuerySingleOrDefaultAsync<Project>(sql, new { id = id });
        }

        public async Task<IEnumerable<Post>> GetProjectChildPostsById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT *
                FROM Posts
                WHERE ParentProjectId = @id
            ";
            return await connection.QueryAsync<Post>(sql, new { id });
        }

        public async Task InsertProject(Project project)
        {
            using var connection = _context.CreateConnection();
            project.DateCreated = DateTime.Now;
            project.Status = "Created";
            var sql = @"
                INSERT INTO Projects (Title, Language, Description, DateCreated, Status)
                VALUES (@Title, @Language, @Description, @DateCreated, @Status)
            ";
            await connection.ExecuteAsync(sql, project);
        }

        public async Task UpdateProject(Project project)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                UPDATE Projects
                SET Title=@Title, Language=@Language, Description=@Description
                WHERE ProjectId=@ProjectId
            ";
            await connection.ExecuteAsync(sql, project);
        }

        public async Task DeleteProject(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                DELETE FROM Projects
                WHERE ProjectId=@ProjectId
            ";
            await connection.ExecuteAsync(sql, new { ProjectId=id });
        }
    }
}