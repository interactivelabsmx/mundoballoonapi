using System.Linq;
using AutoMapper;
using MundoBalloonApi.infrastructure.Data.Models;
using MundoBalloonApi.business.Dtos;

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
