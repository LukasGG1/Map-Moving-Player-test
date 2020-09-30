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
        public int playerHealth = 100;
        public int playerDamage = 20;
        public int playerDefense = 10;
        public int PlayerX = 1;
        public int PlayerY = 1;
        private Item[] _inventory;
        private Item currentWeapon;
        private Item hand ;
        public Item statBoost;
        public Item currently;
        //I'm confused.
        private int gold;
        


        public Player()
        {
            mapTile = 'P';
            hand = new Item();
            statBoost = new Item();
            _inventory = new Item[3];
            gold = 100;
            hand.name = "Kira's Fetish";
            hand.statBoost = 1;
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
            else if (input == "help")
            {
                Console.WriteLine("");
                Console.WriteLine("Input");
                Console.WriteLine("-------");
                Console.WriteLine("Movement");
                Console.WriteLine("============");
                Console.WriteLine("w is a up");
                Console.WriteLine("s is a down");
                Console.WriteLine("d is a right");
                Console.WriteLine("a is a left");
                Console.WriteLine("");
                Console.WriteLine("If you type input. click Enter on your keyboard");
                Console.WriteLine("");
                Console.WriteLine("m is a Menu");
                Console.WriteLine("i is inventory");
                Console.WriteLine("stats is stat");
            }
            else if (input == "stats")
            {
                Console.WriteLine("");
                PrintStats(playerName, playerHealth, playerDamage, playerDefense);
                Console.ReadKey();
            }
            else if (input == "i")
            {
                Console.WriteLine("Coming Soon!");
            }
            else
            {
                Console.WriteLine("You stand there and do nothing");
            }
        }
        void PrintStats(string playerName, int playerHealth, int damage, int defense)
        {
            Console.WriteLine("\n" + playerName);
            Console.WriteLine("Health: " + playerHealth);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("Defense: " + defense);
        }
        public bool Buy(Item item, int inventoryIndex)
        {
            // Am I doing wrong?
            if (gold >= item.cost)
            {
                //pay for item
                gold -= item.cost;
                _inventory[inventoryIndex] = item;
                return true;
            }
            return false;
        }

        public int GetGold()
        {
            return gold;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }
        //I have no idea why it cannot apply indexing.
        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < 4)
            {
                return true;
            }
            return false;
        }
        //89 year-old man
        public void EquipItem(int itemIndex)
        {
            if (Contains(itemIndex) == true)
            {
                currentWeapon = _inventory[itemIndex];
            }
        }


        public string GetName()
        {
            return playerName;
        }
        public void UnequipItem()
        {
            currentWeapon = hand;
        }


    }
}
