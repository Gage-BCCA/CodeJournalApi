using CodeJournalApi.Entities;
using CodeJournalApi.Data.Repositories;
using CodeJournalApi.DTOs;

namespace CodeJournalApi.Data.Services 
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetAllPosts();
        Task<PostDTO> GetPostById(int id);
        // Task Insert(PostDTO newObject);
        // Task Delete(int id);
        // Task Update(PostDTO targetObject);
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
            // Get Project Entity and Convert to DTO
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

        // public async Task Insert(PostDTO PostDTO)
        // {
        //     // Take Project DTO and convert to Project Entity
        //     Project project = new Project 
        //     {
        //         ProjectId = PostDTO.ProjectId,
        //         Title = PostDTO.Title,
        //         Language = PostDTO.Language,
        //         Description = PostDTO.Description
        //     };

        //     await _postRepo.Insert(project);
        // }

        // public async Task Update(PostDTO PostDTO)
        // {
        //     // Take Project DTO and convert to Project Entity
        //     Project project = new Project 
        //     {
        //         ProjectId = PostDTO.ProjectId,
        //         Title = PostDTO.Title,
        //         Language = PostDTO.Language,
        //         Description = PostDTO.Description
        //     };
        //     await _postRepo.Update(project);
        // }

        // public async Task Delete(int id)
        // {
        //     await _postRepo.Delete(id);
        // }
        
    
    }
}