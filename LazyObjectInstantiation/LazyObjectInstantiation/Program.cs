using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lazy Instantiation * ****\n");
            // No allocation of AllTracks object here!
            var myPlayer = new MediaPlayer();
            myPlayer.Play();
            // Allocation of AllTracks happens when you call GetAllTracks().
            var yourPlayer = new MediaPlayer();
            var yourMusic = yourPlayer.GetAllTracks();
            Console.ReadLine();
        }
    }
}
