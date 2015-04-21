using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log.config", Watch = true)]
namespace test.WEB.Common
{
    public class LogHelper
    {
        /// <summary>
        /// 构造器
        /// </summary>
        static LogHelper()
        {
            Init();
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("mylog");

        /// <summary>
        /// 初始化日志系统,在系统运行开始初始化   
        /// </summary>
        private static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();        
        }
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void WriteLog(object msg)
        {
            log.Info(msg);
        }
        /// <summary>
        /// 输出错误到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        public static void WriteError(object msg,Exception ex)
        {            
            log.Error(msg,ex);
        }

    }
}