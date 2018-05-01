using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp.BLL.Interfaces;
using TestApp.BLL.Services;

namespace TestApp.Util
{
    public class TeacherModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITeacherService>().To<TeacherService>();
        }
    }
}