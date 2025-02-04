using CodeJournalApi.Entities;
using CodeJournalApi.Data.Interfaces;
using CodeJournalApi.DTOs;

namespace CodeJournalApi.Data.Services 
{
    public class PostService : IService<PostDTO>
    {
        private IRepository<Post> _postRepo;

        public PostService(IRepository<Post> postRepo)
        {
            _postRepo = postRepo;
        }
        
    
    }
}