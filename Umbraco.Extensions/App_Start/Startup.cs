using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Umbraco.Core;
using Umbraco.Extensions.App_Start;

namespace Umbraco.Extensions
{
    /// <summary> 
    /// Hooks into the umbraco application startup lifecycle  
    /// </summary> 
    class Startup : IApplicationEventHandler
    {
        /// <summary> 
        /// Umbraco lifecycle method 
        /// </summary> 
        /// <param name="httpApplication"></param> 
        /// <param name="applicationContext"></param> 
        public void OnApplicationStarted(UmbracoApplicationBase httpApplication, ApplicationContext applicationContext)
        {
            GlobalConfiguration.Configure(config =>
            {
                config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());
            });

            // Register Types 
            var container = UnityConfig.GetConfiguredContainer();
        }

        public void OnApplicationInitialized(UmbracoApplicationBase httpApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarting(UmbracoApplicationBase httpApplication, ApplicationContext applicationContext)
        {
        }

    }
}
