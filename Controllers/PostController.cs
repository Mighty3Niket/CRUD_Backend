using CRUDAPI.BAL.IServices;
using CRUDAPI.BAL.Services;
using CRUDAPI.DAL.Entity;
using CRUDAPI.DAL.Entity.DTO;
using CRUDAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        private readonly ILogger _logger;

        public PostController(IPostService service, ILogger<PostController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return Ok("This is my CRUD-Backend Operation.");
        }

        [HttpGet("AllPosts")]
        public async Task<ApiResponse<ICollection<PostDTO>>> GetPost()
        {
            ApiResponse<ICollection<PostDTO>> postDTOs = new ApiResponse<ICollection<PostDTO>>();
            try
            {
                postDTOs.Result = await _service.GetAllPosts();
                postDTOs.StatusCode = HttpStatusCode.OK;
                postDTOs.Message = StatusMessages.Post_Got;
            }
            catch (Exception ex)
            {
                postDTOs.StatusCode = HttpStatusCode.InternalServerError;
                postDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "PostController [GetPost] : " + ex.Message);
            }
            return postDTOs;
        }

        [HttpGet("AllPublishedPosts/{ispublished}")]
        public async Task<ApiResponse<ICollection<PostDTO>>> GetPublishedPost(bool ispublished)
        {
            ApiResponse<ICollection<PostDTO>> postDTOs = new ApiResponse<ICollection<PostDTO>>();
            try
            {
                postDTOs.Result = await _service.GetAllPublishedPosts(ispublished);
                postDTOs.StatusCode = HttpStatusCode.OK;
                postDTOs.Message = StatusMessages.Post_Got;
            }
            catch (Exception ex)
            {
                postDTOs.StatusCode = HttpStatusCode.InternalServerError;
                postDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "PostController [GetPublishedPost] : " + ex.Message);
            }
            return postDTOs;
        }

        [HttpGet("PostById/{id}")]

        public async Task<ApiResponse<ICollection<PostDTO>>> GetPostsById(int id)
        {
            ApiResponse<ICollection<PostDTO>> postDTOs = new ApiResponse<ICollection<PostDTO>>();
            try
            {
                postDTOs.Result = await _service.GetPostById(id);
                postDTOs.StatusCode = HttpStatusCode.OK;
                postDTOs.Message = StatusMessages.User_Got;
            }
            catch (Exception ex)
            {
                postDTOs.StatusCode = HttpStatusCode.InternalServerError;
                postDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [GetActiveUser] : " + ex.Message);
            }
            return postDTOs;
        }

        [HttpGet("PostByCategory/{category}")]

        public async Task<ApiResponse<ICollection<PostDTO>>> GetPostsByCategory(int category)
        {
            ApiResponse<ICollection<PostDTO>> postDTOs = new ApiResponse<ICollection<PostDTO>>();
            try
            {
                postDTOs.Result = await _service.GetPostByCategory(category);
                postDTOs.StatusCode = HttpStatusCode.OK;
                postDTOs.Message = StatusMessages.User_Got;
            }
            catch (Exception ex)
            {
                postDTOs.StatusCode = HttpStatusCode.InternalServerError;
                postDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [GetActiveUser] : " + ex.Message);
            }
            return postDTOs;
        }

        [HttpGet("PublishedPostsByUserId/{createdby}")]
        public async Task<ApiResponse<ICollection<PostDTO>>> GetPublishedPostById(int createdby)
        {
            ApiResponse<ICollection<PostDTO>> postDTOs = new ApiResponse<ICollection<PostDTO>>();
            try
            {
                postDTOs.Result = await _service.GetPublishedPostsById(createdby);
                postDTOs.StatusCode = HttpStatusCode.OK;
                postDTOs.Message = StatusMessages.Post_Got;
            }
            catch (Exception ex)
            {
                postDTOs.StatusCode = HttpStatusCode.InternalServerError;
                postDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "PostController [GetPublishedPostById] : " + ex.Message);
            }
            return postDTOs;
        }

        [HttpGet("PublishedPostsByPostId/{id}")]
        public async Task<ApiResponse<ICollection<PostDTO>>> GetPublishedPostByID(int id)
        {
            ApiResponse<ICollection<PostDTO>> postDTOs = new ApiResponse<ICollection<PostDTO>>();
            try
            {
                postDTOs.Result = await _service.GetPublishedPostsByID(id);
                //response.Result = await _service.AddPost(post);
                postDTOs.StatusCode = HttpStatusCode.OK;
                postDTOs.Message = StatusMessages.Post_Got;
            }
            catch (Exception ex)
            {
                postDTOs.StatusCode = HttpStatusCode.InternalServerError;
                postDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "PostController [GetPublishedPostByID] : " + ex.Message);
            }
            return postDTOs;
        }

        [HttpGet("PublishedPostsByCategory/{category}")]
        public async Task<ApiResponse<ICollection<PostDTO>>> GetPublishedPostByCategory(int category)
        {
            ApiResponse<ICollection<PostDTO>> postDTOs = new ApiResponse<ICollection<PostDTO>>();
            //ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                postDTOs.Result = await _service.GetPublishedPostsByCategory(category);
                //response.Result = await _service.AddPost(post);
                postDTOs.StatusCode = HttpStatusCode.OK;
                postDTOs.Message = StatusMessages.Post_Got;
            }
            catch (Exception ex)
            {
                postDTOs.StatusCode = HttpStatusCode.InternalServerError;
                postDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "PostController [GetPublishedPostByCategory] : " + ex.Message);
            }
            return postDTOs;
        }

        [HttpGet("GetPost")]
        public async Task<ApiResponse<ICollection<JoinDTO>>> GetAllPosts()
        {
            ApiResponse<ICollection<JoinDTO>> joinDTOs = new ApiResponse<ICollection<JoinDTO>>();
            try
            {
                joinDTOs.Result = await _service.GetPosts();
                joinDTOs.StatusCode = HttpStatusCode.OK;
                joinDTOs.Message = StatusMessages.Post_Got;
            }
            catch (Exception ex)
            {
                joinDTOs.StatusCode = HttpStatusCode.InternalServerError;
                joinDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "PostController [GetPublishedPostByActiveUser] : " + ex.Message);
            }
            return joinDTOs;
        }

        [HttpPost("AddPost")]
        public async Task<ApiResponse<bool>> AddPost([FromBody] PostDTO post)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                response.Result = await _service.AddPost(post);
                response.StatusCode = HttpStatusCode.OK;
                response.Message = StatusMessages.Post_Added;
            }
            catch(Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "PostController [AddPost] : " + ex.Message);
            }
            return response;
        }

        [HttpPut("UpdatePost")]
        public async Task<ApiResponse<bool>> UpdatePost([FromBody] PostDTO post)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                response.Result = await _service.UpdatePost(post);
                response.StatusCode = HttpStatusCode.OK;
                response.Message = StatusMessages.Post_Updated;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "PostController [UpdatePost] : " + ex.Message);
            }
            return response;
        }

        [HttpDelete("DeletePost/{id}")]
        public async Task<ApiResponse<bool>> DeletePost(int id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                response.Result = await _service.DeletePost(id);
                if (response.Result == true)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = StatusMessages.Post_Deleted;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = ErrorMessages.Bad_Request;
                }
            }
            catch(Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "PostController [DeletePost] : " + ex.Message);
            }
            return response;
        }

        [HttpDelete("SoftDeletePost")]
        public async Task<ApiResponse<bool>> SoftDeletePost(int id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                response.Result = await _service.SoftDeletePost(id);
                if (response.Result == true)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = StatusMessages.Post_Soft_Deleted;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = ErrorMessages.Bad_Request;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                _logger.LogError(ex, "PostController [SoftDeletePost] : " + ex.Message);
            }
            return response;
        }
    }
}
