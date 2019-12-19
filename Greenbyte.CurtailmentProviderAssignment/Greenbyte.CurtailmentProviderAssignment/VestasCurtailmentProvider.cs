using System;
using System.Collections.Generic;
using System.Linq;

namespace Greenbyte.CurtailmentProviderAssignment
{
    /// <summary>
    /// Enum for different kinds of turbine curtailment. Curtailment occurs when the power plant
    /// is not allowed to output energy and can imply total shutdown or a reduced power output.
    /// </summary>
    public enum TurbineCurtailment
    {
        Default,
        Noise,
        Bats,
        Shadow,
        BoatAction,
        Technical,
        Grid,
    }

    internal class VestasCurtailmentProvider : ITurbineCurtailmentProvider
    {
        private static readonly Dictionary<TurbineCurtailment, Tuple<DateTime, double>> CustomLevels = new Dictionary<TurbineCurtailment, Tuple<DateTime, double>>();
        public double GetStandardLevel(TurbineCurtailment curtailment)
        {
            var standardLevel = 0.0;

            switch (curtailment)
            {
                case TurbineCurtailment.Default:
                    standardLevel = 0.0;
                    break;
                case TurbineCurtailment.Noise:
                    standardLevel = 0.25;
                    break;
                case TurbineCurtailment.Bats:
                    standardLevel = 0.15;
                    break;
                case TurbineCurtailment.Shadow:
                    standardLevel = 0.1;
                    break;
                case TurbineCurtailment.BoatAction:
                    standardLevel = 0.05;
                    break;
                case TurbineCurtailment.Technical:
                    standardLevel = 0.05;
                    break;
                case TurbineCurtailment.Grid:
                    standardLevel = 0.05;
                    break;
                default:
                    standardLevel = 0.0;
                    break;
            }

            return standardLevel;
        }

        /// <remarks>
        /// When set, the method saves the curtailment level information for the current timestamp in UTC for later retrieval.
        /// 
        /// Each instance of this object supports a different set of custom levels since we run one thread per customer.
        /// For now we just save it in memory but will use a database later.
        /// </remarks>
        public void SetCustomLevel(TurbineCurtailment curtailment, double level)
        {
            var customerLevel = Tuple.Create(DateTime.Now.ToUniversalTime(), level);

            switch (curtailment)
            {
                case TurbineCurtailment.Default:
                    CustomLevels[curtailment] = customerLevel;
                    break;
                case TurbineCurtailment.Noise:
                    CustomLevels[curtailment] = customerLevel;
                    break;
                case TurbineCurtailment.Bats:
                    CustomLevels[curtailment] = customerLevel;
                    break;
                case TurbineCurtailment.Shadow:
                    CustomLevels[curtailment] = customerLevel;
                    break;
                case TurbineCurtailment.BoatAction:
                    CustomLevels[curtailment] = customerLevel;
                    break;
                case TurbineCurtailment.Technical:
                    CustomLevels[curtailment] = customerLevel;
                    break;
                case TurbineCurtailment.Grid:
                    CustomLevels[curtailment] = customerLevel;
                    break;
                default:
                    break;
            }
        }

        public double GetLevel(TurbineCurtailment curtailment, DateTime timestamp)
        {
            var result = 0.0;

            foreach (var level in CustomLevels)
            {
                if (level.Key.Equals(curtailment) && level.Value.Item1 == timestamp)
                {
                    result = level.Value.Item2;
                }
            }

            return result;
        }

        public double GetCurrentLevel(TurbineCurtailment curtailment)
        {
            var result = (from level in CustomLevels.AsEnumerable()
                          where level.Key == curtailment
                          select level.Value.Item2).FirstOrDefault();

            return result;
        }
    }
}
