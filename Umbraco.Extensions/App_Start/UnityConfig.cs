using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.IO.Abstractions;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Extensions.Services;
using Umbraco.Web;
using Umbraco.Web.HealthCheck;
using Umbraco.Web.Trees;

namespace Umbraco.Extensions.App_Start
{
    /// <summary> 
    /// Specifies the Unity configuration for the main container. 
    /// </summary> 
    static class UnityConfig
    {
        #region Unity Container 
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary> 
        /// Gets the configured Unity container. 
        /// </summary> 
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary> 
        /// <param name="container">The unity container to configure.</param> 
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to  
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks> 
        public static void RegisterTypes(IUnityContainer container)
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Microsoft.Practices.Unity.WebApi.UnityDependencyResolver(container);

            DependencyResolver.SetResolver(new Microsoft.Practices.Unity.Mvc.UnityDependencyResolver(container));

            container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(UnityConfig).Assembly),
                WithMappings.FromMatchingInterface,
                WithName.Default
            );

            container.RegisterType<ApplicationContext>(new InjectionFactory(c => ApplicationContext.Current));

            container.RegisterType<HttpContextBase>(new PerRequestLifetimeManager(), new InjectionFactory(c => new HttpContextWrapper(HttpContext.Current)));
            container.RegisterType<UmbracoContext>(new PerRequestLifetimeManager(), new InjectionFactory(c => UmbracoContext.Current));
            container.RegisterType<UmbracoHelper>(new PerRequestLifetimeManager(), new InjectionConstructor(typeof(UmbracoContext)));
            container.RegisterType<HealthCheckController>(new InjectionConstructor());
            container.RegisterType<LegacyTreeController>(new InjectionConstructor());

            container.RegisterType<ILogFactory, LogFactory>();
            container.RegisterType<IFileSystem, FileSystem>();
            container.RegisterType<Settings>(new ContainerControlledLifetimeManager());
        }
    }
}
