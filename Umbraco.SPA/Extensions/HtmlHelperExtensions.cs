using System.Web;
using System.Web.Mvc;
using Umbraco.Extensions.Helpers;

namespace Umbraco.SPA.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString UmbracoSPAInit(this HtmlHelper helper)
        {
            var isDebug = HttpContext.Current.IsDebuggingEnabled;
            var scriptPath = isDebug ? "/scripts/client.js" : "/scripts/client.min.js";
            var pathAndChecksum = Versioning.PathAndChecksum(scriptPath);

            return new HtmlString($@"<script src=""{pathAndChecksum}""></script>");
        }
    }
}
