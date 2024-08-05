using AutoMapper;
using CRUDAPI.BAL.Services;
using CRUDAPI.DAL.Entity;
using CRUDAPI.DAL.Entity.DTO;
using CRUDAPI.DAL.IRepositories;
using System.Collections.ObjectModel;

namespace CRUDAPI.BAL.IServices
{
    public class UserService : IUserService
    {
        //private readonly object set;
        //private readonly object DbContext;
        //private readonly DbSet<T> DbSet;

        IMapper _mapper;
        IUserRepository _userRepo;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepo = userRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<UserDTO>> GetAllActiveUsers(bool isactive)
        {
            var allActiveUsers = await _userRepo.GetAllAsync(a => a.IsActive == isactive);
            ICollection<UserDTO> users = _mapper.Map<Collection<UserDTO>>(allActiveUsers);
            return users;
        }

        public async Task<ICollection<UserDTO>> GetUserById(int id)
        {
            var userbyid = await _userRepo.GetAllAsync(a => a.Id == id);
            ICollection<UserDTO> users = _mapper.Map<Collection<UserDTO>>(userbyid);

            return users;
        }

        public async Task<ICollection<UserDTO>> GetAllUsers()
        {
            var allUsers = await _userRepo.GetAllUsersAsync();
            ICollection<UserDTO> users = _mapper.Map<Collection<UserDTO>>(allUsers);
            return users;
        }

        public async Task<bool> AddUser(UserDTO user)
        {
            if (user == null) throw new Exception();
            User usr = _mapper.Map<User>(user);
            _userRepo.Add(usr);
            _userRepo.SaveChangesManaged();
            return true;
        }
        public async Task<bool> UpdateUser(UserDTO user)
        {
            if (user == null) throw new Exception();
            User usr = _mapper.Map<User>(user);
            _userRepo.Update(usr);
            _userRepo.SaveChangesManaged();
            return true;
        }
        public async Task<bool> UpdateUserById(int id, UpdateUserDTO user)
        {
            if (user == null) throw new Exception();
            User usr = _mapper.Map<User>(user);
            _userRepo.Update(usr);
            _userRepo.SaveChangesManaged();
            return true;
        }
        public async Task<bool> DeleteUser(int id)
        {
            //if (id == null) throw new Exception();
            User usr = await _userRepo.GetByID(id);
            if (usr == null) return false;
            //_postRepo.Delete(usr);
            //_postRepo.SaveChangesManaged();
            await _userRepo.Delete(usr);
            _userRepo.SaveChangesManaged();
            return true;
        }
        public async Task<bool> SoftDeleteUser(int id)
        {
            User usr = await _userRepo.GetByID(id);
            //if (pst == null) return false;
            if (usr.IsActive == true)
            {
                usr.IsActive = false;
                _userRepo.SaveChangesManaged();
                return true;
            }
            return false;
        }
    }
}
