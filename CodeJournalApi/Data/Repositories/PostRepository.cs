using Dapper;
using CodeJournalApi.Entities;
using CodeJournalApi.Data.Interfaces;

namespace CodeJournalApi.Data.Repositories
{
    
    
    public class PostRepository : IRepository<Post>
    {
        private Context _context;

        public PostRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT *
                FROM Posts
            ";
            return await connection.QueryAsync<Post>(sql);
        }

        public async Task<Post> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT *
                FROM Posts
                WHERE PostId = @id
            ";
            return await connection.QuerySingleAsync<Post>(sql, new { id });
        }

        public async Task Insert(Post post)
        {
            using var connection = _context.CreateConnection();
            post.DateCreated = DateTime.Now;
            post.Status = "Created";
            var sql = @"
                INSERT INTO Posts (Title, Language, Description, DateCreated, Status)
                VALUES (@Title, @Language, @Description, @DateCreated, @Status)
            ";
            await connection.ExecuteAsync(sql, post);
        }

        public async Task Update(Post post)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                UPDATE Posts
                SET Title=@Title, Language=@Language, Description=@Description
                WHERE PostId=@PostId
            ";
            await connection.ExecuteAsync(sql, post);
        }

        public async Task Delete(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                DELETE FROM Posts
                WHERE PostId=@PostId
            ";
            await connection.ExecuteAsync(sql, new { PostId=id });
        }
    }
}