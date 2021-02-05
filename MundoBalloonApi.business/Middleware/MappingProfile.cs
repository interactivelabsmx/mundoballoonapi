using AutoMapper;
using MundoBalloonApi.business.Dtos;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.business.Middleware
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserProfileRequest, UserProfile>();
        }
    }
}