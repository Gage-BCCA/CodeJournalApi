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
                FROM projects
            ";
            return await connection.QueryAsync<Project>(sql);
        }

        public async Task<Project> GetProjectById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT *
                FROM projects
                WHERE id = @id
            ";
            return await connection.QuerySingleOrDefaultAsync<Project>(sql, new { id = id });
        }

        public async Task<IEnumerable<Post>> GetProjectChildPostsById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT *
                FROM posts
                WHERE parent_project_id = @id
            ";
            return await connection.QueryAsync<Post>(sql, new { id });
        }

        public async Task InsertProject(Project project)
        {
            using var connection = _context.CreateConnection();
            project.DateCreated = DateTime.Now;
            project.Status = "Created";
            var sql = @"
                INSERT INTO projects (title, language, description, date_created, status)
                VALUES (@Title, @Language, @Description, @DateCreated, @Status)
            ";
            await connection.ExecuteAsync(sql, project);
        }

        public async Task UpdateProject(Project project)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                UPDATE projects
                SET title=@Title, language=@Language, description=@Description
                WHERE id=@Id
            ";
            await connection.ExecuteAsync(sql, project);
        }

        public async Task DeleteProject(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                DELETE FROM projects
                WHERE id=@Id
            ";
            await connection.ExecuteAsync(sql, new { Id=id });
        }
    }
}