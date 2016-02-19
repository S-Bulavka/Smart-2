using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace demo.framework
{

    public class Logger
    {
        private static Logger instance;

        private ILog logger;
        private int stepNumber =0;
        private Logger(ILog logger)
        {
            this.logger = logger;
        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                lock (typeof(Logger))
                {
                    if (instance == null)
                        instance = new Logger(LogManager.GetLogger(typeof(BaseEntity)));
                }
            }
 
            return instance;
        }


        public void Step()
        {
            stepNumber++;
            logger.Info("== Step " + stepNumber + " ==");
        }

        public void Info(String info)
        {
            logger.Info(info);
        }

        public void Fatal(String fatal)
        {
            logger.Fatal(fatal);
        }
    }
}
