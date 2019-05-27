using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation
{
    internal class AllTracks
    {
        // Our media player can have a maximum
        // of 10,000 songs.
        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>(
            () =>
            {
                Console.WriteLine("Creating AllTracks object!");
                return new AllTracks();
            }
        );
        public AllTracks GetAllTracks()
        {
            // Return all of the songs.
            return allSongs.Value;
        }
    }
}
