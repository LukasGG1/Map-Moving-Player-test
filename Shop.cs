using MapExample;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop : Item
    {
        private int gold;
        private Item[] _inventory;


        public Shop()
        {
            gold = 100;
            _inventory = new Item[3];
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
