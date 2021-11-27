using AutoMapper;
using ProxNetChallenge.Entities;

namespace ProxNetChallenge.MapperProffiles
{
    public class PlayerMapperProfile : Profile
    {
        public PlayerMapperProfile()
        {
            CreateMap<PlayerEntity, LobbyPlayerEntity>().ForMember().ReverseMap();
        }
    }
}
