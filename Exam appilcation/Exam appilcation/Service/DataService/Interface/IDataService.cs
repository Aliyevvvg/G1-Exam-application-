namespace Exam_appilcation.Service;

public interface IDataService<T>
{
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(long id);

    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> RemoveAsync(T entity);
    Task<T> RemoveAsync(long id);
}