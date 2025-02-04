namespace CodeJournalApi.Data.Interfaces
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T newObject);
        Task Delete(int id);
        Task Update(T targetObject);
        // void Save();
    }
}