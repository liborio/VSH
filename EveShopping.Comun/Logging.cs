using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Comun
{
    public class Logging
    {
        private static ILog m_logger;

        public static ILog Logger
        {
            get
            {
                return m_logger;
            }
            private set
            {
                m_logger = value;
            }
        }

        static Logging()
        {
            Logger = LogManager.GetLogger("miLogger");
        }

        
       
    }
}
