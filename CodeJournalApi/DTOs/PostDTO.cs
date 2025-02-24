namespace CodeJournalApi.DTOs
{
    public class PostDTO 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public string Content {get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int ParentProjectId { get; set; }
        public string ParentProjectTitle { get; set; }
    }
}