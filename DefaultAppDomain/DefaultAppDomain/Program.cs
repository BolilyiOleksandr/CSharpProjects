using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DefaultAppDomain
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the default AppDomain *****\n");
            DisplayDadStats();
            ListAllAssembliesInAppDomain();
            InitDad();

            Console.ReadLine();
        }

        private static void DisplayDadStats()
        {
            var defauldAd = AppDomain.CurrentDomain;
            Console.WriteLine("Name of this domain: {0}", defauldAd.FriendlyName);
            Console.WriteLine("ID of domain in this process: {0}", defauldAd.Id);
            Console.WriteLine("Is this the default domain?: {0}", defauldAd.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defauldAd.BaseDirectory);
        }

        private static void ListAllAssembliesInAppDomain()
        {
            var defaultAd = AppDomain.CurrentDomain;
            //var loadedAssemblies = defaultAd.GetAssemblies();
            var loadedAssemblies = from a in defaultAd.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;

            Console.WriteLine("\n\r***** Here are the assemblies loaded in {0} *****\n", defaultAd.FriendlyName);

            foreach (Assembly a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }

        private static void InitDad()
        {
            var defaultAd = AppDomain.CurrentDomain;
            defaultAd.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("\r\n{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };
        }

    }
}
