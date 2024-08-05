using CRUDAPI.DAL.Entity.DTO;
using CRUDAPI.Helper;

namespace CRUDAPI.BAL.IServices
{
    public interface IPostService
    {
        public Task<ICollection<PostDTO>> GetAllPublishedPosts(bool ispublished);
        public Task<ICollection<PostDTO>> GetAllPosts();
        public Task<ICollection<PostDTO>> GetPostById(int id);
        public Task<ICollection<PostDTO>> GetPostByCategory(int category);
        public Task<ICollection<PostDTO>>GetPublishedPostsById(int createdby);
        public Task<ICollection<PostDTO>> GetPublishedPostsByID(int id);
        public Task<ICollection<PostDTO>> GetPublishedPostsByCategory(int category);
        public Task<ICollection<JoinDTO>> GetPosts();
        public Task<bool> AddPost(PostDTO post);
        public Task<bool> UpdatePost(PostDTO post);
        public Task<bool> DeletePost(int id);
        public Task<bool> SoftDeletePost(int id);
    }
}
