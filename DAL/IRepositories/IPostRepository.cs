using CRUDAPI.DAL.Entity;
using CRUDAPI.DAL.Entity.DTO;

namespace CRUDAPI.DAL.IRepositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<ICollection<JoinDTO>> GetPostsAsync();
        //Task<IEnumerable<Post>> GetByCategoryAsync(int category);
        //Task<Post> GetPublishedPostByActiveUserAsync(int postId, int userId);
    }
}
