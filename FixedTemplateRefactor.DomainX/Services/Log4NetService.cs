using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedTemplateRefactor.DomainX.Services
{
    /// <summary>
    ///  simple wrapper around Logger to reduce duplication of enabled checks
    ///  note only this service should be static.  All other services should be instanced 
    ///  and injected in as normal.
    /// </summary>
    public static class Log4NetService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Log4NetService));

        static Log4NetService()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void DebugLogIfEnabled(String message)
        {
            if (log.IsDebugEnabled && !string.IsNullOrEmpty(message))
            {
                log.Debug(message);
            }
        }
    }
}
