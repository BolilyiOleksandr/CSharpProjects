using System;

namespace Greenbyte.CurtailmentProviderAssignment
{
    internal class Program
    {
        private readonly VestasCurtailmentProvider _vestas = new VestasCurtailmentProvider();
        private static void Main(string[] args)
        {
            var program = new Program();

            var standardLevel = program._vestas.GetStandardLevel(TurbineCurtailment.Default);
            Console.WriteLine($"Turbine curtailment noise level is {standardLevel}.");

            program._vestas.SetCustomLevel(TurbineCurtailment.Noise, 0.24);
            program._vestas.SetCustomLevel(TurbineCurtailment.Bats, 0.13);
            program._vestas.SetCustomLevel(TurbineCurtailment.Shadow, 0.09);
            program._vestas.SetCustomLevel(TurbineCurtailment.BoatAction, 0.03);
            program._vestas.SetCustomLevel(TurbineCurtailment.Technical, 0.02);
            program._vestas.SetCustomLevel(TurbineCurtailment.Grid, 0.06);

            var level = program._vestas.GetLevel(TurbineCurtailment.Bats, DateTime.Now.ToUniversalTime());
            Console.WriteLine($"Level is {level}.");

            var currentLevel = program._vestas.GetCurrentLevel(TurbineCurtailment.BoatAction);
            Console.WriteLine($"Current level is {currentLevel}.");

            Console.ReadLine();
        }
    }
}
