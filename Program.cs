using System;

namespace MapExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            map.Start();

            while (!map.GameOver)
            {

                map.update();
                map.draw();
                //map.SaveMap();
            }
        }
    }
}