using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Social_Network.Core;
using Social_Network.Core.Interfaces.IRepositories.Base;
using Social_Network.Core.Interfaces.IRepositories;
using Social_Network.Data;
using Social_Network.Data.Repositoties;

namespace Social_Network.Web.Infrastructure.Installers
{ 
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(IRepository<>)).LifeStyle.PerWebRequest,
                Component.For(typeof(IDataContext)).ImplementedBy<DataContext>().LifeStyle.PerWebRequest
                );
        }
    }
}