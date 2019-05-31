using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    [Serializable]
    internal class Motorcycle
    {
        [NonSerialized] private float weightOfCurrentPassengers;
        private bool hasRadioSystem;
        private bool hasHeadSet;
        private bool hasSissyBar;
    }
}
