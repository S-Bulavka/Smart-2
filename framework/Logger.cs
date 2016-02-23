using System;
using log4net;

namespace demo.framework
{

    public class Logger
    {
        private static Logger _instance;

        private readonly ILog _logger;
        private int _stepNumber =0;
        private Logger(ILog logger)
        {
            this._logger = logger;
        }

        public static Logger GetInstance()
        {
            if(_instance == null){
                lock (typeof(Logger))
                {
                    if (_instance == null)
                        _instance = new Logger(LogManager.GetLogger(typeof(BaseEntity)));
                }
            } 
            return _instance;
        }

        public void Step()
        {
            _stepNumber++;
            _logger.Info("== Step " + _stepNumber + " ==");
        }

        public void Info(string info)
        {
            _logger.Info(info);
        }

        public void Fatal(string fatal)
        {
            _logger.Fatal(fatal);
        }
    }
}
