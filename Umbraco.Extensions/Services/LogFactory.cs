using log4net;
using System;

namespace Umbraco.Extensions.Services
{
    /// <summary> 
    /// Creates an <see cref="ILog"/> instance for the provided <see cref="Type"/> 
    /// </summary> 
    class LogFactory : ILogFactory
    {
        /// <summary> 
        ///  
        /// </summary> 
        /// <param name="T">Type of class this logger logs for</param> 
        /// <returns></returns> 
        public ILog GetLogger(Type T)
        {
            return LogManager.GetLogger(T);
        }
    }

    /// <summary> 
    /// Creates an <see cref="ILog"/> instance for the provided <see cref="Type"/> 
    /// </summary> 
    public interface ILogFactory
    {
        /// <summary> 
        ///  
        /// </summary> 
        /// <param name="T">Type of class this logger logs for</param> 
        /// <returns></returns> 
        ILog GetLogger(Type T);
    }
}
