using CodeJournalApi.Data.DataModels;
using Dapper;

namespace CodeJournalApi.Data.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProjectById(int id);
        Task InsertProject(Project project);
        // void DeleteProject();
        // void UpdateProject();
        // void Save();
    }

    public class ProjectRepository: IProjectRepository
    {
        private Context _context;

        public ProjectRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT *
                FROM Project
            ";
            return await connection.QueryAsync<Project>(sql);

        }

        public async Task<Project> GetProjectById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT *
                FROM Project
                WHERE ProjectId = @id
            ";
            return await connection.QuerySingleAsync<Project>(sql, new { id });
        }

        public async Task InsertProject(Project project)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                INSERT INTO Project (Title, Language, Description)
                VALUES (@Title, @Language, @Description)
            ";
            await connection.ExecuteAsync(sql, project);
        }
    }
}