using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAppDomains
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun With Custom AppDomains *****\n");

            var defaultAd = AppDomain.CurrentDomain;
            defaultAd.ProcessExit += (o, s) => { Console.WriteLine("Default AD unloaded!"); };
            ListAllAssembliesInAppDomain(defaultAd);
            MakeNewAppDomain();

            Console.ReadLine();
        }

        private static void MakeNewAppDomain()
        {
            var newAd = AppDomain.CreateDomain("SecondAppDomain");
            newAd.DomainUnload += (o, s) => { Console.WriteLine("The second AppDomain has been unloaded!"); };
            try
            {
                newAd.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ListAllAssembliesInAppDomain(newAd);
            AppDomain.Unload(newAd);
        }

        private static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            var loadedAssemblies = from a in ad.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;

            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n", ad.FriendlyName);

            foreach (var a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }

    }
}
