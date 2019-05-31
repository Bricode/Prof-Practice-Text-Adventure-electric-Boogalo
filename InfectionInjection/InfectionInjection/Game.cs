using System;
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
            int[,,] playerCoor = new int[8, 8, 3];
            playerCoor[0, 0, 0] = 1;
            int[] playerLocation = { 0, 0, 0 };
            List<Location> locations = new List<Location>();
            LoadData(locations);
            UpdateWorld(locations, world);

            while (true)
            {
                Console.Clear();
                Map(world, playerCoor);

                char input = Console.ReadKey().KeyChar;

                if (input == 'w')
                {
                    playerCoor[playerLocation[0], playerLocation[1], playerLocation[2]] = 0;
                    playerLocation[1]--;
                    playerCoor[playerLocation[0], playerLocation[1], playerLocation[2]] = 1;
                }
                if (input == 's')
                {
                    playerCoor[playerLocation[0], playerLocation[1], playerLocation[2]] = 0;
                    playerLocation[1]++;
                    playerCoor[playerLocation[0], playerLocation[1], playerLocation[2]] = 1;
                }
                if (input == 'a')
                {
                    playerCoor[playerLocation[0], playerLocation[1], playerLocation[2]] = 0;
                    playerLocation[0]--;
                    playerCoor[playerLocation[0], playerLocation[1], playerLocation[2]] = 1;
                }
                if (input == 'd')
                {
                    playerCoor[playerLocation[0], playerLocation[1], playerLocation[2]] = 0;
                    playerLocation[0]++;
                    playerCoor[playerLocation[0], playerLocation[1], playerLocation[2]] = 1;
                }
            }
        }

        static void Map(string[,,] world, int[,,] playerCoor)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (playerCoor[x, y, 0] == 1)
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

                    if (playerCoor[x, y, 0] == 1)
                    {
                        Console.Write("1".PadRight(5).PadLeft(5));
                    }
                    else
                    {
                        Console.Write(world[x, y, 0].PadRight(5).PadLeft(5));
                    }
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
                    string[] halwayStrings = coordinates[x].Split(',');
                    int[] halway = new int[halwayStrings.Length];

                    for (int n = 0; n < halwayStrings.Length; n++)
                    {
                        halway[n] = Convert.ToInt32(halwayStrings[n]);
                    }

                    loadLocation.HalwayCoor.Add(halway);
                }

                loadLocation.RoomCount = Convert.ToInt32(locationTextData.ReadLine());
                loadLocation.EntryCount = Convert.ToInt32(locationTextData.ReadLine());

                string[] entryCoordinates = locationTextData.ReadLine().Split('.');
                for (int x = 0; x < entryCoordinates.Length; x++)
                {
                    string[] entryCoordinateStrings = entryCoordinates[x].Split(',');
                    int[] entryCoordinate = new int[entryCoordinateStrings.Length];

                    for (int n = 0; n < entryCoordinateStrings.Length; n++)
                    {
                        entryCoordinate[n] = Convert.ToInt32(entryCoordinateStrings[n]);
                    }

                    loadLocation.EntryCoor.Add(entryCoordinate);
                }

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

                roomTextData.Close();

                locations.Add(loadLocation);
            }
        }

        static void UpdateWorld(List<Location> locations, string[,,] world)
        {
            for (int i = 0; i < locations.Count; i++)
            {
                for (int x = locations[i].Dimensions[0]; x <= locations[i].Dimensions[0] + locations[i].Dimensions[3]; x++)
                {
                    for (int y = locations[i].Dimensions[1]; y <= locations[i].Dimensions[1] + locations[i].Dimensions[4]; y++)
                    {
                        for (int z = locations[i].Dimensions[2]; z <= locations[i].Dimensions[2] + locations[i].Dimensions[5]; z++)
                        {
                            world[x, y, z] = locations[i].Name[0].ToString();
                        }
                    }
                }
            }
        }
    }
}
