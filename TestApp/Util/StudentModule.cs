using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp.BLL.Interfaces;
using TestApp.BLL.Services;

namespace TestApp.Util
{
    public class StudentModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudentService>().To<StudentService>();
        }
    }
}