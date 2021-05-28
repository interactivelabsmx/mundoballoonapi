using AutoMapper;
using MundoBalloonApi.business.DTOs.Requests;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.business.Middleware
{
    public class RequestsMappingProfile : Profile
    {
        public RequestsMappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
        }
    }
}