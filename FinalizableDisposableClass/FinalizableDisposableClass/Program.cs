using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Dispose() / Destructor Combo Platter * ****");
            // Call Dispose() manually. This will not call the finalizer.
            var rw = new MyResourceWrapper();
            rw.Dispose();
            // Don’t call Dispose(). This will trigger the finalizer
            // and cause a beep.
            var rw2 = new MyResourceWrapper();
        }
    }
}
