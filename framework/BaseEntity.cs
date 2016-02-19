using log4net.Config;

namespace demo.framework
{
    public class BaseEntity
    {
        public static Logger Log;
        protected BaseEntity()
        {
            XmlConfigurator.Configure();
            Log = Logger.GetInstance();

        }
    }
}
