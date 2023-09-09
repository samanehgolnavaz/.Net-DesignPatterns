namespace _03_Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {   //instantiate mail services
            var cloudMailService=new CloudMailService();
            cloudMailService.SendMail("Hi there");
            var onPermiseMailService=new OnPremiseMailService();
            onPermiseMailService.SendMail("Hi there.");
            // add behavior
            var statisticsDecorator = new StatisticDecorator(cloudMailService);
            statisticsDecorator.SendMail($"Hi there via {nameof(StatisticDecorator)}wrapper.");
            //add behavior
            var messageDatabaseDecorator = new MessageDatabaseDecorator(onPermiseMailService);
            messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)}wrapper,message 1.");
             messageDatabaseDecorator = new MessageDatabaseDecorator(onPermiseMailService);
            messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)}wrapper,message 2.");

            foreach (var message in messageDatabaseDecorator.SendMessages)
            {
                Console.WriteLine($"Stored message: \"{message}");
            }
            Console.ReadKey();
      
        }
    }
}