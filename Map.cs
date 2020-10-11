using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.IO;

namespace MapExample
{
    class Map
    {
        int mapLength = 24;
        int mapWidth = 24;
        MapTile[,] map;
        Player player = new Player();
        Random random = new Random();
        Player playerValue;
        Map blayer;
        Map _gameoverPlayer;

        string path = "SaveMap.txt";

        public bool GameOver = false;



        public void Run()
        {
            Start();
            SelectCharacter();

            while (GameOver == false)
            {
                update();
                draw();
            }

            End();

        }




        public void draw()
        {
            Console.Clear();
            //iterate through map writing each map tiles
            for (int i = 0; i < mapLength-1; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < mapWidth-1; j++)
                {
                    Console.Write(map[i, j].mapTile);
                }
            }

        }
        public Map()
        {

        }
        public Map(ref Player player)
        {
            playerValue = player;
        }

        //public void AddObject(object 1hs) //object rhs)
        //{
        //return 1hs + rhs;  <<< public object
        //
        //Console.WriteLine(item);
        // }

        public void update()
        {
            //Text File
            //==============================================
            //var *or Wizard* test = CreateCharacter();
            //var *or Character* test2 = new Wizard(120, "Wizard Lizard", 20, 100);
            //Save();
            //==============================================
            Console.WriteLine();
            player.CheckInput(this);
            //Create a temporary map
            MapTile[,] TempMap = new MapTile[mapLength, mapWidth];
            //update map with new player location
            for (int i = 0; i < mapLength; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    //if player has been on tile set it to a empty tile
                    if (map[i, j] == player)
                    {
                        TempMap[i, j] = new MapTile();
                    }
                    else
                    {
                        TempMap[i, j] = map[i, j];
                    }
                }
            }
            //set players new coordinates on the map 
            TempMap[player.PlayerY, player.PlayerX] = player;
            //Interact
            //interact with the players new location before the map is updated
            map[player.PlayerY, player.PlayerX].Interact(ref player, ref GameOver);
            //set map to temp map
            map = TempMap;

        }
        //Returns a random type of tile
        MapTile GenTile()
        {
            //Pick a random Number
            int TileToGenerate = random.Next(0, 20);
            //create tile based off Random Number
            if (TileToGenerate == 0)
            {
                return new MapTile();
            }
            else if (TileToGenerate == 1)
            {
                return new Monster();
            }
            else if (TileToGenerate == 2)
            {
                return new Shop();
            }
            return new MapTile();
        }

        //public string Load()
        //{
        // StreamReader reader = new StreamReader("SaveData.txt");
        //string name = reader.ReadLine();
        //player.Load(reader);
        //reader.Close();
        //return name;
        //}

        public void Help()
        {
            Console.WriteLine("P is a player and you");
            Console.WriteLine("");
            Console.WriteLine("M is a monster and enemy");
            Console.WriteLine("");
            Console.WriteLine("Movement");
            Console.WriteLine("==================");
            Console.WriteLine("W = up");
            Console.WriteLine("S = down");
            Console.WriteLine("A = left");
            Console.WriteLine("D = right");
            Console.ReadKey();
            Console.Clear();

        }




       
            //  ||
            //  \/
            //  This is Example of how to avoid ArguementOutOfRangeExpection.
        void PrintOddDude(int index, char[] charList)
        {
            if(index >= 0 && index < charList.Length)
            { 
                Console.WriteLine(charList[index]);
            }
        }

        public void SaveMap()
        {
            //Open Writ er with Path
            StreamWriter writer = File.CreateText("SaveData.txt");
            //Write Length and Width
            writer.WriteLine(mapLength);
            writer.WriteLine(mapWidth);
              //writer.WriteLine(player.PlayerY);
              //writer.WriteLine(player.PlayerX);
            //Interate though map saving each tile
            for (int i = 0; i < mapLength-1; i++)
            {
                writer.WriteLine();
                for (int j = 0; j < mapWidth-1; j++)
                {
                    writer.Write(map[i, j].mapTile);
                }
            }
            //close Writer
            writer.Close();

        }
        public bool LoadMap()
        {
            //Check If File Exists
            if (File.Exists("SaveData.txt"))
            {
                //Create Reader to path
                StreamReader reader = File.OpenText("SaveData.txt");
                //Read Map Width and length
                mapLength = Convert.ToInt32(reader.ReadLine());
                mapWidth = Convert.ToInt32(reader.ReadLine());
                //Temporary map to load into
                MapTile[,] TempMap = new MapTile[mapLength, mapWidth];
                //Skip White Space
                reader.ReadLine();

                //Iterate Through Map Reading Each Character
                for (int i = 0; i < mapLength-1; i++)
                {
                    //save this row as string
                    string LoadedRow;
                    LoadedRow = reader.ReadLine();

                    //Convert Loaded Row Into a Character array
                    //  ||
                    //  \/
                    // Problem

                    char[] LoadedTiles = LoadedRow.ToCharArray();
                    if (i >= 0 && i < LoadedTiles.Length)
                    {
                        Console.WriteLine(LoadedTiles[i]);
                    }
                    //Go through the row Checking the character and loading in the Corrisponding Tile
                    for (int j = 0; j < mapWidth-1; j++)
                    {
                        //Set maps player to this new Temporary Player
                        if (LoadedTiles[j] == 'P')
                        {
                            Player tempPlayer = new Player();
                            tempPlayer.PlayerY = j;
                            tempPlayer.PlayerX = i;
                            player = tempPlayer;
                            TempMap[i, j] = new Player();
                        }
                        else if (LoadedTiles[j] == '-')
                        {
                            TempMap[i, j] = new MapTile();
                        }
                        else if (LoadedTiles[j] == 'M')
                        {
                            TempMap[i, j] = new Monster();
                        }
                        else if (LoadedTiles[j] == 'S')
                        {
                            TempMap[i, j] = new Shop();
                        }
                        else
                        {
                            TempMap[i, j] = new MapTile();
                        }
                    }
                    
                }
                Console.WriteLine("Save loaded!");
                //Close Reader
                reader.Close();
                //Set Map to the map we just loaded
                map = TempMap;

                return true;
            }
            //No Save File was Found
            else
            {
                Console.WriteLine("No save Found");
                Console.ReadKey();
                return false;
            }
        }

        public void Start()
        {
            Help();
            Console.WriteLine("Welcome to my shadow game");
            Console.ReadKey();
            Console.Clear();
            //SelectCharacter();
            //Load Map OtherWise Generate a new map
            if (!LoadMap())
            {
                MapTile[,] TempMap = new MapTile[mapLength, mapWidth];
                for (int i = 0; i < mapLength; i++)
                {
                    for (int j = 0; j < mapWidth; j++)
                    {
                        if (i == player.PlayerY && j == player.PlayerY)
                        {
                            TempMap[i, j] = player;
                        }
                        else
                        {
                            TempMap[i, j] = GenTile();
                        }

                    }
                }
                map = TempMap;
            }
            //Intial Draw




            //===========================================

            //bool test = false;
            //float a = 0.05f;
            //int b = Convert.ToInt32(test);
            //Character testCharacter = playerPartner;
            //Wizard testWizard = null;
            //if(testCharacter is Wizard)
            //{
            //
            //  testWizard = (Wizard)testCharacter;
            //
            //}
            //if(testWizard != null)
            //{
            //   testWizard.TestFunc();   
            //}
            //((Wizard)testCharacter).TestFunc(); or Wizard testWizard = (Wizard)testCharacter;
        }
        public void End()
        {

            //If the player died print death message
            if (playerValue.playerHealth <= 0)
            {
                Console.WriteLine("Failure");
                Console.ReadKey();
                GameOver = true;
                return;
            }
        }
        public void SelectCharacter()
        {
            char input = ' ';
            //Loops until a valid option is choosen
            while (input != '1' && input != '2' && input != '3')
            {
                //Prints options
                Console.WriteLine("Welcome! Please select a character.");
                Console.WriteLine("1.Sir YeeHawwer");
                Console.WriteLine("Sir YeeHawwer is from noble house called Griffin for bodyguard of Royalty. Griffin's founder was legendary knight who");
                Console.WriteLine("protected his kingdom multiple and saved a lot Royalty's life. But, Griffin dislike politic and was exiled by greedy and arrogant Royalty");
                Console.WriteLine("");
                Console.WriteLine("2.Gnoo");
                Console.WriteLine("Gnoo is mage who bears blood magic from his family and running away from Templer, knight who kill or safeguard mage for fearing magic corruption. Gnojoel wasn't corrupted by blood magic. Gnojoel is such greedy mage. Not money. Not fame. Not glory. Just knowledge for sasifty his curiousity.");
                Console.WriteLine("");
                Console.WriteLine("3.Dazz Boy");
                Console.WriteLine("Dazz Boy's race is elves who were enslaved by human and now lower rank is commoner. Human looked down and treat elves as trash. Joedazz's bloodline was legendary Reavor, a warrior who devor blood and flesh for healing his flesh. Joedazz was declared crimenal by noble. because Joedazz killed noble's son. Joedazz killed noble's son for saving Joedazz's sister  because noble's son tried kill her for his pleasure. Joedazz has no place in this city and have no choice but leave city.");
                Console.WriteLine("");
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
                //Sets the players default stats based on which character was picked
                switch (input)
                {
                    case '1':
                        {
                            playerValue.playerName = "Sir YeeHawwer";
                            playerValue.playerHealth = 40;
                            playerValue.playerDamage = 3;
                            break;
                        }
                    case '2':
                        {
                            playerValue.playerName = "Gnoo";
                            playerValue.playerHealth = 30;
                            playerValue.playerDamage = 7;
                            break;
                        }
                    case '3':
                        {
                            playerValue.playerName = "Dazz Boy";
                            playerValue.playerHealth = 50;
                            playerValue.playerDamage = 5;
                            break;
                        }
                    //If an invalid input is selected display and input message and input over again.
                    default:
                        {
                            Console.WriteLine("Invalid input. Press any key to continue.");
                            Console.Write("> ");
                            Console.ReadKey();
                            break;
                        }
                }
                Console.Clear();
            }
        }
    }
}
