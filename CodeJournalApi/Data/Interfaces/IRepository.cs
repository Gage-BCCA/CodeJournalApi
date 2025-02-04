namespace CodeJournalApi.Data.Interfaces
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T newObject);
        Task Delete(int id);
        Task Update(T targetObject);
        // void Save();
    }
}