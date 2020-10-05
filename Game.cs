using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.IO;
using HelloWorld;

namespace MapExample
{
    class Game
    {
        bool _gameOver = false;
        private Player player;
        Player enemy;
        Item longSword;
        Item dagger;
        Item bow;
        Item battleAxe;
        Item mace;
        private Item healthPotion; //as arrow
        private Item sappherie; //as gem
        private Item buckler; //as shield
        private Shop shop;
        private Item[] shopInventory;
        private object currentWeapon;
        private object hand;
        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }


        //Equip item to both players in the beginnning of the game
        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            //89 Year-old Man?
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("> ");
            //----------------------
            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            //89 Year-old Man is in bus! We need get him!
            //Weapon Choose
            //---------------------------------------
            //hELq
            input = Console.ReadKey().KeyChar;
        }

        public void SelectLoadout(Player player)
        {
            Console.Clear();
            Console.WriteLine("Loadout 1: ");
            Console.WriteLine(longSword.name);
            Console.WriteLine(bow.name);
            Console.WriteLine("\n Loadout 2: ");
            Console.WriteLine(battleAxe.name);
            Console.WriteLine(mace.name);
            //Weapon Choose
            //---------------------------------------
            //wHY ArE WE HeRE SuuffEriNg?
            char input;
            GetInput(out input, "Loudout 2", "Loadout 1 ", "Choose your Loadout", "");
            //HAVE YOU SEEN 89 YEAR-OLD MAN?
            //HAVE YOU SEEN 89 YEAR-OLD MAN?
            //HAVE YOU SEEN 89 YEAR-OLD MAN?
            //HAVE YOU SEEN 89 YEAR-OLD MAN?
            //HAVE YOU SEEN 89 YEAR-OLD MAN?
            //HAVE YOU SEEN 89 YEAR-OLD MAN?
            //HAVE YOU SEEN 89 YEAR-OLD MAN?
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input == '1')
                {
                    player.AddItemToInventory(longSword, 0);
                    player.AddItemToInventory(dagger, 1);
                    player.AddItemToInventory(bow, 2);
                }
                else if (input == '2')
                {
                    player.AddItemToInventory(battleAxe, 0);
                    player.AddItemToInventory(mace, 1);
                }
                Console.WriteLine("Player 1");
                //this.player.PrintStats();

                Console.Clear();
            }
        }

        public void CreateCharacter(Player player)
        {
            Console.WriteLine("What is your name, mortal?");
            string name = Console.ReadLine();
            player = new Player();
            SelectLoadout(player);
        }

        public void InitializeItem()
        {
            //Weapon&Armor
            longSword.name = "Long Sword";
            longSword.statBoost = 15;
            longSword.cost = 10;

            dagger.name = "Dagger";
            dagger.statBoost = 10;
            dagger.cost = 7;

            bow.name = "Bow";
            bow.statBoost = 10;
            bow.cost = 15;

            battleAxe.name = "Battle Axe";
            battleAxe.statBoost = 19;
            battleAxe.cost = 35;

            mace.name = "Mace";
            mace.cost = 20;
            mace.statBoost = 17;

            buckler.name = "Buckler";
            buckler.cost = 13;

            //Consumable Item
            healthPotion.cost = 7;
            healthPotion.name = "Health Potion";

            //Valuable Item
            sappherie.cost = 50;
            sappherie.name = "Sappherie";
        }

        public void PrintInventory(Item[] inventory) //I know it  need return; But, I want console.writeline
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + "." + inventory[i].name + inventory[i].cost);
            }
        }

        private void OpenShopMenu()
        {
            //print a that bad boy as welcome message and all the choices to the screen
            Console.WriteLine("Welcome to my shop! Please select an fine item, sir.");

            PrintInventory(shopInventory);

            char input = Console.ReadKey().KeyChar;
            int itemIndex = -1;
            switch (input)
            {
                case '1':
                    {
                        itemIndex = 0;
                        break;
                    }
                case '2':
                    {
                        itemIndex = 1;
                        break;
                    }
                case '3':
                    {
                        itemIndex = 2;
                        break;
                    }
                default:
                    {
                        return;
                    }

            }

            if (player.GetGold() < shopInventory[itemIndex].cost)
            {
                Console.WriteLine("HaHa, you poor! You can't afford this!");
                return;
            }
            Console.WriteLine("Choose a slot to replace.");
            PrintInventory(player.GetInventory());
            //Get player Input
            input = Console.ReadKey().KeyChar;
            //set the value
            int playerIndex = -1;
            switch (input)
            {
                case '1':
                    {
                        playerIndex = 0;
                        break;
                    }
                case '2':
                    {
                        playerIndex = 1;
                        break;
                    }
                case '3':
                    {
                        playerIndex = 2;
                        break;
                    }
                default:
                    {
                        return;
                    }

            }
            shop.Sell(player, itemIndex, playerIndex);
        }

        //public void SwitchWeapon(Player player)
        //{
        // Item[] inventory = player.GetInventory();
        //Print all item to screen
        //char input = ' ';
        //for(int i = 0; i < 3; i++)
        //{
        //    Console.WriteLine((i + 1) + ". " + inventory[i].name + "Damage: " + inventory[i].statBoost);
        // }
        // Console.Write("> ");
        // input = Console.ReadKey().KeyChar;

        //GetInput(out input, inventory[0].name, inventory[1], inventory[2].name, "Choose your weapon");


        // switch(input)
        //{
        // case '1':
        //   {
        //        player.EquipItem(0);
        //        Console.WriteLine("You equipped " + inventory[0].name);
        //        Console.WriteLine("Damage increased by " + inventory[0].statBoost);
        //        break;
        //     }
        // case '2':
        //    {
        //     player.EquipItem(1);
        //     Console.WriteLine("You equipped " + inventory[1].name);
        //    Console.WriteLine("Damage increased by " + inventory[1].statBoost);
        //    break;
        //    }
        //  case '3':
        //   {
        //      player.EquipItem(2);
        //     Console.WriteLine("You equipped " + inventory[2].name);
        //    Console.WriteLine("Damage increased by " + inventory[2].statBoost);
        //    break;
        //  }
        //  default:
        //    {
        //        player.UnequipItem();
        //       Console.WriteLine("You are thinking about your voice and you acciently dropped weapon");

        //      break;
        //  }
        // }
        //   }


        // public void StartBattle()
        // {
        //   Console.Clear();
        //    Console.WriteLine("Fight to death!");

        //  while (player.GetIsAlive() && _enemy.GetIsAlive())
        //  {
        //      Console.WriteLine("Player 1");
        //     player.PrintStat();
        //Player 1 turn start
        //     char input;
        //    GetInput(out input, "Attack", "Inventory", "Your Turn, Player 1","");

        //  if(input == '1')
        //   {
        //
        //       _enemy.Attack(player);

        //  }
        //  else
        //  {
        //     SwitchWeapon(player);
        // }
        //  if(input == '2')
        //  {

        //   }


        // }
        // Player PrintStat;
        // if (player.GetIsAlive())
        //{
        //     Console.WriteLine("Player 1 Won");
        //}
        // else
        //{
        //    Console.WriteLine("Player 2 Won");
        //}
        // Console.Clear();
        //  _gameOver = true;
        //}

        //Performed once when the game begins
        public void Start()
        {
            _gameOver = false;
            player = new Player();
            InitializeItem();
            shopInventory = new Item[] { healthPotion, buckler, sappherie };
            //mace, bow, dagger, longSword, battleAxe};
            shop = new Shop(shopInventory);
        }

        //Repeated until the game ends
        public void Update()
        {
            OpenShopMenu();
            CreateCharacter(player);
            SelectLoadout(player);
            //StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {

        }

        public void UnequipItem()
        {
            currentWeapon = hand;
        } 
    }
}

