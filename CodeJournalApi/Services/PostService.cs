using CodeJournalApi.Entities;
using CodeJournalApi.Repositories;
using CodeJournalApi.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace CodeJournalApi.Services 
{
    public interface IPostService
    {
        Task<IEnumerable<PostSummaryDTO>> GetAllPosts();
        Task<IEnumerable<PostSummaryDTO>> GetAllPostSummaries();
        Task<IEnumerable<PostSummaryDTO>> GetRecentPostSummaries();
        Task<IEnumerable<PostSummaryDTO>> GetPostsByProjectId(int id);
        Task<PostDTO> GetPostById(int id);
        Task InsertPost(PostDTO newObject);
        Task DeletePost(int id);
        Task UpdatePost(int id, PostDTO targetObject);
 
    }

    public class PostService : IPostService
    {
        private IPostRepository _postRepo;

        public PostService(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<IEnumerable<PostSummaryDTO>> GetAllPosts()
        {
            // Get All Project Entities and convert to Project DTOs
            IEnumerable<Post> posts = await _postRepo.GetAllPosts();
            return ConstructPostSummariesFromPosts(posts);
        }

        public async Task<IEnumerable<PostSummaryDTO>> GetPostsByProjectId(int id)
        {
            IEnumerable<Post> posts = await _postRepo.GetPostsByProjectId(id);
            return ConstructPostSummariesFromPosts(posts);
        }

        public async Task<PostDTO> GetPostById(int id)
        {
            // Get Post Entity and Convert to DTO
            Post post = await _postRepo.GetPostById(id);
            PostDTO dto = new PostDTO
            {
                    Id = post.Id,
                    Title = post.Title,
                    Blurb = post.Blurb,
                    Content = post.Content,
                    DateCreated = post.DateCreated,
                    LikeCount = post.LikeCount,
                    DislikeCount = post.DislikeCount,
                    ParentProjectTitle = post.ParentProjectTitle,
                    ParentProjectId = post.ParentProjectId
            };
            return dto;
        }

        public async Task InsertPost(PostDTO postDto)
        {
            Post post = new Post()
            {
                Title = postDto.Title,
                Blurb = postDto.Blurb,
                Content = postDto.Content,
                ParentProjectId = postDto.ParentProjectId
            };

            await _postRepo.InsertPost(post);
        }

        public async Task UpdatePost(int id, PostDTO postDto)
        {
            // Take Project DTO and convert to Project Entity
            Post post = new Post()
            {
                Id = id,
                Title = postDto.Title,
                Blurb = postDto.Blurb,
                Content = postDto.Content,
            };
            await _postRepo.UpdatePost(post);
        }

        public async Task DeletePost(int id)
        {
            await _postRepo.DeletePost(id);
        }

        // TODO: Remove this. This is a duplicate function. Whoops.
        public async Task<IEnumerable<PostSummaryDTO>> GetAllPostSummaries()
        {
            IEnumerable<Post> posts = await _postRepo.GetAllPosts();
            return ConstructPostSummariesFromPosts(posts);
        }


        public async Task<IEnumerable<PostSummaryDTO>> GetRecentPostSummaries()
        {
            IEnumerable<Post> posts = await _postRepo.GetRecentPosts();
            return ConstructPostSummariesFromPosts(posts);
        }


        private List<PostSummaryDTO> ConstructPostSummariesFromPosts(IEnumerable<Post> posts) 
        {
            List<PostSummaryDTO> postSummaries = new List<PostSummaryDTO>();

            foreach (Post post in posts)
            {
                PostSummaryDTO summary = new PostSummaryDTO 
                {
                    Id = post.Id,
                    Title = post.Title,
                    Blurb = post.Blurb,
                    DateCreated = post.DateCreated,
                    LikeCount = post.LikeCount
                };

                postSummaries.Add(summary);
            }

            return postSummaries;
        }   
    
    }
}