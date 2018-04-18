using MyNiceHome.BusinessManager;
using MyNiceHome.BusinessManager.Interfaces;
using MyNiceHome.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MyNiceHome_Feb18_API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserUtility, UserUtility>();
            container.RegisterType<IRepositoryUtility, RepositoryUtility>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}