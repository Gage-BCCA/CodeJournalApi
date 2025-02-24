namespace CodeJournalApi.DTOs
{
    public class ProjectSummaryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }

        public ProjectSummaryDTO () {}
    }
}