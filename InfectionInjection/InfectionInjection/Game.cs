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
            for (int i=0; i<10; i++)
            {
                Console.WriteLine(Inventory[i]);
            }
        }

        public static void Inventory_Add()
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
            string[,,] world = new string[5, 5, 3];
            for (int a = 0; a < 5; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        world[a, b, c] = "X";
                    }
                }
            }
            int[] playerCoor = { 3, 3, 0 };
            int[] playerCoorLocation = { 0, 0, 0 };
            List<Location> locations = new List<Location>();
            LoadData(locations);
            UpdateWorld(locations, world);
            GameLoop(world, playerCoor, playerCoorLocation, locations);
        }

        static void GameLoop(string[,,] world, int[] playerCoor, int[] playerCoorLocation, List<Location> locations)
        {
            Console.ResetColor();
            int index = 0;
            string input = "";
            bool firstTime = true;

            do
            {
                Console.Clear();

                Console.WriteLine($"{playerCoor[0]}, {playerCoor[1]}, {playerCoor[2]}");
                Console.WriteLine($"{playerCoorLocation[0]}, {playerCoorLocation[1]}, {playerCoorLocation[2]}\n");

                if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                {
                    for (int i = 0; i < locations.Count; i++)
                    {
                        if (world[playerCoor[0], playerCoor[1], playerCoor[2]] == locations[i].Name)
                        {
                            index = i;
                        }
                    }
                    if (firstTime)
                    {
                        playerCoorLocation[0] = locations[index].StartPos[0];
                        playerCoorLocation[1] = locations[index].StartPos[1];
                        playerCoorLocation[2] = locations[index].StartPos[2];

                        firstTime = false;
                    }
                    LocationText(locations, world, playerCoorLocation, index);
                }
                else
                {
                    Console.WriteLine("You are outside somewhere");
                    LocationCheck(playerCoor, world, locations);
                }

                Console.ResetColor();

                Console.WriteLine("\nWhat do you want to do next?");
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "n":
                        Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[1], 0, -1, 1, locations, index, ref input, ref firstTime);
                        break;
                    case "w":
                        Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[0], 0, -1, 0, locations, index, ref input, ref firstTime);
                        break;
                    case "e":
                        Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[3] - 1, playerCoorLocation[0], 1, 0, locations, index, ref input, ref firstTime);
                        break;
                    case "s":
                        Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[4]-1, playerCoorLocation[1], 1, 1, locations, index, ref input, ref firstTime);
                        break;
                    case "up":
                        Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[5] - 1, playerCoorLocation[2], 1, 2, locations, index, ref input, ref firstTime);
                        break;
                    case "down":
                        Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[2], 0, -1, 2, locations, index, ref input, ref firstTime);
                        break;
                }
            } while (input != "quit");
        }

        static void Movement(string[,,] world, int[] playerCoor, int[] playerCoorLocation, int condition1, int condition2, int num, int index, List<Location> locations, int locIndex, ref string input, ref bool firstTime)
        {
            if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
            {
                if (condition1 > condition2)
                {
                    playerCoorLocation[index] += num;
                }
                else if (index != 2)
                {
                    Console.WriteLine($"Are you sure you want to leave the {locations[locIndex].Name}?");
                    if (playerCoorLocation[2] != 0)
                    {
                        Console.WriteLine("You are not on the ground floor");
                    }

                    string choice = Console.ReadLine().ToLower();

                    if ((choice == "yes") || (choice == "y"))
                    {
                        if (playerCoorLocation[2] > 0)
                        {
                            Death(0, ref input);
                        }
                        playerCoor[index] += num;
                        playerCoorLocation[2] = 0;
                        for (int i = 0; i < playerCoorLocation.Length; i++)
                        {
                            playerCoorLocation[i] = 0;
                        }
                        firstTime = true;
                    }
                }
            }
            else
            {
                if ((playerCoor[index] + num >= 0) && (playerCoor[index] + num < 8) && (index != 2))
                {
                    playerCoor[index] += num;
                    //playerCoor[0] = x;
                    //playerCoor[1] = y;
                    //playerCoor[2] = z;
                    //Put yos text stuff here
                }
                if ((playerCoorLocation[0] != 0) && (playerCoorLocation[1] != 0) && (playerCoorLocation[2] != 0))
                {
                    for (int i = 0; i < playerCoorLocation.Length; i++)
                    {
                        playerCoorLocation[i] = 0;
                    }
                }
            }
        }

        static void Death(int number, ref string input)
        {
            string[] deaths = { "You fell to your death!" };

            Console.WriteLine(deaths[number]);
            input = "quit";
            Console.ReadLine();
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

        static void LocationText(List<Location> locations, string[,,] world, int[] playerCoorLocation, int index)
        {
            Console.WriteLine($"You are in the {locations[index].Name}");
            Console.WriteLine($"You are in the {locations[index].LocationMap[playerCoorLocation[0], playerCoorLocation[1], playerCoorLocation[2]]}");
            int roomIndex = 0;
            for (int i = 0; i < locations[index].RoomCount; i++)
            {
                if (locations[index].Rooms[i].Name == locations[index].LocationMap[playerCoorLocation[0], playerCoorLocation[1], playerCoorLocation[2]])
                {
                    roomIndex = i;
                }
            }
            if (locations[index].Rooms[roomIndex].Items.Count > 0)
            {
                Console.Write("\nThere is: \n");
            }
            for (int i = 0; i < locations[index].Rooms[roomIndex].Items.Count; i++)
            {
                Console.Write($"* {locations[index].Rooms[roomIndex].Items[i]}\n");
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

                string[] temp = locationTextData.ReadLine().Split(',');

                for (int n = 0; n < temp.Length; n++)
                {
                    loadLocation.StartPos[n] = Convert.ToInt32(temp[n]);
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

                    string[] tempItems = new string[1];
                    string items = roomTextData.ReadLine();

                    if ((items != null) && (items.Contains(",")))
                    {
                        tempItems = items.Split(',');
                    }
                    else
                    {
                        tempItems[0] = items;
                    }

                    for (int z = 0; z < tempItems.Length; z++)
                    {
                        if (tempItems[z] != "")
                        {
                            loadRoom.Items.Add(tempItems[z]);
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
