using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{

    class Game
    {
        bool gameOver = false;
        //Run the game
        public void Run()
        {
            Start();
            RequestName();
            while (gameOver == false)
            {
                Update();
            }

            End();
        }

        void RequestName()
        //body
        {
            //Initialize Order 34
            char input = ' ';
            while (input != '1')
            {
                Console.Clear();
                Console.WriteLine("Welcome! What is your name, stranger?");
                _playerName = Console.ReadLine();
                Console.WriteLine("Greeting, " + _playerName);
                input = GetInput("Yes", "No", "Is this name you want " + _playerName + "?");
                if (input == '2')
                {
                    Console.WriteLine("Yeah, You're right. It is not good name for you.");

                }
            }

        }

        //Performed once when the game begins
        public void Start()
        {
            
        }

        //Repeated until the game ends
        public void Update()
        {
            
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
