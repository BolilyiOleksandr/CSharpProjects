using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions
{
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
            if (delta < 0)
                throw new ArgumentOutOfRangeException("delta", "Speed must be greater than zero!");
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

                    ex = new CarIsDeadException(string.Format("{0} has overheated!", PetName), "You have a lead foot", DateTime.Now);
                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
