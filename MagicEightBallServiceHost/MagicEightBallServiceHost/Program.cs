using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MagicEightBallService;

namespace MagicEightBallServiceHost
{
    public static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Console Based WCF Host *****\n");

            using (var serviceHost = new ServiceHost(typeof(MagicEightBallService.MagicEightBallService)))
            {
                serviceHost.Open();
                DisplayHostInfo(serviceHost);
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press the Enter key to terminate service.");
                Console.ReadLine();
            }
        }

        private static void DisplayHostInfo(ServiceHostBase host)
        {
            Console.WriteLine("\n***** Host Info *****");

            foreach (var se in host.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("Binding: {0}", se.Binding?.Name);
                Console.WriteLine("Contract: {0}", se.Contract.Name);
            }

            Console.WriteLine("\n**********************************************");
        }

    }
}
