namespace CodeJournalApi.DTOs
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }

        public ProjectDTO(string title, string language, string description)
        {
            this.Title = title;
            this.Language = language;
            this.Description = description;
        }

        public ProjectDTO () {}
    }
}