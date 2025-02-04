namespace CodeJournalApi.Entities
{
    class Post
    {
        public int PostId { get; set; }
        public String Title { get; set; }
        public String Blurb { get; set; }
        public String Content {get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Slug { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public string Status { get; set; }
        public int ParentProjectId { get; set; }

        public Post() {} 

    }
}