using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.IO;

namespace MapExample
{
    class Game : Map
    {
        public void Run()
        {
            Start();

            while (GameOver == false)
            {
                update();
            }

            End();

        }
    }
}
