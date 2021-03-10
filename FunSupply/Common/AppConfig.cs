using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunSupply.Common
{
    public class AppConfig
    {
        public static bool ACCEPT_WORKER = false;

        public static bool[] STATUS_DRIVERS = { false,false };
        

        public static Log.SimpleLog logger;
        public static Log.SimpleLog getLog()
        {
            if (logger == null)
            {
                logger = new Log.FileLog();
            }
            return AppConfig.logger;
        }
    }
}
