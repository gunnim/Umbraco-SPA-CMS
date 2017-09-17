using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace Umbraco.Extensions
{
    /// <summary>
    /// Handles server side routing for React Router
    /// </summary>
    public class ContentFinder : IContentFinder
    {
        static IPublishedContent homeNode;

        static ContentFinder()
        {
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

            homeNode = umbracoHelper.TypedContentAtRoot().First();
        }

        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            // Catch all requests and leave to React Router to handle
            contentRequest.PublishedContent = homeNode;
            return true;
        }
    }
}
