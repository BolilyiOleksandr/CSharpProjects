using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Handling Multiple Exceptions *****\n");
            var myCar = new Car("Rusty", 90);
            try
            {
                myCar.Accelerate(-10);
            }
            //catch (CarIsDeadException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            catch (CarIsDeadException e) when
                (e.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
            {
                Console.WriteLine("Something bad happenned...");
            }
            finally
            {
                myCar.CrankTunes(false);
            }

            Console.ReadLine();
        }
    }
}
