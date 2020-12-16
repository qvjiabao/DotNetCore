using Autofac;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using QJB.MongoDB.Model;
using QJB.MongoDB.Repository;
using QJB.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QJB.Server.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var IServices = System.Reflection.Assembly.Load("Jabo.IServices");
            var Services = System.Reflection.Assembly.Load("Jabo.Services");
            var IRepository = System.Reflection.Assembly.Load("Jabo.IRepository");
            var Repository = System.Reflection.Assembly.Load("Jabo.Repository");

            //根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(IServices, Services)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces();

            //根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖
            builder.RegisterAssemblyTypes(IRepository, Repository)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces();

            //autoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
            var mapper = config.CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>().SingleInstance();

            builder.RegisterType<LogRepository>().As<IRepository<LogEventData>>();


            //builder.RegisterType<QJB.Server.DicService>().As<Jabo.IServices.IDicService>();

            //builder.Register(c => AppConfigurtaion.Configuration["MongoDBSettings:ConnectionStrings"]).As<DBSettings>();
            //builder.Register(c => AppConfigurtaion.Configuration["MongoDBSettings:AppSettings"]).As<AppSettings>();

        }
    }
}
