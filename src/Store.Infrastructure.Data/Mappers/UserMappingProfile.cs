using AutoMapper;
using Store.Domain;
using Store.Infrastructure.Data.Entities;

namespace Store.Infrastructure.Data.Mappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserEntity, User>().ReverseMap();
    }
}