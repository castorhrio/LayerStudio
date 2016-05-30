
namespace LayerStudio.Logging
{
    public static class Log
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Info(string message, object owner)
        {
            var log = log4net.LogManager.GetLogger(owner.GetType());
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
            log = null;
        }

        public static void Error(string message, object owner)
        {
            var log = log4net.LogManager.GetLogger(owner.GetType());
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
            log = null;
        }

        public static void Debug(string message, object owner)
        {
            var log = log4net.LogManager.GetLogger(owner.GetType());
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
            log = null;
        }
    }
}
