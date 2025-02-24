using Dapper;
using CodeJournalApi.Entities;

namespace CodeJournalApi.Repositories
{
    
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPosts();

        Task<IEnumerable<Post>> GetPostsByProjectId(int id);
        Task<Post> GetPostById(int id);
        Task InsertPost(Post post);
        Task DeletePost(int id);
        Task UpdatePost(Post post);
        Task<IEnumerable<Post>> GetRecentPosts(); 
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
                SELECT  posts.id,
                        posts.title,
                        posts.blurb,
                        posts.content,
                        posts.date_created,
                        posts.like_count,
                        posts.dislike_count,
                        projects.id as parent_project_id,
                        projects.title as parent_project_title

                  FROM  posts
                 INNER  JOIN projects ON posts.parent_project_id = projects.id;
            ";
            return await connection.QueryAsync<Post>(sql);
        }

        public async Task<IEnumerable<Post>> GetPostsByProjectId(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT  posts.id,
                        posts.title,
                        posts.blurb,
                        posts.content,
                        posts.date_created,
                        posts.like_count,
                        posts.dislike_count,
                        posts.parent_project_id,
                        projects.title as parent_project_title
                FROM    posts
                INNER   JOIN projects ON posts.parent_project_id = projects.id
                WHERE   posts.parent_project_id = @id
            ";
            
            return await connection.QueryAsync<Post>(sql, new { id });
        }

        public async Task<Post> GetPostById(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                SELECT  posts.id,
                        posts.title,
                        posts.blurb,
                        posts.content,
                        posts.date_created,
                        posts.like_count,
                        posts.dislike_count,
                        posts.parent_project_id,
                        projects.title as parent_project_title
                FROM    posts
                INNER   JOIN projects ON posts.parent_project_id = projects.id
                WHERE   posts.id = @id
            ";
            
            return await connection.QuerySingleAsync<Post>(sql, new { id });
        }

        public async Task<IEnumerable<Post>> GetRecentPosts() 
        {
            using var connection = _context.CreateConnection();

            var sql = @"
                SELECT  posts.id,
                        posts.title,
                        posts.blurb,
                        posts.content,
                        posts.date_created,
                        posts.like_count,
                        posts.dislike_count,
                        posts.parent_project_id,
                        projects.title as parent_project_title
                FROM    posts
                INNER   JOIN projects ON posts.parent_project_id = projects.id
                ORDER   BY posts.date_created DESC
                LIMIT   3  
            ";

            return await connection.QueryAsync<Post>(sql);
        }

        public async Task InsertPost(Post post)
        {
            using var connection = _context.CreateConnection();
            post.DateCreated = DateTime.Now;
            post.Status = "Created";
            var sql = @"
                INSERT INTO posts (title, blurb, content, parent_project_id)
                VALUES (@Title, @Blurb, @Content, @ParentProjectId)
            ";
            await connection.ExecuteAsync(sql, post);
        }

        public async Task UpdatePost(Post post)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                UPDATE posts
                SET title=@Title, blurb=@Blurb, content=@Content, date_modified=@DateModified
                WHERE id=@PostId
            ";
            var parameters = new 
            {
                Id = post.Id,
                Title = post.Title,
                Blurb = post.Blurb,
                Content = post.Content,
                DateModified = DateTime.Now

            };
            await connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeletePost(int id)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
                DELETE FROM posts
                WHERE id=@PostId
            ";
            await connection.ExecuteAsync(sql, new { PostId=id });
        }
    }
}