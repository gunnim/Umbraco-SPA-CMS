using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;
using React;
using System.Configuration;
using System.Web.Configuration;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Umbraco.Site.ReactConfig), "Configure")]

namespace Umbraco.Site
{
    public static class ReactConfig
    {
        public static void Configure()
        {
            JsEngineSwitcher.Instance.DefaultEngineName = V8JsEngine.EngineName;

            CompilationSection compilationSection =
                (CompilationSection)ConfigurationManager.GetSection("system.web/compilation");

            if (compilationSection.Debug)
            {
                ReactSiteConfiguration.Configuration
                                      .SetLoadBabel(false)
                                      .SetLoadReact(false)
                                      .SetReuseJavaScriptEngines(false)
                                      //.DisableServerSideRendering()
                                      .SetUseDebugReact(true)
                                      .AddScriptWithoutTransform("~/scripts/server.js");
            }
            else
            {
                ReactSiteConfiguration.Configuration
                                      .SetLoadBabel(false)
                                      .SetLoadReact(false)
                                      .AddScriptWithoutTransform("~/scripts/server.min.js");
            }
        }
    }
}
