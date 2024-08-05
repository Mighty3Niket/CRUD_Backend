using AutoMapper;
using CRUDAPI.BAL.IServices;
using CRUDAPI.DAL.Entity;
using CRUDAPI.DAL.Entity.DTO;
using CRUDAPI.DAL.IRepositories;
using System.Collections.ObjectModel;

namespace CRUDAPI.BAL.Services
{
    public class PostService : IPostService
    {
        IMapper _mapper;
        IPostRepository _postRepo;
        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepo = postRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<PostDTO>> GetAllPublishedPosts(bool ispublished)
        {
            var allPublishedPosts = await _postRepo.GetAllAsync(a => a.IsPublished == ispublished);
            ICollection<PostDTO> posts = _mapper.Map<ICollection<PostDTO>>(allPublishedPosts);
            return posts;
        }
        public async Task<ICollection<PostDTO>> GetAllPosts()
        {
            var allPosts = await _postRepo.GetAllPostsAsync();
            ICollection<PostDTO> posts = _mapper.Map<ICollection<PostDTO>>(allPosts);
            return posts;
        }
        public async Task<ICollection<PostDTO>> GetPostById(int id)
        {
            var postbyid = await _postRepo.GetAllAsync(a => a.Id == id);
            ICollection<PostDTO> posts = _mapper.Map<Collection<PostDTO>>(postbyid);

            return posts;
        }
        public async Task<ICollection<PostDTO>> GetPostByCategory(int category)
        {
            var postbycategory = await _postRepo.GetAllAsync(a => a.Category == category);
            ICollection<PostDTO> posts = _mapper.Map<Collection<PostDTO>>(postbycategory);

            return posts;
        }
        public async Task<ICollection<PostDTO>> GetPublishedPostsById(int createdby)
        {
            var allPublishedPostsByCreatedBy = await _postRepo.GetAllAsync(a => a.CreatedBy == createdby && a.IsPublished == true);
            ICollection<PostDTO> posts = _mapper.Map<ICollection<PostDTO>>(allPublishedPostsByCreatedBy);
            return posts;
        }
        public async Task<ICollection<PostDTO>> GetPublishedPostsByID(int id)
        {
            var allPublishedPostsById = await _postRepo.GetAllAsync(a => a.Id == id && a.IsPublished == true);
            ICollection<PostDTO> posts = _mapper.Map<ICollection<PostDTO>>(allPublishedPostsById);
            return posts;
        }
        public async Task<ICollection<PostDTO>> GetPublishedPostsByCategory(int category)
        {
            var allPublishedPostsByCategory = await _postRepo.GetAllAsync(a => a.Category == category && a.IsPublished == true);
            ICollection<PostDTO> posts = _mapper.Map<ICollection<PostDTO>>(allPublishedPostsByCategory);
            return posts;
        }
        /*public async Task<ICollection<JoinDTO>> GetPublishedPostsOfActiveUserById(int id)
        {
            var allPublishedPostsOfActiveUserById = await _postRepo.GetAllAsync(a => a.Id == id && a.IsPublished == true && a.IsActive == true);
            ICollection<JoinDTO> joins = _mapper.Map<ICollection<JoinDTO>>(allPublishedPostsOfActiveUserById);
            return joins;
        }*/
        public async Task<bool> AddPost(PostDTO post)
        {
            if (post == null) throw new Exception();
            Post pst = _mapper.Map<Post>(post);
            _postRepo.Add(pst);
            _postRepo.SaveChangesManaged();
            return true;
        }
        public async Task<bool> UpdatePost(PostDTO post)
        {
            if (post == null) throw new Exception();
            Post pst = _mapper.Map<Post>(post);
            _postRepo.Update(pst);
            _postRepo.SaveChangesManaged();
            return true;
        }
        public async Task<bool> DeletePost(int id)
        {
            //if (id == null) throw new Exception();
            //Post usr = _mapper.Map<Post>(id);
            Post pst = await _postRepo.GetByID(id);
            if (pst == null) return false;
            //_postRepo.Delete(usr);
            //_postRepo.SaveChangesManaged();
             await _postRepo.Delete(pst);
             _postRepo.SaveChangesManaged();
            return true;
        }
        public async Task<bool> SoftDeletePost(int id)
        {
            Post pst = await _postRepo.GetByID(id);
            //if (pst.Id == null) return false;
            if (pst.IsPublished == true)
            {
                pst.IsPublished = false;
                _postRepo.SaveChangesManaged();
                return true;
            }
            return false;
        }
        public async Task<ICollection<JoinDTO>> GetPosts()
        {
            return await _postRepo.GetPostsAsync();
        }
    }
}
