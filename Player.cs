using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HelloWorld;

namespace MapExample
{
    class Player : MapTile
    {
        public string playerName = "Hero";
        public int playerHealth = 120;
        public int playerDamage = 20;
        public int playerDefense = 10;
        public int PlayerX = 1;
        public int PlayerY = 1;

        public Player()
        {
            mapTile = 'P';
        }
        public void CheckInput()
        {
            string input;


            input = Console.ReadLine();


            if (input == "w")
            {
                PlayerY--;
            }
            else if (input == "s")
            {
                PlayerY++;
            }
            else if (input == "d")
            {
                PlayerX++;
            }
            else if (input == "a")
            {
                PlayerX--;
            }
            else
            {
                Console.WriteLine("You stand there and do nothing");
            }
        }
    }
}