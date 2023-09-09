using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Decorator
{
    /// <summary>
    /// Component(as interface)
    /// </summary>
    public  interface IMailService
    {
        bool SendMail(string message);
    }
    /// <summary>
    /// ConcreteComponent1
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message  {message} sent via {nameof(CloudMailService)}.");
            return true;
        }
    }
    /// <summary>
    /// ConcreteComponent2
    /// </summary>
    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message  {message} sent via {nameof(OnPremiseMailService)}.");
            return true;
        }
    }
    /// <summary>
    /// Decorator
    /// </summary>
    public abstract class MailServiceDecoratorBase: IMailService
    {
        private readonly IMailService _mailService;
        public MailServiceDecoratorBase(IMailService mailService)
        {

            _mailService = mailService;

        }
        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }
    /// <summary>
    /// ConcreteDecorator1
    /// </summary>
    public class StatisticDecorator : MailServiceDecoratorBase
    {
        public StatisticDecorator(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            //Fake collecting statistics
            Console.WriteLine($"collecting statistics in {nameof(StatisticDecorator)}");
            return base.SendMail(message);
        }
    }
    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> SendMessages { get; private set; } = new List<string>();
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            if (base.SendMail(message))
            {
                //store send message
                SendMessages.Add(message);
                return true;
            }
            return false;
        }
    }
}
