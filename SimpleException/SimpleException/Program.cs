using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SimpleException
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Exception Example *****");
            Console.WriteLine("=> Creating a car and stepping on it!");

            var myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);
            try
            {
                for (var i = 0; i < 10; i++)
                {
                    myCar.Accelerate(10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n*** Error! ***");
                Console.WriteLine("Method: {0}", ex.TargetSite);
                Console.WriteLine("Class defining member: {0}", ex.TargetSite.DeclaringType);
                Console.WriteLine("Member type: {0}", ex.TargetSite.MemberType);
                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("Source: {0}", ex.Source);
                Console.WriteLine("Stack: {0}", ex.StackTrace);
                Console.WriteLine("Help Link: {0}", ex.HelpLink);

                Console.WriteLine("\n-> Custom Data:");
                foreach (DictionaryEntry de in ex.Data)
                    Console.WriteLine("-> {0}: {1}", de.Key, de.Value);
            }

            Console.ReadLine();
        }
    }

    internal class Radio
    {
        public void TurnOn(bool on)
        {
            if (on)
                Console.WriteLine("Jamming...");
            else
                Console.WriteLine("Quiet time...");
        }
    }

    internal class Car
    {
        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        private bool _carIsDead;
        private Radio _theMusicBox = new Radio();
        public Car() { }

        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            _theMusicBox.TurnOn(state);
        }

        public void Accelerate(int delta)
        {
            if (_carIsDead)
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    _carIsDead = true;
                    CurrentSpeed = 0;
                    var ex = new Exception(string.Format("{0} has overheated!", PetName));
                    ex.HelpLink = "http://www.CarsRUs.com";

                    ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }

}
