using CRUDAPI.DAL.DBContext;
using CRUDAPI.DAL.Entity;
using CRUDAPI.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.DAL.Repositories
{
    public class UserRepository : Repository<User, blogContext>, IUserRepository
    {
        public UserRepository(blogContext context) : base(context)
        {
        }
    }
}
