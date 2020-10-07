using MapExample;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapExample
{
    struct Item
    {
        public int statBoost;
        public int cost;
        public string name;
    }
    class Shop : MapTile
    {
        private int gold;
        private Item[] _inventory;


        public Shop()
        {
            mapTile = 'S';
            gold = 100;
            _inventory = new Item[3];
        }
        public override void Interact(ref Player player, ref Map _gameoverPlayer)
        { //Oh I'm blind idiot.
            Console.WriteLine();
            Console.WriteLine("You entered a shop");
            Console.ReadKey();
        }

        public Shop(Item[] item)
        {
            gold = 100;
            //Set OUR inventory array to be the array of item that was passed in.
            _inventory = item;
        }

        public bool Sell(Player player, int shopIndex, int playerIndex)        //int itemIndex, int playerIndex
        {
            // return player.Buy(_inventory[shopIndex], playerIndex);
            //Find the item to buy in the inventory array
            Item itemToBuy = _inventory[shopIndex];
            //Check to see if the player ourchased the item sucessfully.
            if (player.Buy(_inventory[shopIndex], playerIndex))
            {
                //Increase  shops gold by item cost to complete the transaction
                gold += itemToBuy.cost;
                return true;
            }
            return false;
        }
        public void CheckPlayerFunds(Player player)
        {

        }
    }
}
