using CRUDAPI.DAL.Entity;
using AutoMapper;
using CRUDAPI.DAL.Entity.DTO;

namespace CRUDAPI.Helper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            //CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<Post, JoinDTO>().ReverseMap();
            CreateMap<User, JoinDTO>().ReverseMap();
        }
    }
}
