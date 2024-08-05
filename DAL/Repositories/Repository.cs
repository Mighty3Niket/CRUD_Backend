using CRUDAPI.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using CRUDAPI.DAL.DBContext;

namespace CRUDAPI.DAL.Repositories
{
    public class Repository<T, Tcontext> : IRepository<T> where T : class where Tcontext : DbContext
    {
        private readonly Tcontext DbContext;
        public Repository(Tcontext context)
        {
            this.DbContext = context;
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? condition)
        {
            IQueryable<T> result = this.DbContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }
            return await result.ToListAsync();
        }

        /*public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this.DbContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return result;
        }*/

        public async Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = this.DbContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return await result.ToListAsync();

        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> result = this.DbContext.Set<T>();
            return result;
        }

        public async Task<ICollection<T>> GetAllUsersAsync()
        {
            IQueryable<T> result = this.DbContext.Set<T>();
            return await result.ToListAsync();
        }

        public async Task<ICollection<T>> GetAllPostsAsync()
        {
            IQueryable<T> result = this.DbContext.Set<T>();
            return await result.ToListAsync();
        }

        public bool Add(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
            return true;
        }

        public bool Update(T entity)
        {
            this.DbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
           // this.DbContext.SaveChanges();
            return true;
        }


        public void SaveChangesManaged()
        {
            this.DbContext.SaveChanges();
        }

        public async Task<T> GetByID(int id)
        {
            return await this.DbContext.Set<T>().FindAsync(id);
        }
    }
}
