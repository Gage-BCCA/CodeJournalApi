namespace CodeJournalApi.Data.DataModels
{
    public class Project
    {
        public required String Title { get; set; }
        public required String Language { get; set; }
        public required String Description { get; set;}

        public Project(int ProjectId, String name, String language, String description)
        {
            Title = name;
            Language = language;
            Description = description;
        }

        public Project() {}
    }


}