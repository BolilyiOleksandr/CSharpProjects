using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: CLSCompliant(true)]
namespace AttributedCarLibrary
{
    public enum AttributeTargets
    {
        All,
        Assembly,
        Class,
        Constructor,
        Delegate,
        Enum,
        Event,
        Field,
        GenericParameter,
        Interface,
        Method,
        Module,
        Parameter,
        Property,
        ReturnValue,
        Struct
    }

    [AttributeUsage(AttributeTargets.Class,Inherited = false)]
    public sealed class VehicleDescriptionAttribute : System.Attribute
    {
        public string Description { get; set; }

        public VehicleDescriptionAttribute(string vehicalDescription)
        {
            Description = vehicalDescription;
        }
        public VehicleDescriptionAttribute() { }
    }

    [Serializable]
    [VehicleDescription(Description = "My rocking Harley")]
    public class Motorcycle { }

    [Serializable]
    [Obsolete("Use another vehicle!")]
    [VehicleDescription("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy { }

    [VehicleDescription("A very long, slow, but feature-rich auto")]
    public class Winnebago
    {
        [VehicleDescription("My rocking CD player")]
        public void PlayMusic(bool On) { }
    }

}
