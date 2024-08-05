using CRUDAPI.DAL.DBContext;
using CRUDAPI.DAL.Entity;
using CRUDAPI.DAL.Entity.DTO;
using CRUDAPI.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUDAPI.DAL.Repositories
{
    public class PostRepository : Repository<Post, blogContext>, IPostRepository
    {
        private readonly blogContext _context;

        public PostRepository(blogContext context) : base(context)
        {
            _context = context;
        }
        /*public async Task<Post> GetPublishedPostByActiveUserAsync(int postId, int userId)
        {
            return await _context.Posts
                .Include(p => p.CreatedBy)
                .Where(p => p.Id == postId && (bool)p.IsPublished && p.CreatedByUser.IsActive && p.CreatedBy == userId)
                .FirstOrDefaultAsync();
        }

    }*/
        /*private readonly DbSet<T> set;
        private readonly DbContext context;

        public PostRepository(DbContext context) : base(context)
        {
            set = context.Set<T>();
            this.context = context;
        }*/
        /*public async Task<IEnumerable<Post>> GetByCategoryAsync(int category)
        {
            return await set.Where(p => (bool)p.IsPublished && p.Category == category).ToListAsync();
        }*/
        public async Task<ICollection<JoinDTO>> GetPostsAsync()
        {
            var joinDTOs = await (from user in _context.Users
                                  join post in _context.Posts on user.Id equals post.CreatedBy
                                  select new JoinDTO
                                  {
                                      UserId = user.Id,
                                      Name = user.Name,
                                      Password = user.Password,
                                      IsActive = user.IsActive,
                                      Id = post.Id,
                                      Title = post.Title,
                                      Description = post.Description,
                                      Category = post.Category,
                                      CreatedDate = post.CreatedDate,
                                      IsPublished = post.IsPublished,
                                      CreatedBy = user.Name,
                                  }).ToListAsync();
            return joinDTOs;
        }
    }
}
