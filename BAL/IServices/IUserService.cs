using CRUDAPI.DAL.Entity.DTO;
using System.Collections.ObjectModel;

namespace CRUDAPI.BAL.Services
{
    public interface IUserService
    {
        public Task<ICollection<UserDTO>> GetAllActiveUsers(bool isactive);
        //public Task<ICollection<UserDTO>> GetAllActiveUsers();
        public Task<bool> AddUser(UserDTO user);
        public Task<bool> UpdateUser(UserDTO user);
        public Task<bool> UpdateUserById(int id, UpdateUserDTO user);
        //public Task<bool> DeleteUser(UserDTO user);
        public Task<bool> DeleteUser(int id);
        public Task<ICollection<UserDTO>> GetAllUsers();
        public Task<ICollection<UserDTO>> GetUserById(int id);
        public Task<bool> SoftDeleteUser(int id);
    }
}
