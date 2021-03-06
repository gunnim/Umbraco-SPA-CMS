using Microsoft.Practices.Unity.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Umbraco.Extensions.App_Start.UnityActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Umbraco.Extensions.App_Start.UnityActivator), "Shutdown")]

namespace Umbraco.Extensions.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET</summary> 
    static class UnityActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary> 
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}
