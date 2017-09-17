using Microsoft.Practices.Unity;
using System.IO.Abstractions;
using System.Web;
using Umbraco.Core;
using Umbraco.Extensions.App_Start;

namespace Umbraco.Extensions.Helpers
{
    public class Versioning
    {
        public static string PathAndChecksum(string filePath)
        {
            var container = UnityConfig.GetConfiguredContainer();
            var versioning = container.Resolve<Versioning>();

            return versioning.PathNChecksum(filePath);
        }

        ApplicationContext _appCtx;
        HttpContextBase _httpCtx;
        IFileSystem _fs;

        public Versioning(ApplicationContext appCtx, HttpContextBase httpCtx, IFileSystem fileSystem)
        {
            _appCtx = appCtx;
            _httpCtx = httpCtx;
            _fs = fileSystem;
        }

        public string PathNChecksum(string filePath)
        {
            return $"{filePath}?v={AppendFileChecksum(filePath)}";
        }

        string AppendFileChecksum(string filePath)
        {
            return _appCtx.ApplicationCache.RuntimeCache.GetCacheItem(filePath, () =>
            {
                var fullFilePath = _httpCtx.Server.MapPath(filePath);

                using (var fileStream = _fs.File.OpenRead(fullFilePath))
                {
                    return CryptoHelpers.GetSHASum(fileStream);
                }

            }).ToString();
        }
    }
}
