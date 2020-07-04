using AutoMapper;
using Jabo.Core.ViewModels;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jabo.Core.Config
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile") { }

        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<MenuModel, MenuVModel>()
                .ForMember(dest => dest.href, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.child, opts => opts.MapFrom(src => src.Children));

            CreateMap<MenuModel, MenuTreeVModel>()
                .ForMember(dest => dest.id, opts => opts.MapFrom(src => src.MenuGuid));

            CreateMap<MenuTreeVModel, MenuModel>()
                .ForMember(dest => dest.MenuGuid, opts => opts.MapFrom(src => src.id));

            CreateMap<UserModel, UserVModel>();
            CreateMap<RoleModel, RoleVModel>();
            CreateMap<OrderZWYSModel, OrderZWYSVModel>();
        }
    }
}