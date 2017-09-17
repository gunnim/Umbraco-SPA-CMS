using log4net;
using System.Net.Http;
using System.Text;
using System.Web.Http.ExceptionHandling;

namespace Umbraco.Extensions
{
    class GlobalExceptionLogger : ExceptionLogger
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(GlobalExceptionLogger));

        public override void Log(ExceptionLoggerContext context)
        {
            Logger.Error(RequestToString(context.Request), context.Exception);
        }

        private string RequestToString(HttpRequestMessage request)
        {
            var message = new StringBuilder();
            if (request.Method != null)
                message.Append(request.Method);

            if (request.RequestUri != null)
                message.Append(" ").Append(request.RequestUri);

            message.Append(" ");

            return message.ToString();
        }
    }
}
