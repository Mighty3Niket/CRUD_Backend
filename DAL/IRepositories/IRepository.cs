using System.Linq.Expressions;

namespace CRUDAPI.DAL.IRepositories
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> condition);
        //IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition);
        Task<ICollection<T>> GetAllUsersAsync();
        Task<ICollection<T>> GetAllPostsAsync();
        //Task<T> GetPublishedPostOfActiveUserById(int id);
        Task<T> GetByID(int id);
        bool Add(T entity);
        bool Update(T entity);
        Task<bool> Delete(T entity);
        void SaveChangesManaged();
    }
}
