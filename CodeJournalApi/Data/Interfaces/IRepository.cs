namespace CodeJournalApi.Data.Interfaces
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> GetProjects();
        Task<T> GetProjectById(int id);
        Task InsertProject(T newObject);
        Task DeleteProject(int id);
        Task UpdateProject(T targetObject);
        // void Save();
    }
}