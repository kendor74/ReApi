namespace ReApiConsumer.Models.Interfaces
{
    public interface IApi<T>
    {
        Task<List<T>> Get(string api);
        Task<List<T>> GetById(string api ,int id);
        Task<T> Post(string api, T entity);
        Task<T> Put(string api, T entity);
        Task<T> Delete(string api, int id);
    }
}
