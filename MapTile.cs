using System;
using System.Collections.Generic;
using System.Text;

namespace MapExample
{
    class MapTile
    {
        public char mapTile;
        public MapTile()
        {
            mapTile = '-';

        }   
        public virtual void Interact(ref Player player, ref Map _gameoverPlayer)
        { //Oh I'm blind idiot.
            Console.WriteLine();
            Console.WriteLine("you walk into a empty room");
            Console.ReadKey();
        }
    }
}