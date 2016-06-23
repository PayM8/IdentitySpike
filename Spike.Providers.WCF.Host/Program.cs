
namespace Spike.Providers.WCF.Host
{
    using System;
    using System.Linq;
    using System.ServiceModel;

    public class Program
    {
        public static void Main(string[] args)
        {
            var servicehost = new ServiceHost(typeof(BookProviderService));
            try
            {
                servicehost.Open();

                Console.WriteLine("*** N-Tier: Provider Service ***");
                Console.WriteLine();
                Console.WriteLine(servicehost.Description.Endpoints.First().Address);
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to exit.");
                Console.ReadLine();

                servicehost.Close();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message);
                Console.Read();
            }
        }
    }
}
