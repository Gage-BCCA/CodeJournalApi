using Dapper;
using CodeJournalApi.Entities;

namespace CodeJournalApi.Data.Repositories
{
    
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<Post> GetPostById(int id);
        Task InsertPost(Post post);
        Task DeletePost(int id);
        Task UpdatePost(Post post);
        // void Save();
    }

    public class PostRepository : IPostRepository
    {
        private Context _context;

        public PostRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT  Posts.PostId,
                        Posts.Title,
                        Posts.Blurb,
                        Posts.Content,
                        Posts.DateCreated,
                        Posts.LikeCount,
                        Posts.DislikeCount,
                        Projects.ProjectId as ParentProjectId,
                        Projects.Title as ParentProjectTitle

                  FROM  Posts
                 INNER  JOIN Projects ON Posts.ParentProjectId = Projects.ProjectId;
            ";
            return await connection.QueryAsync<Post>(sql);
        }

        public async Task<Post> GetPostById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT  Posts.PostId,
                        Posts.Title,
                        Posts.Blurb,
                        Posts.Content,
                        Posts.DateCreated,
                        Posts.LikeCount,
                        Posts.DislikeCount,
                        Projects.ProjectId as ParentProjectId,
                        Projects.Title as ParentProjectTitle
                FROM Posts
                INNER JOIN Projects ON Posts.ParentProjectId = Projects.ProjectId
                WHERE PostId = @id
            ";
            return await connection.QuerySingleAsync<Post>(sql, new { id });
        }

        public async Task InsertPost(Post post)
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

        public async Task UpdatePost(Post post)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                UPDATE Posts
                SET Title=@Title, Language=@Language, Description=@Description
                WHERE PostId=@PostId
            ";
            await connection.ExecuteAsync(sql, post);
        }

        public async Task DeletePost(int id)
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