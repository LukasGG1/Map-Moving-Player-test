﻿using System;
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
        string path = "SaveMap.txt";

        public bool GameOver = false;
        public Map()
        {
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
            draw();
        }

       
        public void draw()
        {
            Console.Clear();
            //iterate through map writing each map tiles
            for (int i = 0; i < mapLength; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < mapWidth; j++)
                {
                    Console.Write(map[i, j].mapTile);
                }
            }

        }



        public void update()
        {

            Console.WriteLine();
            player.CheckInput();
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
            map[player.PlayerY, player.PlayerX].Interact(ref player);
            //set map to temp map
            map = TempMap;

        }
        //Returns a random type of tile
        MapTile GenTile()
        {
            //Pick a random Number
            int TileToGenerate = random.Next(0, 12);
            //create tile based off Random Number
            if (TileToGenerate == 0)
            {
                return new MapTile();
            }
            else if (TileToGenerate == 1)
            {
                return new Monster();
            }
            return new MapTile();
        }
        public void SaveMap()
        {
            //Open Writer with Path
            StreamWriter writer = File.CreateText(path);
            //Write Length and Width
            writer.WriteLine(mapLength);
            writer.WriteLine(mapWidth);
            //Interate though map saving each tile
            for (int i = 0; i < mapLength; i++)
            {
                writer.WriteLine();
                for (int j = 0; j < mapWidth; j++)
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
            if (File.Exists(path))
            {
                //Create Reader to path
                StreamReader reader = File.OpenText(path);
                //Read Map Width and length
                mapLength = Convert.ToInt32(reader.ReadLine());
                mapWidth = Convert.ToInt32(reader.ReadLine());
                //Temporary map to load into
                MapTile[,] TempMap = new MapTile[mapLength, mapWidth];
                //Skip White Space
                reader.ReadLine();

                //Iterate Through Map Reading Each Character
                for (int i = 0; i < mapLength; i++)
                {
                    //save this row as string
                    string LoadedRow;
                    LoadedRow = reader.ReadLine();

                    //Convert Loaded Row Into a Character array
                    char[] LoadedTiles = LoadedRow.ToCharArray();

                    //Go through the row Checking the character and loading in the Corrisponding Tile
                    for (int j = 0; j < mapWidth; j++)
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
                        else if (LoadedTiles[j] == '|')
                        {
                            TempMap[i, j] = new MapTile();
                        }
                        else if (LoadedTiles[j] == 'M')
                        {
                            TempMap[i, j] = new Monster();
                        }
                        else
                        {
                            TempMap[i, j] = new MapTile();
                        }
                    }
                }
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
    }
}
