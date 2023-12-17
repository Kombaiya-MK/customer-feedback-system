namespace CustomerFeedbackSystem.Infrastructure.Interfaces
{

    public interface IRepo<T, K>
    {
        Task<T> Get(K id);
        Task<List<T>> GetAll(); 
        Task<T> Add(T entity);
    }
}
