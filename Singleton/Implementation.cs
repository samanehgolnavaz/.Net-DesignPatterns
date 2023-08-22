using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{

    /// <summary>
    /// Singleton
    /// </summary>
    public class Logger
    {
        //Lazy<T>
        private static readonly Lazy<Logger> LazyLogger
            = new Lazy<Logger>(() => new Logger());

       // private static Logger? _instance;

        public static Logger Instance
        {

            get
            {
                return LazyLogger.Value;
                //if (_instance==null)
                //{
                //    _instance=new Logger();
                //}
                //return _instance;
            } 
        }
        protected Logger()
        {
            
        }

        public void Log(string message)
        {
            Console.WriteLine($"Message to log :{message}");
        }
    }
}
