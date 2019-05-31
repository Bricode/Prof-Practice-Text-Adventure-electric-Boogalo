﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace InfectionInjection
{
    class Game
    {
        static void Main(string[] args)
        {
            string[,,] world = new string[8, 8, 3];
            for (int a = 0; a < 8; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        world[a, b, c] = "X";
                    }
                }
            }
            int[,,] playerPos = new int[8, 8, 3];
            playerPos[0, 0, 0] = 1;
            int[] playerCoor = { 0, 0, 0 };
            List<Location> locations = new List<Location>();
            LoadData(locations);
            UpdateWorld(locations, world);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Map of World\n");
                Map(world, playerPos);
                Console.ResetColor();
                Console.WriteLine("Map of inside Hospital\n");
                LocationMap(locations);

                char input = Console.ReadKey().KeyChar;

                if (input == 'w')
                {
                    playerPos[playerCoor[0], playerCoor[1], playerCoor[2]] = 0;
                    playerCoor[1]--;
                    playerPos[playerCoor[0], playerCoor[1], playerCoor[2]] = 1;
                }
                if (input == 's')
                {
                    playerPos[playerCoor[0], playerCoor[1], playerCoor[2]] = 0;
                    playerCoor[1]++;
                    playerPos[playerCoor[0], playerCoor[1], playerCoor[2]] = 1;
                }
                if (input == 'a')
                {
                    playerPos[playerCoor[0], playerCoor[1], playerCoor[2]] = 0;
                    playerCoor[0]--;
                    playerPos[playerCoor[0], playerCoor[1], playerCoor[2]] = 1;
                }
                if (input == 'd')
                {
                    playerPos[playerCoor[0], playerCoor[1], playerCoor[2]] = 0;
                    playerCoor[0]++;
                    playerPos[playerCoor[0], playerCoor[1], playerCoor[2]] = 1;
                }
            }
        }

        static void Map(string[,,] world, int[,,] playerPos)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (playerPos[x, y, 0] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (world[x, y, 0] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if (playerPos[x, y, 0] == 1)
                    {
                        Console.Write("1".PadRight(15).PadLeft(15));
                    }
                    else
                    {
                        Console.Write(world[x, y, 0].PadRight(15).PadLeft(15));
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void LocationMap(List<Location> locations)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (locations[0].LocationMap[x, y, 0] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (locations[0].LocationMap[x, y, 0] == "Hallway")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(locations[0].LocationMap[x, y, 0].PadRight(15).PadLeft(15));
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void LoadData(List<Location> locations)
        {
            string locationDir = Directory.GetCurrentDirectory() + @"\Resources\Location\";
            string locationRoomDir = Directory.GetCurrentDirectory() + @"\Resources\LocationRooms\";
            string[] locationFilePaths = Directory.GetFiles(locationDir);
            string[] roomFilePaths = Directory.GetFiles(locationRoomDir);

            for (int i = 0; i < locationFilePaths.Length; i++)
            {
                StreamReader locationTextData = new StreamReader(locationFilePaths[i]);
                StreamReader roomTextData = new StreamReader(roomFilePaths[i]);
                Location loadLocation = new Location();

                loadLocation.Name = locationTextData.ReadLine();

                string[] tempDimensions = locationTextData.ReadLine().Split(',');
                for (int n = 0; n < tempDimensions.Length; n++)
                {
                    loadLocation.Dimensions[n] = Convert.ToInt32(tempDimensions[n]);
                }

                string[] coordinates = locationTextData.ReadLine().Split('.');
                for (int x = 0; x < coordinates.Length; x++)
                {
                    string[] hallwayStrings = coordinates[x].Split(',');
                    int[] hallway = new int[hallwayStrings.Length];

                    for (int n = 0; n < hallwayStrings.Length; n++)
                    {
                        hallway[n] = Convert.ToInt32(hallwayStrings[n]);
                    }

                    loadLocation.HallwayCoor.Add(hallway);
                }

                loadLocation.RoomCount = Convert.ToInt32(locationTextData.ReadLine());
                loadLocation.HallwayCount = Convert.ToInt32(locationTextData.ReadLine());

                locationTextData.Close();

                for (int n = 0; n < loadLocation.RoomCount; n++)
                {
                    Room loadRoom = new Room();
                    loadRoom.Name = roomTextData.ReadLine();

                    string[] coorString = roomTextData.ReadLine().Split(',');
                    for (int x = 0; x < coorString.Length; x++)
                    {
                        loadRoom.Coor[x] = Convert.ToInt32(coorString[x]);
                    }

                    loadRoom.Items = roomTextData.ReadLine().Split(',');

                    loadLocation.Rooms.Add(loadRoom);
                }

                loadLocation.LocationMap = new string[loadLocation.Dimensions[3], loadLocation.Dimensions[4], loadLocation.Dimensions[5]];
                for (int a = 0; a < loadLocation.Dimensions[3]; a++)
                {
                    for (int b = 0; b < loadLocation.Dimensions[4]; b++)
                    {
                        for (int c = 0; c < loadLocation.Dimensions[5]; c++)
                        {
                            loadLocation.LocationMap[a, b, c] = "X";
                        }
                    }
                }

                roomTextData.Close();

                locations.Add(loadLocation);
            }
        }

        static void UpdateWorld(List<Location> locations, string[,,] world)
        {
            for (int i = 0; i < locations.Count; i++)
            {
                for (int x = locations[i].Dimensions[0]; x < locations[i].Dimensions[0] + locations[i].Dimensions[3]; x++)
                {
                    for (int y = locations[i].Dimensions[1]; y < locations[i].Dimensions[1] + locations[i].Dimensions[4]; y++)
                    {
                        for (int z = locations[i].Dimensions[2]; z < locations[i].Dimensions[2] + locations[i].Dimensions[5]; z++)
                        {
                            world[x, y, z] = locations[i].Name;
                        }
                    }
                }

                for (int x = 0; x < locations[i].Dimensions[3]; x++)
                {
                    for (int y = 0; y < locations[i].Dimensions[4]; y++)
                    {
                        for (int z = 0; z < locations[i].Dimensions[5]; z++)
                        {
                            for (int r = 0; r < locations[i].RoomCount; r++)
                            {
                                if ((x == locations[i].Rooms[r].Coor[0]) && (y == locations[i].Rooms[r].Coor[1]) && (z == locations[i].Rooms[r].Coor[2]))
                                {
                                    locations[i].LocationMap[x, y, z] = locations[i].Rooms[r].Name;
                                }
                            }
                            for (int h = 0; h < locations[i].HallwayCount; h++)
                            {
                                if ((x == locations[i].HallwayCoor[h][0]) && (y == locations[i].HallwayCoor[h][1]) && (z == locations[i].HallwayCoor[h][2]))
                                {
                                    locations[i].LocationMap[x, y, z] = "Hallway";
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
