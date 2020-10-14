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
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            mapTile = '█';
            //mapTile = '░';

        }   
        public virtual void Interact(ref Player player, ref bool gameover)
        { //Oh I'm blind idiot.
            Console.WriteLine();
            Console.WriteLine("you walks to new location");
            Console.ReadKey();
        }
    }
}