using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace InfectionInjection
{
    class Game
    {
        public static string[] Inventory = new string[10];
        public static int WrongCommand = 0;
        public static int Bullets = 5;
        public static bool GunLockerUnlocked = false;
        public static bool PoliceStationUnlocked = false;

        public static void Inventory_Show()
        {
            if (Inventory[0] != null)
            {
                Console.WriteLine("You have: ");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine((i + 1) + "| " + Inventory[i]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You don't have anyhting on you.\n");
            }
        }

        public static string Inventory_Check(string Found_Item)
        {
            string returnValue = "";
            bool space_found = false;
            bool STOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOP = false;
            for (int i = 0; i < 10; i++)
            {
                if ((Inventory[i] == null)&&(STOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOP!=true))
                {
                    space_found = true;
                    returnValue = "pickup " + Inventory[i];
                    Inventory[i] = Found_Item;
                    STOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOP = true;
                }
            }
            if (space_found == false)
            {
                bool loop = true;
                do
                {
                    Console.WriteLine("Which item slot would you like to place it in? (1,2,3,4,5,6,7,8,9,0)");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine((i+1) + "| " + Inventory[i]);
                    }
                    Console.WriteLine();
                    string Temp = Console.ReadLine();
                    switch (Temp)
                    {
                        case "1":
                            returnValue = "dump " + Inventory[0];
                            Inventory[0] = Found_Item;
                            loop = false;
                            break;
                        case "2":
                            returnValue = "dump " + Inventory[1];
                            Inventory[1] = Found_Item;
                            loop = false;
                            break;
                        case "3":
                            returnValue = "dump " + Inventory[2];
                            Inventory[2] = Found_Item;
                            loop = false;
                            break;
                        case "4":
                            returnValue = "dump " + Inventory[3];
                            Inventory[3] = Found_Item;
                            loop = false;
                            break;
                        case "5":
                            returnValue = "dump " + Inventory[4];
                            Inventory[4] = Found_Item;
                            loop = false;
                            break;
                        case "6":
                            returnValue = "dump " + Inventory[5];
                            Inventory[5] = Found_Item;
                            loop = false;
                            break;
                        case "7":
                            returnValue = "dump " + Inventory[6];
                            Inventory[6] = Found_Item;
                            loop = false;
                            break;
                        case "8":
                            returnValue = "dump " + Inventory[7];
                            Inventory[7] = Found_Item;
                            loop = false;
                            break;
                        case "9":
                            returnValue = "dump " + Inventory[8];
                            Inventory[8] = Found_Item;
                            loop = false;
                            break;
                        case "0":
                            returnValue = "dump " + Inventory[9];
                            Inventory[9] = Found_Item;
                            loop = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Sorry, I do not understand.\nPlease try again!");
                            break;
                    }
                } while (loop==true);
            }

            return (returnValue);
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
            int roomIndex = 0;
            string input = "";
            string lastPlace = "";
            bool firstTime = true;
            Random rand = new Random();
            string[] misunderstood = { "Sorry, I do not understand.", "What?", "Not a valid command.", "Do you even know how to play?", "Try again?" };

            do
            {
                try
                {
                    if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                    {
                        for (int i = 0; i < locations.Count; i++)
                        {
                            if (world[playerCoor[0], playerCoor[1], playerCoor[2]] == locations[i].Name)
                            {
                                index = i;
                                for (int n = 0; n < locations[i].RoomCount; n++)
                                {
                                    if (locations[i].Rooms[n].Name == locations[i].LocationMap[playerCoorLocation[0], playerCoorLocation[1], playerCoorLocation[2]])
                                    {
                                        roomIndex = n;
                                    }
                                }
                            }
                        }
                        if (firstTime)
                        {
                            switch (lastPlace)
                            {
                                case "north":
                                    playerCoorLocation[0] = locations[index].StartPosN[0];
                                    playerCoorLocation[1] = locations[index].StartPosN[1];
                                    playerCoorLocation[2] = locations[index].StartPosN[2];
                                    break;
                                case "west":
                                    playerCoorLocation[0] = locations[index].StartPosW[0];
                                    playerCoorLocation[1] = locations[index].StartPosW[1];
                                    playerCoorLocation[2] = locations[index].StartPosW[2];
                                    break;
                                case "east":
                                    playerCoorLocation[0] = locations[index].StartPosE[0];
                                    playerCoorLocation[1] = locations[index].StartPosE[1];
                                    playerCoorLocation[2] = locations[index].StartPosE[2];
                                    break;
                                case "south":
                                    playerCoorLocation[0] = locations[index].StartPosS[0];
                                    playerCoorLocation[1] = locations[index].StartPosS[1];
                                    playerCoorLocation[2] = locations[index].StartPosS[2];
                                    break;
                            }

                            firstTime = false;
                        }
                        LocationText(locations, world, playerCoorLocation, index);
                    }
                    else
                    {
                        Console.WriteLine("You are outside; wandering the town of Steelport.");
                        try
                        {
                            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"/Resources/data(" + playerCoor[0] + "," + playerCoor[1] + "," + playerCoor[2] + ").txt"))
                            {
                                while (!sr.EndOfStream)
                                {
                                    Console.WriteLine(sr.ReadLine());
                                }
                            }
                        }
                        catch { }
                        LocationCheck(playerCoor, world, locations);
                    }
                }
                catch
                {
                    Death(1, ref input);
                }

                if (input != "quit")
                {
                    Console.WriteLine("\nWhat do you want to do next?");
                    input = Console.ReadLine().ToLower();
                }
                Console.Clear();
                if (input.Contains(" ") == false)
                {
                    switch (input)
                    {
                        case "n":
                            lastPlace = "south";
                            Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[1], 0, -1, 1, locations, index, ref input, ref firstTime);
                            break;
                        case "north":
                            lastPlace = "south";
                            Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[1], 0, -1, 1, locations, index, ref input, ref firstTime);
                            break;
                        case "forward":
                            lastPlace = "south";
                            Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[1], 0, -1, 1, locations, index, ref input, ref firstTime);
                            break;
                        case "w":
                            lastPlace = "east";
                            Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[0], 0, -1, 0, locations, index, ref input, ref firstTime);
                            break;
                        case "west":
                            lastPlace = "east";
                            Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[0], 0, -1, 0, locations, index, ref input, ref firstTime);
                            break;
                        case "left":
                            lastPlace = "east";
                            Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[0], 0, -1, 0, locations, index, ref input, ref firstTime);
                            break;
                        case "e":
                            lastPlace = "west";
                            Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[3] - 1, playerCoorLocation[0], 1, 0, locations, index, ref input, ref firstTime);
                            break;
                        case "east":
                            lastPlace = "west";
                            Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[3] - 1, playerCoorLocation[0], 1, 0, locations, index, ref input, ref firstTime);
                            break;
                        case "right":
                            lastPlace = "west";
                            Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[3] - 1, playerCoorLocation[0], 1, 0, locations, index, ref input, ref firstTime);
                            break;
                        case "s":
                            lastPlace = "north";
                            Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[4] - 1, playerCoorLocation[1], 1, 1, locations, index, ref input, ref firstTime);
                            break;
                        case "south":
                            lastPlace = "north";
                            Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[4] - 1, playerCoorLocation[1], 1, 1, locations, index, ref input, ref firstTime);
                            break;
                        case "backward":
                            lastPlace = "north";
                            Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[4] - 1, playerCoorLocation[1], 1, 1, locations, index, ref input, ref firstTime);
                            break;
                        case "up":
                            Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[5] - 1, playerCoorLocation[2], 1, 2, locations, index, ref input, ref firstTime);
                            break;
                        case "ascend":
                            Movement(world, playerCoor, playerCoorLocation, locations[index].Dimensions[5] - 1, playerCoorLocation[2], 1, 2, locations, index, ref input, ref firstTime);
                            break;
                        case "down":
                            Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[2], 0, -1, 2, locations, index, ref input, ref firstTime);
                            break;
                        case "descend":
                            Movement(world, playerCoor, playerCoorLocation, playerCoorLocation[2], 0, -1, 2, locations, index, ref input, ref firstTime);
                            break;
                        case "inventory":
                            Inventory_Show();
                            break;
                        case "help":
                            WrongCommand = 0;
                            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Resources\help.txt"))
                            {
                                while (!sr.EndOfStream)
                                {
                                    Console.WriteLine(sr.ReadLine());
                                }
                            }
                            break;
                        default:
                            if (WrongCommand < 3)
                            {
                                Console.WriteLine($"{misunderstood[rand.Next(0, misunderstood.Length)]}\n");
                                WrongCommand++;
                            }
                            else
                            {
                                Console.WriteLine($"{misunderstood[rand.Next(0, misunderstood.Length)]}\nIf you need help with the commands type \"help\".\n");
                            }
                            break;
                    }
                }
                else
                {
                    string[] temp = input.Split(' ');
                    string command = temp[0];
                    string restOfArray = "";

                    for (int i = 1; i < temp.Length; i++)
                    {
                        restOfArray += temp[i] + " ";
                    }

                    restOfArray = restOfArray.Trim();

                    switch (command)
                    {
                        case "get":
                            if ((world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X") && (locations[index].Rooms[roomIndex].Items.Contains(restOfArray.ToLower())))
                            {
                                string[] temp2 = Inventory_Check(restOfArray).Split(' ');
                                string itemInstruction = temp2[0];
                                string restOfItemArray = "";

                                for (int i = 1; i < temp2.Length; i++)
                                {
                                    restOfItemArray += temp2[i] + " ";
                                }

                                restOfItemArray = restOfItemArray.Trim();

                                if (itemInstruction == "pickup")
                                {
                                    locations[index].Rooms[roomIndex].Items.Remove(restOfArray.ToLower());
                                }
                                else
                                {
                                    locations[index].Rooms[roomIndex].Items.Remove(restOfArray.ToLower());
                                    locations[index].Rooms[roomIndex].Items.Add(restOfItemArray.ToLower());
                                }
                            }
                            break;
                        case "drop":
                            if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                            {
                                Console.WriteLine($"Are you sure you want to drop {restOfArray}?");
                                string choice = Console.ReadLine().ToLower();
                                if ((choice == "yes") || (choice == "y"))
                                {
                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                    locations[index].Rooms[roomIndex].Items.Add(restOfArray);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Are you sure you want to drop {restOfArray}?\nYou are not in a building so it will be lost.");
                                string choice = Console.ReadLine().ToLower();
                                if ((choice == "yes") || (choice == "y"))
                                {
                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                }
                            }
                            break;
                        case "use":
                            if (Array.IndexOf(Inventory, restOfArray) >= 0)
                            {
                                if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                                {
                                    if ((locations[index].Rooms[roomIndex].Name == "Armory") && (GunLockerUnlocked == false) && (restOfArray == "small key"))
                                    {
                                        GunLockerUnlocked = true;
                                        Console.WriteLine("Unlocked Gun Locker.\n");
                                    }
                                    else if ((locations[index].Rooms[roomIndex].Name == "Armory") && (GunLockerUnlocked) && (restOfArray == "small key"))
                                    {
                                        Console.WriteLine("Already Unlocked.\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Can't use that.\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Can't use that.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You don't have that item.\n");
                            }
                            break;
                        case "search":
                            if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                            {
                                if ((locations[index].Rooms[roomIndex].Name == "Armory") && (GunLockerUnlocked) && (restOfArray == "gun locker"))
                                {
                                    Search("gun locker", 6, 4, locations, input, playerCoor, world);
                                }
                                else if ((locations[index].Rooms[roomIndex].Name == "Armory") && (GunLockerUnlocked == false) && (restOfArray == "gun locker"))
                                {
                                    Console.WriteLine("The Gun Locker is locked.");
                                }
                                if ((locations[index].Rooms[roomIndex].Name == "Ward 2") && ((restOfArray == "commissioner's body") || (restOfArray == "commissioners body") || (restOfArray == "commissioner")))
                                {
                                    Search("commissioner's body", 3, 8, locations, input, playerCoor, world);
                                }
                                else
                                {
                                    Console.WriteLine("Can't do that.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Can't do that.\n");
                            }
                            break;
                        default:
                            if (WrongCommand < 3)
                            {
                                Console.WriteLine($"{misunderstood[rand.Next(0, misunderstood.Length)]}\n");
                                WrongCommand++;
                            }
                            else
                            {
                                Console.WriteLine($"{misunderstood[rand.Next(0, misunderstood.Length)]}\nIf you need help with the commands type \"help\".\n");
                            }
                            break;
                    }
                }
            } while (input != "quit");
        }

        static void Search(string searchPlace, int locNum, int roomNum, List<Location> locations, string input, int[] playerCoor, string[,,] world)
        {
            do
            {
                Console.WriteLine($"In the {searchPlace} you found:");

                if ((locations[locNum].Rooms[roomNum].Items.Count > 0) && (locations[locNum].Rooms[roomNum].Items[0] != null))
                {
                    for (int i = 0; i < locations[locNum].Rooms[roomNum].Items.Count; i++)
                    {
                        Console.Write($"* {locations[locNum].Rooms[roomNum].Items[i]}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing.");
                }

                Console.WriteLine("\nWhat do you want to do next?");
                input = Console.ReadLine().ToLower();
                Console.Clear();
                if (input.Contains(" ") == false)
                {
                    switch (input)
                    {
                        case "back":
                            break;
                        default:
                            Console.WriteLine("When searching type [Get] \"item name\" or [Back].\n");
                            break;
                    }
                }
                else
                {
                    string[] temp = input.Split(' ');
                    string command = temp[0];
                    string restOfArray = "";

                    for (int i = 1; i < temp.Length; i++)
                    {
                        restOfArray += temp[i] + " ";
                    }

                    restOfArray = restOfArray.Trim();

                    switch (command)
                    {
                        case "get":
                            if ((world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X") && (locations[locNum].Rooms[roomNum].Items.Contains(restOfArray.ToLower())))
                            {
                                string[] temp2 = Inventory_Check(restOfArray).Split(' ');
                                string itemInstruction = temp2[0];
                                string restOfItemArray = "";

                                for (int i = 1; i < temp2.Length; i++)
                                {
                                    restOfItemArray += temp2[i] + " ";
                                }

                                restOfItemArray = restOfItemArray.Trim();

                                if (itemInstruction == "pickup")
                                {
                                    locations[locNum].Rooms[roomNum].Items.Remove(restOfArray.ToLower());
                                }
                                else
                                {
                                    locations[locNum].Rooms[roomNum].Items.Remove(restOfArray.ToLower());
                                    locations[locNum].Rooms[roomNum].Items.Add(restOfItemArray.ToLower());
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("When searching type [Get] \"item name\" or [Back].\n");
                            break;
                    }
                }
            } while (input != "back");
        }

        static void Movement(string[,,] world, int[] playerCoor, int[] playerCoorLocation, int condition1, int condition2, int num, int index, List<Location> locations, int locIndex, ref string input, ref bool firstTime)
        {
            if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
            {
                if (condition1 > condition2)
                {
                    if ((locations[locIndex].Name != "Sewer Entrance North") && (locations[locIndex].Name != "Sewer Entrance South") && (locations[locIndex].Name != "Sewer Entrance West") && (locations[locIndex].Name != "North Forest") && (locations[locIndex].Name != "West Forest") && (locations[locIndex].Name != "South Forest"))
                    {
                        playerCoorLocation[index] += num;
                    }
                    else if ((locations[locIndex].Name == "Sewer Entrance North") || (locations[locIndex].Name == "Sewer Entrance South") || (locations[locIndex].Name == "Sewer Entrance West"))
                    {
                        switch (index)
                        {
                            case 0:
                                if (locations[locIndex].LocationMap[playerCoorLocation[0] + num, playerCoorLocation[1], playerCoorLocation[2]] != "wall")
                                {
                                    playerCoorLocation[index] += num;
                                }
                                else
                                {
                                    Console.WriteLine("You can't go that way, it's blocked by the Sewer wall.\n");
                                }
                                break;
                            case 1:
                                if (locations[locIndex].LocationMap[playerCoorLocation[0], playerCoorLocation[1] + num, playerCoorLocation[2]] != "wall")
                                {
                                    playerCoorLocation[index] += num;
                                }
                                else
                                {
                                    Console.WriteLine("You can't go that way, it's blocked by the Sewer wall.\n");
                                }
                                break;
                            case 2:
                                if (locations[locIndex].LocationMap[playerCoorLocation[0], playerCoorLocation[1], playerCoorLocation[2] + num] != "wall")
                                {
                                    switch (locations[locIndex].LocationMap[playerCoorLocation[0], playerCoorLocation[1], playerCoorLocation[2]])
                                    {
                                        case "Sewer Exit West":
                                            playerCoor[0] = 0;
                                            playerCoor[1] = 3;
                                            playerCoor[2] = 0;
                                            playerCoorLocation[0] = 0;
                                            playerCoorLocation[1] = 0;
                                            playerCoorLocation[2] = 0;
                                            firstTime = true;
                                            break;
                                        case "Sewer Exit Hospital":
                                            playerCoor[0] = 2;
                                            playerCoor[1] = 2;
                                            playerCoor[2] = 0;
                                            playerCoorLocation[0] = 0;
                                            playerCoorLocation[1] = 0;
                                            playerCoorLocation[2] = 0;
                                            firstTime = true;
                                            break;
                                        case "Sewer Exit North":
                                            playerCoor[0] = 3;
                                            playerCoor[1] = 1;
                                            playerCoor[2] = 0;
                                            playerCoorLocation[0] = 0;
                                            playerCoorLocation[1] = 0;
                                            playerCoorLocation[2] = 0;
                                            firstTime = true;
                                            break;
                                        case "Sewer Exit Police Station":
                                            playerCoor[0] = 4;
                                            playerCoor[1] = 1;
                                            playerCoor[2] = 0;
                                            playerCoorLocation[0] = 0;
                                            playerCoorLocation[1] = 0;
                                            playerCoorLocation[2] = 0;
                                            firstTime = true;
                                            break;
                                        case "Sewer Exit South":
                                            playerCoor[0] = 3;
                                            playerCoor[1] = 4;
                                            playerCoor[2] = 0;
                                            playerCoorLocation[0] = 0;
                                            playerCoorLocation[1] = 0;
                                            playerCoorLocation[2] = 0;
                                            firstTime = true;
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You can't go that way, it's blocked by the Sewer wall.\n");
                                }
                                break;
                        }
                    }
                    else if ((locations[locIndex].Name == "North Forest") || (locations[locIndex].Name == "West Forest") || (locations[locIndex].Name == "South Forest"))
                    {
                        switch (index)
                        {
                            case 0:
                                if (locations[locIndex].LocationMap[playerCoorLocation[0] + num, playerCoorLocation[1], playerCoorLocation[2]] != "wall")
                                {
                                    playerCoorLocation[index] += num;
                                }
                                else
                                {
                                    int roomIndex = 0;

                                    for (int i = 0; i < locations[locIndex].RoomCount; i++)
                                    {
                                        if (((playerCoorLocation[0] + num) == locations[locIndex].Rooms[i].Coor[0]) && ((playerCoorLocation[1]) == locations[locIndex].Rooms[i].Coor[1]) && ((playerCoorLocation[2]) == locations[locIndex].Rooms[i].Coor[2]))
                                        {
                                            roomIndex = i;
                                        }
                                    }
                                    Console.WriteLine("Can't go that way; " + locations[locIndex].Rooms[roomIndex].Description + "\n");
                                }
                                break;
                            case 1:
                                if (locations[locIndex].LocationMap[playerCoorLocation[0], playerCoorLocation[1] + num, playerCoorLocation[2]] != "wall")
                                {
                                    playerCoorLocation[index] += num;
                                }
                                else
                                {
                                    int roomIndex = 0;

                                    for (int i = 0; i < locations[locIndex].RoomCount; i++)
                                    {
                                        if (((playerCoorLocation[0]) == locations[locIndex].Rooms[i].Coor[0]) && ((playerCoorLocation[1] + num) == locations[locIndex].Rooms[i].Coor[1]) && ((playerCoorLocation[2]) == locations[locIndex].Rooms[i].Coor[2]))
                                        {
                                            roomIndex = i;
                                        }
                                    }
                                    Console.WriteLine("Can't go that way; " + locations[locIndex].Rooms[roomIndex].Description + "\n");
                                }
                                break;
                        }
                    }
                }
                else if (index != 2)
                {
                    int[] mapDim = { 4, 4, 2 };

                    if ((locations[locIndex].Name != "Sewer Entrance North") && (locations[locIndex].Name != "Sewer Entrance South") && (locations[locIndex].Name != "Sewer Entrance West"))
                    {
                        Console.WriteLine($"Are you sure you want to leave the {locations[locIndex].Name}?");
                        if (((playerCoor[index] + num) > mapDim[index]) || ((playerCoor[index] + num) < 0))
                        {
                            Console.WriteLine("CAUTION! - You are about to leave the town");
                        }
                        if (playerCoorLocation[2] != 0)
                        {
                            Console.WriteLine("You are not on the ground floor");
                        }

                        string choice = Console.ReadLine().ToLower();
                        Console.Clear();

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
                    else
                    {
                        Console.WriteLine("You can't go that way, it's blocked by the Sewer wall.\n");
                    }
                }
            }
            else
            {
                if (index != 2)
                {
                    switch (index)
                    {
                        case 0:
                            if (((playerCoor[0] + num) == locations[6].Dimensions[0]) && (playerCoor[1] == locations[6].Dimensions[1]) && (playerCoor[2] == locations[6].Dimensions[2]) && PoliceStationUnlocked)
                            {
                                playerCoor[index] += num;
                            }
                            else if (((playerCoor[0] + num) == locations[6].Dimensions[0]) && (playerCoor[1] == locations[6].Dimensions[1]) && (playerCoor[2] == locations[6].Dimensions[2]) && (PoliceStationUnlocked == false))
                            {
                                if (Array.IndexOf(Inventory, "building key") >= 0)
                                {
                                    PoliceStationUnlocked = true;
                                    Console.WriteLine("Police Station Unlocked.\n");
                                }
                                else
                                {
                                    Console.WriteLine("The Police Station is Locked and you don't have the key.\n");
                                }
                            }
                            else
                            {
                                playerCoor[index] += num;
                            }
                            break;
                        case 1:
                            if (((playerCoor[1] + num) == locations[6].Dimensions[1]) && (playerCoor[0] == locations[6].Dimensions[0]) && (playerCoor[2] == locations[6].Dimensions[2]) && PoliceStationUnlocked)
                            {
                                playerCoor[index] += num;
                            }
                            else if (((playerCoor[1] + num) == locations[6].Dimensions[1]) && (playerCoor[0] == locations[6].Dimensions[0]) && (playerCoor[2] == locations[6].Dimensions[2]) && (PoliceStationUnlocked == false))
                            {
                                if (Array.IndexOf(Inventory, "building key") >= 0)
                                {
                                    PoliceStationUnlocked = true;
                                    Console.WriteLine("Police Station Unlocked.\n");
                                }
                                else
                                {
                                    Console.WriteLine("The Police Station is Locked and you don't have the key.\n");
                                }
                            }
                            else
                            {
                                playerCoor[index] += num;
                            }
                            break;
                        case 2:
                            if (((playerCoor[2] + num) == locations[6].Dimensions[2]) && (playerCoor[1] == locations[6].Dimensions[1]) && (playerCoor[0] == locations[6].Dimensions[0]) && PoliceStationUnlocked)
                            {
                                playerCoor[index] += num;
                            }
                            else if (((playerCoor[2] + num) == locations[6].Dimensions[2]) && (playerCoor[1] == locations[6].Dimensions[1]) && (playerCoor[0] == locations[6].Dimensions[0]) && (PoliceStationUnlocked == false))
                            {
                                if (Array.IndexOf(Inventory, "building key") >= 0)
                                {
                                    PoliceStationUnlocked = true;
                                    Console.WriteLine("Police Station Unlocked.\n");
                                }
                                else
                                {
                                    Console.WriteLine("The Police Station is Locked and you don't have the key.\n");
                                }
                            }
                            else
                            {
                                playerCoor[index] += num;
                            }
                            break;
                    }
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
            string[] deaths = { "You fell to your death!", "As you attempt to flee from the town, you hear a thumping through the ground.\nAs you turn in horror towards the vibrations, you see a horde of green shambling corpses running towards you at a speed you couldn't believe was possible.\nYou try desperately to run.\nYour last thoughts on how you failed this town and have doomed this world to a zombie apocalypse." };

            Console.WriteLine(deaths[number]);
            input = "quit";
            Console.ReadLine();
        }

        static void LocationCheck(int[] playerCoor, string[,,] world, List<Location> locations)
        {
            int index = 0;
            string north = "";
            string west = "";
            string east = "";
            string south = "";

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
                    east = $"The {locations[index].Name} is to the East";
                }
            }
            catch
            {
                east = "X";
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
                    west = $"The {locations[index].Name} is to the West";
                }
            }
            catch
            {
                west = "X";
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
                    south = $"The {locations[index].Name} is to the South";
                }
            }
            catch
            {
                south = "X";
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
                    north = $"The {locations[index].Name} is to the North";
                }
            }
            catch
            {
                north = "X";
            }

            if (north == "X")
            {
                Console.WriteLine($"CAUTION! - If you go North you will leave the town.");
            }
            if (west == "X")
            {
                Console.WriteLine($"CAUTION! - If you go West you will leave the town.");
            }
            if (east == "X")
            {
                Console.WriteLine($"CAUTION! - If you go East you will leave the town.");
            }
            if (south == "X")
            {
                Console.WriteLine($"CAUTION! - If you go South you will leave the town");
            }

            if ((north != "X") && (north != ""))
            {
                Console.WriteLine(north);
            }
            if ((west != "X") && (west != ""))
            {
                Console.WriteLine(west);
            }
            if ((east != "X") && (east != ""))
            {
                Console.WriteLine(east);
            }
            if ((south != "X") && (south != ""))
            {
                Console.WriteLine(south);
            }
        }

        static void LocationText(List<Location> locations, string[,,] world, int[] playerCoorLocation, int index)
        {
            if ((locations[index].Name != "Sewer Entrance North") && (locations[index].Name != "Sewer Entrance West") && (locations[index].Name != "Sewer Entrance South") && (locations[index].Name != "South Forest") && (locations[index].Name != "North Forest") && (locations[index].Name != "West Forest"))
            {
                Console.WriteLine($"You are in the {locations[index].Name}");
                Console.WriteLine($"You are in the {locations[index].LocationMap[playerCoorLocation[0], playerCoorLocation[1], playerCoorLocation[2]]}");
            }
            else if ((locations[index].Name == "Sewer Entrance North") || (locations[index].Name == "Sewer Entrance West") || (locations[index].Name == "Sewer Entrance South"))
            {
                Console.WriteLine("You are in the Sewer");
            }
            else if ((locations[index].Name == "South Forest") || (locations[index].Name == "North Forest") || (locations[index].Name == "West Forest"))
            {
                Console.WriteLine("You are in a Forest");
            }
            int roomIndex = 0;
            for (int i = 0; i < locations[index].RoomCount; i++)
            {
                if ((locations[index].Rooms[i].Coor[0] == playerCoorLocation[0]) && (locations[index].Rooms[i].Coor[1] == playerCoorLocation[1]) && (locations[index].Rooms[i].Coor[2] == playerCoorLocation[2]))
                {
                    roomIndex = i;
                }
            }
            Console.WriteLine(locations[index].Rooms[roomIndex].Description);
            if ((locations[index].Rooms[roomIndex].Items.Count > 0) && (locations[index].Rooms[roomIndex].Items[0] != null))
            {
                Console.Write("\nThere is: \n");
                for (int i = 0; i < locations[index].Rooms[roomIndex].Items.Count; i++)
                {
                    Console.Write($"* {locations[index].Rooms[roomIndex].Items[i]}\n");
                }
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
                    loadLocation.StartPosN[n] = Convert.ToInt32(temp[n]);
                }

                string[] temp2 = locationTextData.ReadLine().Split(',');

                for (int n = 0; n < temp.Length; n++)
                {
                    loadLocation.StartPosW[n] = Convert.ToInt32(temp2[n]);
                }

                string[] temp3 = locationTextData.ReadLine().Split(',');

                for (int n = 0; n < temp.Length; n++)
                {
                    loadLocation.StartPosE[n] = Convert.ToInt32(temp3[n]);
                }

                string[] temp4 = locationTextData.ReadLine().Split(',');

                for (int n = 0; n < temp.Length; n++)
                {
                    loadLocation.StartPosS[n] = Convert.ToInt32(temp4[n]);
                }

                locationTextData.Close();

                for (int n = 0; n < loadLocation.RoomCount; n++)
                {
                    Room loadRoom = new Room();
                    loadRoom.Name = roomTextData.ReadLine();
                    loadRoom.Description = roomTextData.ReadLine();

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
                
                

            }
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\locationData.txt");
            while (!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
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
