using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Method
{
    /// <summary>
    /// Abstract Class
    /// </summary>
    public abstract class MailServer
    {
        public virtual void FindServer()
        {
            Console.WriteLine("Find server...");
        }
        public abstract void AuthenticationToServer();
        public string ParseHtmlMailBody(string identifier)
        {
            Console.WriteLine("Parsing HTML mail body ...");
            return $"This is the body of mail with id {identifier}";
        }
        /// <summary>
        /// Template Metgod
        /// </summary>
        public string ParseMailBody(string identifier)
        {
            Console.WriteLine("Parsing mail body (in template method)...");
            FindServer();
            AuthenticationToServer();
            return ParseHtmlMailBody(identifier);
        }
    }

    public class ExchangeMailParser : MailServer
    {
        public override void AuthenticationToServer()
        {
            Console.WriteLine("Connecting to Exchange");
        }
    }
    public class ApacheMailParser:MailServer
    {
        public override void AuthenticationToServer()
        {
            Console.WriteLine("Connecting to Apache");
        }
    }
    public class EudoraMailParser : MailServer
    {
        public override void FindServer()
        {
            Console.WriteLine("Finding Eudora server through a custom algorithm...");
        }
        public override void AuthenticationToServer()
        {
            Console.WriteLine("Conneting to Eudora");
        }
    }
}
