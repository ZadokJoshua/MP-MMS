namespace MP_MMS.EntityFramworkCore.Repositories
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Create(T entity);

        Task<T> GetById(int id);

        Task<T> Update(int id, T entity);

        Task<bool> Delete(int id);
    }
}
