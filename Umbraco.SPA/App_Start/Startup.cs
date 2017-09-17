using Umbraco.Core;
using Umbraco.Extensions.App_Start;
using Umbraco.Web.Routing;

namespace Umbraco.Extensions
{
    /// <summary> 
    /// Hooks into the umbraco application startup lifecycle  
    /// </summary> 
    class Startup : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase httpApplication, ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarting(UmbracoApplicationBase httpApplication, ApplicationContext applicationContext)
        {
            ContentFinderResolver.Current.InsertType<ContentFinder>();
        }

        /// <summary> 
        /// Umbraco lifecycle method 
        /// </summary> 
        /// <param name="httpApplication"></param> 
        /// <param name="applicationContext"></param> 
        public void OnApplicationStarted(UmbracoApplicationBase httpApplication, ApplicationContext applicationContext)
        {
            // Register Types 
            var container = UnityConfig.GetConfiguredContainer();
        }
    }
}
