using Domain.DTO;
using Domain.Entities;

namespace Core.Profile
{
    public class UserProfile : AutoMapper.Profile
    {

        public UserProfile()
        {

            CreateMap<Users, UsuarioRequest>()
             .ReverseMap();

            CreateMap<UserSp, UsuarioResponse>()
          .ReverseMap();


        }
    }
}
