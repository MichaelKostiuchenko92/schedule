using Ninject.Modules;
using TestApp.BLL.Interfaces;
using TestApp.BLL.Services;
using TestApp.Domain;
using TestApp.Domain.Interfaces;

namespace TestApp.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connection;
        public ServiceModule(string connection)
        {
            this.connection = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connection);
            //Bind<>
        }
    }
}
