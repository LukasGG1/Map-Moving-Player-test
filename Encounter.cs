using System;
using System.Collections.Generic;
using System.Text;
using MapExample;

namespace HelloWorld
{
    class Encounter
    {
        //int levelScaleMax = 5;
        int HitChance = 50;
        Random random = new Random();

        public Encounter(ref Player player, ref bool gameover)
        {
            gameover = Battle(ref player);
        }


        void GetInput(out char input, string option1, string option2)
        {
            //Initialize input
            input = ' ';
            //Loop until the player enters a valid input
            while (input != '1' && input != '2')
            {
                Console.WriteLine("1." + option1);
                Console.WriteLine("2." + option2);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
            }
        }
        public bool Battle(ref Player player) //<<< (Character player)
        {
            
            //initialize default enemy stats
            int enemyHealth = 0;
            int enemyAttack = 0;
            int enemyDefense = 0;
            string enemyName = "";
            //Changes the enemy's default stats based on our current room number. 
            //This is how we make it seem as if the player is fighting different enemies
            switch (random.Next(0,3))
            {
                case 0:
                    {
                        Console.WriteLine("                              _.--''-._");
                        Console.WriteLine("  .                         .'         '.");
                        Console.WriteLine(" / \\    ,^.         /(     Y             |      )\\");
                        Console.WriteLine("/   `---. |--'\\    (  \\__..'--   -   -- -'''-.-'  )");
                        Console.WriteLine("|        :|    `>   '.     l_..-------.._l      .'");
                        Console.WriteLine("|      __l;__ .'      ' -.__.|| _.- 'v' -._ ||`'----'");
                        Console.WriteLine(" \\  .-' | |  `              l._       _.'");
                        Console.WriteLine("  \\/    | |                   l`^^'^^'j");
                        Console.WriteLine("        | |                _   \\_____/     _");
                        Console.WriteLine("        j |               l `--__)-'(__.--' |");
                        Console.WriteLine("        | |               | /`---``-----''| |  , -----.");
                        Console.WriteLine("        | |               )/  `--' '---'   \'-'  ___  `-. ");
                        Console.WriteLine("        | |              //  `-'  '`----'  /  ,-'   I`.  \\");
                        Console.WriteLine("      _ L |_            //  `-.-.'`-----' /  /  |   |  `. \\");
                        Console.WriteLine("     '._' / \\         _/(   `/   )- ---' ;  /__.J   L.__.\\ :");
                        Console.WriteLine("      `._;/7(-.......'  /        ) (     |  |            | |");
                        Console.WriteLine("      `._;l _'--------_/        )-'/     :  |___.    _._./ ;");
                        Console.WriteLine("        | |                 .__ )-'\\  __  \\  \\  I   1   / /");
                        Console.WriteLine("        `-'                /   `-\\-(-'   \\ \\  `.|   | ,' /");
                        Console.WriteLine("                           \\__  `-'    __/  `-. `---'',-'");
                        Console.WriteLine("                              )-._.-- (        `-----'");
                        Console.WriteLine("                             )(  l\\ o ('..-.");
                        Console.WriteLine("                       _..--' _'-' '--'.-. |");
                        Console.WriteLine("                __,,-'' _,,-''            \\ \\");
                        Console.WriteLine("               f'. _,,-'                   \\ \\");
                        Console.WriteLine("              ()--  |                       \\ \\");
                        Console.WriteLine("                \\.  |                       /  \\");
                        Console.WriteLine("                  \\ \\                      |._  |");
                        Console.WriteLine("                   \\ \\                     |  ()|");
                        Console.WriteLine("                    \\ \\                     \\  /");
                        Console.WriteLine("                     ) `-.                   | |");
                        Console.WriteLine("                    // .__)                  | |");
                        Console.WriteLine("                 _.//7'                      | |");
                        Console.WriteLine("                                            (| |");
                        Console.WriteLine("                                             |  \\");
                        Console.WriteLine("                                             |lllj");
                        Console.WriteLine("                                             |||||  ");
                        Console.WriteLine("");
                        Console.ReadKey();
                        enemyHealth = 100;
                        enemyAttack = 1;
                        enemyDefense = 5;
                        enemyName = "Warrior Skeleton";
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("");
                        Console.WriteLine("           /^\\/^\\");
                        Console.WriteLine("         _|__|  O|");
                        Console.WriteLine("\\/     /~     \\_/ \\");
                        Console.WriteLine(" \\____|__________/  \\");
                        Console.WriteLine("        \\_______      \\");
                        Console.WriteLine("                `\\     \\                 \\");
                        Console.WriteLine("                  |     |                  \\");
                        Console.WriteLine("                 /      /                    \\");
                        Console.WriteLine("                /     /                       \\\\");
                        Console.WriteLine("              /      /                         \\ \\");
                        Console.WriteLine("             /     /                            \\  \\");
                        Console.WriteLine("           /     /             _----_            \\   \\");
                        Console.WriteLine("          /     /           _-~      ~-_         |   |");
                        Console.WriteLine("         (      (        _-~    _--_    ~-_     _/   |");
                        Console.WriteLine("          \\      ~-____-~    _-~    ~-_    ~-_-~    /");
                        Console.WriteLine("            ~-_           _-~          ~-_       _-~");
                        Console.WriteLine("               ~--______-~                ~-___-~");
                        Console.ReadKey();
                        enemyHealth = 50;
                        enemyAttack = 20;
                        enemyDefense = 5;
                        enemyName = "Snake";
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("          _......._");
                        Console.WriteLine("       .-'.'.'.'.'.'.`-.");
                        Console.WriteLine("     .'.'.'.'.'.'.'.'.'.`.");
                        Console.WriteLine("    /.'.'               '.\\");
                        Console.WriteLine("    |.'    _.--...--._     |");
                        Console.WriteLine("    \\    `._.-.....-._.'   /");
                        Console.WriteLine("    |     _..- .-. -.._   |");
                        Console.WriteLine(" .-.'    `.   ((@))  .'   '.-.");
                        Console.WriteLine("( ^ \\      `--.   .-'     / ^ )");
                        Console.WriteLine(" \\  /         .   .       \\  /");
                        Console.WriteLine(" /          .'     '.  .-    \\");
                        Console.WriteLine("( _.\\    \\ (_`-._.-'_)    /._\\)");
                        Console.WriteLine(" `-' \\   ' .--.          / `-'");
                        Console.WriteLine("     |  / /|_| `-._.'\\   |");
                        Console.WriteLine("     |   |       |_| |   /-.._");
                        Console.WriteLine(" _..-\\   `.--.______.'  |");
                        Console.WriteLine("      \\       .....     |");
                        Console.WriteLine("       `.  .'      `.  /");
                        Console.WriteLine("         \\           .'");
                        Console.WriteLine("  LGB     `-..___..-`");

                        Console.WriteLine("");
                        Console.ReadKey();
                        enemyHealth = 200;
                        enemyAttack = 40;
                        enemyDefense = 10;
                        enemyName = "Cyclops";
                        break;
                    }
            }

            //Loops until the player or the enemy is dead
            while (player.playerHealth > 0 && enemyHealth > 0)
            {
                //Displays the stats for both charactersa to the screen before the player takes their turn
                PrintStats(player.playerName, player.playerHealth, player.playerDamage, player.playerDefense);
                PrintStats(enemyName, enemyHealth, enemyAttack, enemyDefense);

                //Get input from the player
                char input;
                GetInput(out input, "Attack", "Defend");
                //If input is 1, the player wants to attack. By default the enemy blocks any incoming attack
                if (input == '1')
                {
                    int HitRoll = random.Next(0, 100);
                    if (HitRoll > HitChance)
                    {

                        BlockAttack(ref enemyHealth, player.playerDamage, enemyDefense);
                        Console.Clear();
                        Console.WriteLine("You dealt " + (player.playerDamage - enemyDefense) + " damage.");
                        Console.Write("> ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("you missed");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    if (HitRoll < HitChance)
                    {
                        //After the player attacks, the enemy takes its turn. Since the player decided not to defend, the block attack function is not called.
                        player.playerHealth -= enemyAttack;
                        Console.WriteLine(enemyName + " dealt " + enemyAttack + " damage.");
                        Console.Write("> ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Enemy missed you");
                    }


                }
                //If the player decides to defend the enemy just takes their turn. However this time the block attack function is
                //called instead of simply decrementing the health by the enemy's attack value.
                else
                {
                    BlockAttack(ref player.playerHealth, enemyAttack, player.playerDefense);
                    Console.WriteLine(enemyName + " dealt " + (enemyAttack - player.playerDefense) + " damage.");
                    Console.Write("> ");
                    Console.ReadKey();

                    Console.Clear();
                }
                
               
            }
            //Return whether or not our player died
            return player.playerHealth <= 0;
        }
        void BlockAttack(ref int opponentHealth, int attackVal, int opponentDefense)
        {
            int damage = attackVal - opponentDefense;
            if (damage < 0)
            {
                damage = 0;
            }
            opponentHealth -= damage;
        }
        void PrintStats(string name, int health, int damage, int defense)
        {
            Console.WriteLine("\n" + name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Damage: " + damage);
            Console.WriteLine("Defense: " + defense);
        }
    }
}
