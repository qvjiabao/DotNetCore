using QJB.Models;
using QJB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QJB.Server.Profile
{
    public class AutoMapperProfile : AutoMapper.Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<MenuModel, MenuVModel>();

            CreateMap<MenuModel, MenuTreeVModel>()
                .ForMember(dest => dest.id, opts => opts.MapFrom(src => src.MenuGuid));

            CreateMap<MenuTreeVModel, MenuModel>()
                .ForMember(dest => dest.MenuGuid, opts => opts.MapFrom(src => src.id));

            CreateMap<UserModel, UserVModel>();
            CreateMap<RoleModel, RoleVModel>();
            CreateMap<OrderZWYSModel, OrderZWYSVModel>();

            CreateMap<DicTypeModel, DicTypeVModel>()
                .ForMember(dest => dest.id, opts => opts.MapFrom(src => src.DicTypeCode))
                .ForMember(dest => dest.title, opts => opts.MapFrom(src => src.DicTypeName));
            CreateMap<DicModel, DicVModel>();

            CreateMap<JDItineraryModel, JDItineraryVModel>();
            CreateMap<JDItineraryCostModel, JDItineraryCostVModel>();
            CreateMap<OrderJDModel, OrderJDVModel>();
        }
    }
}