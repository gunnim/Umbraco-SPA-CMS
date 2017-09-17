using System.Configuration;

namespace Umbraco.Extensions
{
    public class Settings
    {
        public const string ConnectionStringName = "umbracoDbDsn";

        public virtual string Email { get; } = ConfigurationManager.AppSettings["MinLidan.Email"];
    }
}
