namespace CodeJournalApi.Data.Interfaces
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetProjects();
        Task<T> GetProjectById(int id);
        Task InsertProject(T project);
        Task DeleteProject(int id);
        Task UpdateProject(T project);
        // void Save();
    }
}