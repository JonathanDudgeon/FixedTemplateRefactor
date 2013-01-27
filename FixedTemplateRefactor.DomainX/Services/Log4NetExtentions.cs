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
    public static class Log4NetExtentions
    {
        public static void DebugLogIfEnabled(this ILog logger, String message)
        {
            if (logger.IsDebugEnabled && !string.IsNullOrEmpty(message))
            {
                logger.Debug(message);
            }
        }
    }
}
