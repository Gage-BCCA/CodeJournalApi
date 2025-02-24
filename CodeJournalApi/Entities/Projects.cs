namespace CodeJournalApi.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Language { get; set; }
        public required string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; }
        public string GithubLink { get; set; }
        

        public Project() {} // Empty Constructor for Dapper deserialization
    }
    
}