using CRUDAPI.BAL.IServices;
using CRUDAPI.BAL.Services;
using CRUDAPI.DAL.Entity.DTO;
using CRUDAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Net;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger _logger;
        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("AllUsers")]
        public async Task<ApiResponse<ICollection<UserDTO>>> GetUser()
        {
            ApiResponse<ICollection<UserDTO>> userDTOs = new ApiResponse<ICollection<UserDTO>>();
            try
            {
                userDTOs.Result = await _service.GetAllUsers();
                userDTOs.StatusCode = HttpStatusCode.OK;
                userDTOs.Message = StatusMessages.User_Got;
            }
            catch (Exception ex)
            {
                userDTOs.StatusCode = HttpStatusCode.InternalServerError;
                userDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [GetUser] : " + ex.Message);
            }
            return userDTOs;
        }

        [HttpGet("UserById/{id}")]

        public async Task<ApiResponse<ICollection<UserDTO>>> GetUsersById(int id)
        {
            ApiResponse<ICollection<UserDTO>> userDTOs = new ApiResponse<ICollection<UserDTO>>();
            try
            {
                userDTOs.Result = await _service.GetUserById(id);
                userDTOs.StatusCode = HttpStatusCode.OK;
                userDTOs.Message = StatusMessages.User_Got;
            }
            catch (Exception ex)
            {
                userDTOs.StatusCode = HttpStatusCode.InternalServerError;
                userDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [GetActiveUser] : " + ex.Message);
            }
            return userDTOs;
        }

        [HttpGet("AllActiveUsers/{isactive}")]

        public async Task<ApiResponse<ICollection<UserDTO>>> GetActiveUser(bool isactive)
        {
            ApiResponse<ICollection<UserDTO>> userDTOs = new ApiResponse<ICollection<UserDTO>>();
            try
            {
                userDTOs.Result = await _service.GetAllActiveUsers(isactive);
                userDTOs.StatusCode = HttpStatusCode.OK;
                userDTOs.Message = StatusMessages.User_Got;
            }
            catch (Exception ex)
            {
                userDTOs.StatusCode = HttpStatusCode.InternalServerError;
                userDTOs.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [GetActiveUser] : " + ex.Message);
            }
            return userDTOs;
        }

        [HttpPost("AddUser")]
        public async Task<ApiResponse<bool>> AddUser([FromBody] UserDTO user)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                response.Result = await _service.AddUser(user);
                response.StatusCode = HttpStatusCode.OK;
                response.Message = StatusMessages.User_Added;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [AddUser] : " + ex.Message);
            }
            return response;
        }
        
        [HttpPut("UpdateUser")]
        public async Task<ApiResponse<bool>> UpdateUser([FromBody] UserDTO user)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                response.Result = await _service.UpdateUser(user);
                response.StatusCode = HttpStatusCode.OK;
                response.Message = StatusMessages.User_Updated;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [UpdateUser] : " + ex.Message);
            }
            return response;
        }

        [HttpPut("UpdateUserById/{id}")]
        public async Task<ApiResponse<bool>> UpdateUserById(int id, [FromBody] UpdateUserDTO user)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                response.Result = await _service.UpdateUserById(id, user);
                response.StatusCode = HttpStatusCode.OK;
                response.Message = StatusMessages.User_Updated;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [UpdateUser] : " + ex.Message);
            }
            return response;
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ApiResponse<bool>> DeleteUser(int id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                response.Result = await _service.DeleteUser(id);
                if (response.Result == true)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = StatusMessages.User_Deleted;
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
                response.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [DeleteUser] : " + ex.Message);
            }
            return response;
        }

        [HttpDelete("SoftDeleteUser")]
        public async Task<ApiResponse<bool>> SoftDeleteUser(int id)
        {
            ApiResponse<bool> response = new ApiResponse<bool>();
            try
            {
                response.Result = await _service.SoftDeleteUser(id);
                if (response.Result == true)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = StatusMessages.User_Soft_Deleted;
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
                response.Message = ErrorMessages.Internal_Server_Error;
                _logger.LogError(ex, "UserController [SoftDeleteUser] : " + ex.Message);
            }
            return response;
        }
    }
}
