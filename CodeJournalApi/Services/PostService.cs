using CodeJournalApi.Entities;
using CodeJournalApi.Repositories;
using CodeJournalApi.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace CodeJournalApi.Services 
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetAllPosts();
        Task<PostDTO> GetPostById(int id);
        Task InsertPost(PostDTO newObject);
        Task DeletePost(int id);
        Task UpdatePost(int id, PostDTO targetObject);
        Task<IEnumerable<PostSummaryDTO>> GetAllPostSummaries();
        // void Save();
    }

    public class PostService : IPostService
    {
        private IPostRepository _postRepo;

        public PostService(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<IEnumerable<PostDTO>> GetAllPosts()
        {
            // Get All Project Entities and convert to Project DTOs
            IEnumerable<Post> postEntities = await _postRepo.GetAllPosts();

            List<PostDTO> PostDTOs = new List<PostDTO>();

            foreach (Post post in postEntities)
            {
                PostDTO dto = new PostDTO
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Blurb = post.Blurb,
                    Content = post.Content,
                    DateCreated = post.DateCreated,
                    LikeCount = post.LikeCount,
                    DislikeCount = post.DislikeCount,
                    ParentProjectTitle = post.ParentProjectTitle,
                    ParentProjectId = post.ParentProjectId
                };

                PostDTOs.Add(dto);
            }

            return PostDTOs;
        }

        public async Task<PostDTO> GetPostById(int id)
        {
            // Get Post Entity and Convert to DTO
            Post post = await _postRepo.GetPostById(id);
            PostDTO dto = new PostDTO
            {
                    PostId = post.PostId,
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
                PostId = id,
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

        public async Task<IEnumerable<PostSummaryDTO>> GetAllPostSummaries()
        {
            IEnumerable<Post> posts = await _postRepo.GetAllPosts();

            List<PostSummaryDTO> postSummaries = new List<PostSummaryDTO>();

            foreach (Post post in posts)
            {
                PostSummaryDTO summary = new PostSummaryDTO 
                {
                    PostId = post.PostId,
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