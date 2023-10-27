public interface ICrud<T> where T : class
{
    //implementation of CRUD operations
    Task<List<T>> ReadAll(); // retur new List<>()
    Task<List<T>> ReadById(int id);
    Task Create(T entity);
    Task Update(int id, T entity);
    Task Delete(int id);
}
