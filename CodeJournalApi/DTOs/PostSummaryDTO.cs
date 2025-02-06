namespace CodeJournalApi.DTOs
{
    public class PostSummaryDTO 
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public DateTime DateCreated { get; set; }
        public int LikeCount { get; set; }
    }
}