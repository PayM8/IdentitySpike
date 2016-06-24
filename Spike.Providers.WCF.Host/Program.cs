
namespace Spike.Providers.WCF.Host
{
    using System;
    using System.Linq;
    using System.ServiceModel;

    public class Program
    {
        public static void Main(string[] args)
        {
            var bookHost = new ServiceHost(typeof(BookProviderService));
            var securityHost = new ServiceHost(typeof(SecurityProviderService));

            try
            {
                bookHost.Open();
                securityHost.Open();

                Console.WriteLine("*** N-Tier: Provider Service ***");
                Console.WriteLine();
                Console.WriteLine(bookHost.Description.Endpoints.First().Address);
                Console.WriteLine(securityHost.Description.Endpoints.First().Address);
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to exit.");
                Console.ReadLine();

                bookHost.Close();
                securityHost.Close();
            }
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message);
                Console.Read();
            }
        }
    }
}
