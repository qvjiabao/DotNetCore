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
            CreateMap<MenuModel, MenuVModel>();
        }
    }
}