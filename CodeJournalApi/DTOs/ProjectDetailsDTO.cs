namespace CodeJournalApi.DTOs
{
    public class ProjectDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string GithubLink { get; set; }
        public int NumberOfPosts { get; set; }
        public List<PostSummaryDTO> ChildPosts { get; set; }
    }
}