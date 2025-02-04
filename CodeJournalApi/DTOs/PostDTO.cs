namespace CodeJournalApi.DTOs
{
    public class PostDTO 
    {
        public String Title { get; set; }
        public String Blurb { get; set; }
        public String Content {get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}