using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{
    public class CarEventArgs
    {
        public readonly string msg;

        public CarEventArgs(string message)
        {
            msg = message;
        }
    }
}
