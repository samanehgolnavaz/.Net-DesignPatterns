namespace Template_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExchangeMailParser exchangeMailParser = new ExchangeMailParser();
            Console.WriteLine(exchangeMailParser.ParseMailBody("bf3a298c-9990-4b02-873d-3d3c98ad16d2"));
            Console.WriteLine();


            ApacheMailParser apacheMailParser = new ApacheMailParser();
            Console.WriteLine(apacheMailParser.ParseMailBody("hyf3a298c-9990-5b02-873d-3d3c98ad16d3"));
            Console.WriteLine();

            EudoraMailParser eudoraMailParser = new EudoraMailParser();
            Console.WriteLine(eudoraMailParser.ParseMailBody("ftf3a298c-8890-4b02-874d-3d3c98ad16d3"));
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}