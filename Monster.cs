﻿using System;
using System.Collections.Generic;
using System.Text;
using HelloWorld;

namespace MapExample
{
    class Monster : MapTile
    {

        public Monster()
        {
            mapTile = 'M';
        }
        

        public override void Interact(ref Player player, ref Map _gameoverPlayer)
        {
            Console.WriteLine();
            Console.WriteLine(" you run into a Monster");
            Console.ReadKey();
            Encounter battle = new Encounter(ref player, _gameoverPlayer);
        }


    }
}