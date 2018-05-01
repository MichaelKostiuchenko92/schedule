using AutoMapper;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.BLL.Mapping;
using TestApp.Domain.Entities;
using TestApp.ViewModels.Models;

namespace TestApp.BLL.Infrastructure
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValueResolver<StudentView, Student, bool>>();
            Bind<IValueResolver<TeacherView, Teacher, bool>>();

            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            Bind<IMapper>().ToMethod(ctx =>
            new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddProfile(new StudentMappingProfile());
                cfg.AddProfile(new TeacherMappingProfile());
            });

            return config;
        }
    }
}