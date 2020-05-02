using System;
using System.Linq;
using AutoMapper;
using edusent_service.Models;
using edusent_service.Models.ViewModels;
using System.Collections.Generic;

namespace edusent_service.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserInfoViewModel>()
            .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserName));
            

        }
    }
}