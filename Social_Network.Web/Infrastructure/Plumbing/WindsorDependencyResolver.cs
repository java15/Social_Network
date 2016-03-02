using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Castle.Windsor;

namespace Social_Network.Web.Infrastructure.Plumbing
{
    public class WindsorDependencyResolver : IDependencyResolver,IDisposable
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            this._container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch 
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return (IEnumerable<object>) _container.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

       public void Dispose()
        {
            _container.Dispose(); 
        }
    }
}