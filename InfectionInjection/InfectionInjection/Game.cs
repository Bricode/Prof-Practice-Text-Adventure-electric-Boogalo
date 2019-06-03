using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace InfectionInjection
{
    class Game
    {
        public static string[] Inventory = new string[10];
        public static string Found_Item;
        public static void Inventory_Check()
        {
            bool space_found = false;
            bool STOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOP = false;
            for (int i = 0; i < 10; i++)
            {
                if ((Inventory[i] == null)&&(STOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOP!=true))
                {
                    space_found = true;
                    Inventory[i] = Found_Item;
                    STOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOP = true;
                }
            }
            if (space_found == false)
            {
                bool loop = true;
                do
                {
                    Console.WriteLine("Which item slot would you like to replace? (1,2,3,4,5,6,7,8,9,0)");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(i + "|" + Inventory[i]);
                    }
                    string Temp = Console.ReadLine();
                    switch (Temp)
                    {
                        case "1":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "2":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "3":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "4":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "5":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "6":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "7":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "8":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "9":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "0":
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("Sorry, I do not understand.\nPlease try again!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }
                } while (loop==true);
            }
        }
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
            int[] playerCoor = { 0, 0, 0 };
            int[] playerCoorLocation = { 0, 0, 0 };
            List<Location> locations = new List<Location>();
            LoadData(locations);
            UpdateWorld(locations, world);

            
            //Console.WriteLine("Map of World\n");
            //Map(world);
            Console.ResetColor();
            int floor = 0;
            int locationNum = 0;
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine($"{playerCoor[0]}, {playerCoor[1]}, {playerCoor[2]}\n");
                Console.WriteLine($"Map of inside {locations[locationNum].Name}\n");
                LocationMap(locations, floor, locationNum, world, playerCoor);
                Console.ResetColor();
                LocationCheck(playerCoor, world, locations);
                Console.Write("\nInput direction: ");
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "n":
                        if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                        {
                            playerCoorLocation[1]--;
                        }
                        else
                        {
                            playerCoor[1]--;
                            if ((playerCoorLocation[0] != 0) && (playerCoorLocation[1] != 0) && (playerCoorLocation[2] != 0))
                            {
                                for (int i = 0; i < playerCoorLocation.Length; i++)
                                {
                                    playerCoorLocation[i] = 0;
                                }
                            }
                        }
                        break;
                    case "w":
                        playerCoor[0]--;
                        break;
                    case "e":
                        playerCoor[0]++;
                        break;
                    case "s":
                        playerCoor[1]++;
                        break;
                    case "up":
                        playerCoor[2]++;
                        break;
                    case "down":
                        playerCoor[2]--;
                        break;
                }
            } while (input != "");
        }

        static void LocationCheck(int[] playerCoor, string[,,] world, List<Location> locations)
        {
            int index = 0;

            try
            {
                if (world[playerCoor[0] + 1, playerCoor[1], playerCoor[2]] != "X")
                {
                    for (int i = 0; i < locations.Count; i++)
                    {
                        if (world[playerCoor[0] + 1, playerCoor[1], playerCoor[2]] == locations[i].Name)
                        {
                            index = i;
                        }
                    }
                    Console.WriteLine($"The {locations[index].Name} is to the East");
                }
            }
            catch
            {
                Console.WriteLine($"You cannot go the East");
            }
            try
            {
                if (world[playerCoor[0] - 1, playerCoor[1], playerCoor[2]] != "X")
                {
                    for (int i = 0; i < locations.Count; i++)
                    {
                        if (world[playerCoor[0] - 1, playerCoor[1], playerCoor[2]] == locations[i].Name)
                        {
                            index = i;
                        }
                    }
                    Console.WriteLine($"The {locations[index].Name} is to the West");
                }
            }
            catch
            {
                Console.WriteLine($"You cannot go the West");
            }
            try
            {
                if (world[playerCoor[0], playerCoor[1] + 1, playerCoor[2]] != "X")
                {
                    for (int i = 0; i < locations.Count; i++)
                    {
                        if (world[playerCoor[0], playerCoor[1] + 1, playerCoor[2]] == locations[i].Name)
                        {
                            index = i;
                        }
                    }
                    Console.WriteLine($"The {locations[index].Name} is to the South");
                }
            }
            catch
            {
                Console.WriteLine($"You cannot go the South");
            }
            try
            {
                if (world[playerCoor[0], playerCoor[1] - 1, playerCoor[2]] != "X")
                {
                    for (int i = 0; i < locations.Count; i++)
                    {
                        if (world[playerCoor[0], playerCoor[1] - 1, playerCoor[2]] == locations[i].Name)
                        {
                            index = i;
                        }
                    }
                    Console.WriteLine($"The {locations[index].Name} is to the North");
                }
            }
            catch
            {
                Console.WriteLine($"You cannot go the North");
            }
        }

        static void Map(string[,,] world)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (world[x, y, 0] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(world[x, y, 0].PadRight(15).PadLeft(15));
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void LocationMap(List<Location> locations, int floor, int locationNum, string[,,] world, int[] playerCoor)
        {
            for (int y = 0; y < locations[locationNum].Dimensions[4]; y++)
            {
                for (int x = 0; x < locations[locationNum].Dimensions[3]; x++)
                {
                    if (locations[locationNum].LocationMap[x, y, floor] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (locations[locationNum].LocationMap[x, y, floor] == "Hallway")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if ((world[playerCoor[0], playerCoor[1], playerCoor[2]] == locations[locationNum].Name) && (playerCoor[0]-locations[locationNum].Dimensions[0] == x) && (playerCoor[1] - locations[locationNum].Dimensions[1] == y))
                    {
                        Console.Write("1".PadRight(15).PadLeft(15));
                    }
                    else
                    {
                        Console.Write(locations[locationNum].LocationMap[x, y, floor].PadRight(15).PadLeft(15));
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
            string[] mapX = { "8", "7", "6" };
            string[] mapy = { "1", "2", "3" };
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

                loadLocation.RoomCount = Convert.ToInt32(locationTextData.ReadLine());

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

                    string[] temp = roomTextData.ReadLine().Split(',');
                    for (int z = 0; z < temp.Length; z++)
                    {
                        if (temp[z] != "")
                        {
                            loadRoom.Items.Add(temp[z]);
                        }
                    }

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
                StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\locationData.txt");
                string[] openingText = { sr.ReadLine() };
                Console.WriteLine(openingText[0]);
            }
        }

        static void UpdateWorld(List<Location> locations, string[,,] world)
        {
            for (int i = 0; i < locations.Count; i++)
            {
                world[locations[i].Dimensions[0], locations[i].Dimensions[1], locations[i].Dimensions[2]] = locations[i].Name;

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
                        }
                    }
                }
            }
        }
    }
}
