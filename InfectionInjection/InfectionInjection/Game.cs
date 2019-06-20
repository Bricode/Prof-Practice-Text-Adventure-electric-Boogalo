//Correct Formula = Flesh (26) + N29 + N52 + 63 + 156 + 122

using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace InfectionInjection
{
    public class Game
    {
        public static string[] Inventory = new string[10];
        public static int WrongCommand = 0;
        public static int Bullets = 5;
        public static bool GunLockerUnlocked = false;
        public static bool PoliceStationUnlocked = false;
        public static bool TorchIsEnabled = false;
        public static bool ZombiePresent = false;
        public static int ViralImmunity = 75;
        public static int Health = 100;
        public static bool WorkbenchExists = false;
        public static int DeathCount = 0;

        public static void Inventory_Show()
        {
            bool empty = true;

            for (int i = 0; i < Inventory.Length; i++)
            {
                if (Inventory[i] != null)
                {
                    empty = false;
                    break;
                }
            }

            if (!empty)
            {
                Console.WriteLine("You have: ");
                for (int i = 0; i < 10; i++)
                {
                    if (Inventory[i] != null)
                    {
                        if (i < 9)
                        {
                            Console.WriteLine(" " + (i + 1) + "| " + Inventory[i][0].ToString().ToUpper() + Inventory[i].Substring(1));
                        }
                        else
                        {
                            Console.WriteLine((i + 1) + "| " + Inventory[i][0].ToString().ToUpper() + Inventory[i].Substring(1));
                        }
                    }
                    else
                    {
                        if (i < 9)
                        {
                            Console.WriteLine(" " + (i + 1) + "| ");
                        }
                        else
                        {
                            Console.WriteLine((i + 1) + "| ");
                        }
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You don't have anything on you.\n");
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
                    Console.WriteLine("Which item slot would you like to place it in? (1,2,3,4,5,6,7,8,9,10)");
                    for (int i = 0; i < 10; i++)
                    {
                        if (i < 9)
                        {
                            Console.WriteLine(" " + (i + 1) + "| " + Inventory[i][0].ToString().ToUpper() + Inventory[i].Substring(1));
                        }
                        else
                        {
                            Console.WriteLine((i + 1) + "| " + Inventory[i][0].ToString().ToUpper() + Inventory[i].Substring(1));
                        }
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
                        case "10":
                            returnValue = "dump " + Inventory[9];
                            Inventory[9] = Found_Item;
                            loop = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Sorry, I do not understand.\nPlease try again!");
                            break;
                    }
                } while (loop);
            }

            return (returnValue);
        }

        static void Main(string[] args)
        {
            string game = "";
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

            List<Location> locations = new List<Location>();
            WorkbenchClass workbench = new WorkbenchClass();

            do
            {
                int[] playerCoor = { 0, 0, 0 };
                int[] playerCoorLocation = { 0, 0, 0 };
                
                Console.Clear();
                Console.WriteLine(@"
▀█▀ █▀▀▄ █▀▀ █▀▀ █▀▀ ▀▀█▀▀ ░▀░ █▀▀█ █▀▀▄ 
▒█░ █░░█ █▀▀ █▀▀ █░░ ░░█░░ ▀█▀ █░░█ █░░█ 
▄█▄ ▀░░▀ ▀░░ ▀▀▀ ▀▀▀ ░░▀░░ ▀▀▀ ▀▀▀▀ ▀░░▀ 

▀█▀ █▀▀▄ ░░▀ █▀▀ █▀▀ ▀▀█▀▀ ░▀░ █▀▀█ █▀▀▄ 
▒█░ █░░█ ░░█ █▀▀ █░░ ░░█░░ ▀█▀ █░░█ █░░█ 
▄█▄ ▀░░▀ █▄█ ▀▀▀ ▀▀▀ ░░▀░░ ▀▀▀ ▀▀▀▀ ▀░░▀" + "\n");
                if (game != "death")
                {
                    LoadData(locations);
                    UpdateWorld(locations, world);
                }
                else
                {
                    Console.WriteLine("You somehow managed to respawn back at the start with all your things.\nThanks to someone watching over you, humanity now has a second chance.\n");
                }
                game = GameLoop(world, playerCoor, playerCoorLocation, locations, workbench);
            } while (game != "quit");
        }

        static string GameLoop(string[,,] world, int[] playerCoor, int[] playerCoorLocation, List<Location> locations, WorkbenchClass workbench)
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
                        Console.WriteLine("Viral Immunity: " + ViralImmunity);
                        Console.WriteLine("Health: " + Health);
                        Console.WriteLine();

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
                        TorchIsEnabled = false;
                        Console.WriteLine("Viral Immunity: " + ViralImmunity);
                        Console.WriteLine("Health: " + Health);
                        Console.WriteLine();
                        Console.WriteLine("You are outside; wandering the town of Steelport.\n");
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

                if ((input != "quit") && (input != "death"))
                {
                    Console.WriteLine("\nWhat do you want to do next?");
                    input = Console.ReadLine().ToLower().Trim();
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
                        case "i":
                            Inventory_Show();
                            break;
                        case "workbench":
                            if ((world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X") && (locations[index].Rooms[roomIndex].Name == "Main Labratory"))
                            {
                                Workbench(locations, index, roomIndex, input, playerCoor, world, workbench);
                            }
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
                            if (WrongCommand < 1)
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

                    if (restOfArray.Contains("beakers"))
                    {
                        restOfArray = restOfArray.Replace("s", "S");
                    }

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
                            else
                            {
                                Console.WriteLine("Can't do that.\n");
                            }
                            break;
                        case "drop":
                            if (Array.IndexOf(Inventory, restOfArray) >= 0)
                            {
                                if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                                {
                                    Console.WriteLine($"Are you sure you want to drop {restOfArray}? - [Y]es or [N]o");
                                    string choice = Console.ReadLine().ToLower();
                                    Console.Clear();
                                    if ((choice == "yes") || (choice == "y"))
                                    {
                                        Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                        locations[index].Rooms[roomIndex].Items.Add(restOfArray);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Are you sure you want to drop {restOfArray}? - [Y]es or [N]o\nYou are not in a building so it will be lost.");
                                    string choice = Console.ReadLine().ToLower();
                                    Console.Clear();
                                    if ((choice == "yes") || (choice == "y"))
                                    {
                                        Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("You don't have that item.\n");
                            }
                            break;
                        case "use":
                            if (Array.IndexOf(Inventory, restOfArray) >= 0)
                            {
                                if (restOfArray == "cure")
                                {
                                    Death(9, ref input);
                                }
                                if (restOfArray.Contains("beakerS"))
                                {
                                    if (workbench.Viable)
                                    {
                                        if (workbench.BeakerVitality == 286)
                                        {
                                            Console.WriteLine("Test SUCCEEDED - You found the CURE!\n");
                                            workbench.ToolOnWorkBench = "";
                                            Inventory[Array.IndexOf(Inventory, "beakerS" + workbench.BeakerVitality.ToString())] = "cure";
                                            workbench.BeakerVitality = 0;

                                            int count = workbench.ItemsInBeaker.Count;

                                            for (int i = 0; i < count; i++)
                                            {
                                                workbench.ItemsInBeaker.Remove(workbench.ItemsInBeaker[0]);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Test FAILED - Solution wrong vitality ratio.\nSolution destroyed.\nSample destroyed.\n");
                                            workbench.ToolOnWorkBench = "";
                                            Inventory[Array.IndexOf(Inventory, "beakerS" + workbench.BeakerVitality.ToString())] = "beaker";
                                            workbench.BeakerVitality = 0;

                                            int count = workbench.ItemsInBeaker.Count;

                                            for (int i = 0; i < count; i++)
                                            {
                                                workbench.ItemsInBeaker.Remove(workbench.ItemsInBeaker[0]);
                                            }

                                            Death(8, ref input);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Test FAILED - Solution is missing zombie flesh sample.\nSolution destroyed.\nSample destroyed.\n");
                                        workbench.ToolOnWorkBench = "";
                                        Inventory[Array.IndexOf(Inventory, "beakerS" + workbench.BeakerVitality.ToString())] = "beaker";
                                        workbench.BeakerVitality = 0;

                                        int count = workbench.ItemsInBeaker.Count;

                                        for (int i = 0; i < count; i++)
                                        {
                                            workbench.ItemsInBeaker.Remove(workbench.ItemsInBeaker[0]);
                                        }

                                        Death(8, ref input);
                                    }
                                }
                                if (restOfArray == "note")
                                {
                                    Console.Clear();
                                    Console.WriteLine("" +
                                        " __________________________________________________________________________\n" +
                                        "|                                                                          |\n" +
                                        "|                                                                          |\n" +
                                        "|                                                                          |\n" +
                                        "|                                                                          |\n" +
                                        "|      Dear Jeff,                                                          |\n" +
                                        "|                                                                          |\n" +
                                        "|                                                                          |\n" +
                                        "|      I'm writing to inform you on the situation for when you             |\n" +
                                        "|      get back. There has been a containment breach at the Steelport      |\n" +
                                        "|      laboratory. The infection is spreading rapidly and has              |\n" +
                                        "|      infected the new development to the South. The Steelport Tower      |\n" +
                                        "|      apartment complex is crowded with the helpless and infected.        |\n" +
                                        "|      We need URGENT assistance. You will need to come to the             |\n" +
                                        "|      Steelport Tower to collect samples to synthesize a cure. I          |\n" +
                                        "|      urge you to bring a weapon as a means to protect yourself as        |\n" +
                                        "|      we are no longer ourselves. DO NOT enter the Steelport tower        |\n" +
                                        "|      directly - find another access point. Take the samples to the       |\n" +
                                        "|      research lab to the North. Once there, use the chemicals to         |\n" +
                                        "|      create a solution that matches the chemical vitality ratio          |\n" +
                                        "|      of 286, once the sample has been added.                             |\n" +
                                        "|                                                                          |\n" +
                                        "|      Good Luck. You're our only hope.                                    |\n" +
                                        "|                                                                          |\n" +
                                        "|                                                                          |\n" +
                                        "|                                                                          |\n" +
                                        "|      |\\ |)                                                               |\n" +
                                        "|      |/ |/\\  /|/|                                                        |\n" +
                                        "|      |_/|  |/ | |_/                                                      |\n" +
                                        "|      |)                                                                  |\n" +
                                        "|                                                                          |\n" +
                                        "|      - Frank                                                             |\n" +
                                        "|                                                                          |\n" +
                                        "|      Manager of WHO Steelport Lab                                        |\n" +
                                        "|                                                                          |\n" +
                                        "|                                                                          |\n" +
                                        "|                                                                          |\n" +
                                        "|                                                                          |\n" +
                                        " ==========================================================================\n");
                                    Console.WriteLine("Press enter to continue.");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                if (restOfArray == "bandage")
                                {
                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                    Health += 5;
                                    if (Health > 100)
                                    {
                                        Health = 100;
                                    }
                                }
                                else if ((restOfArray == "first aid kit") || (restOfArray == "blood bag"))
                                {
                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                    if (restOfArray == "blood bag")
                                    {
                                        if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                                        {
                                            locations[index].Rooms[roomIndex].Items.Add("empty medical bag");
                                        }
                                        Health += 20;
                                        if (Health > 100)
                                        {
                                            Health = 100;
                                        }
                                    }
                                    else
                                    {
                                        if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                                        {
                                            locations[index].Rooms[roomIndex].Items.Add("empty first aid kit");
                                        }
                                        Health += 10;
                                        if (Health > 100)
                                        {
                                            Health = 100;
                                        }
                                    }
                                }
                                else if ((restOfArray == "antibiotics") || (restOfArray == "vaccine"))
                                {
                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                    if ((restOfArray == "vaccine") && (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X"))
                                    {
                                        locations[index].Rooms[roomIndex].Items.Add("empty syringe");
                                        ViralImmunity += 20;
                                        if (ViralImmunity > 75)
                                        {
                                            ViralImmunity = 75;
                                        }
                                    }
                                    else if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                                    {
                                        locations[index].Rooms[roomIndex].Items.Add("empty container");
                                        ViralImmunity += 10;
                                        if (ViralImmunity > 75)
                                        {
                                            ViralImmunity = 75;
                                        }
                                    }
                                }
                                else if (restOfArray == "vitamins")
                                {
                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                    if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                                    {
                                        locations[index].Rooms[roomIndex].Items.Add("empty container");
                                        ViralImmunity += 5;
                                        if (ViralImmunity > 75)
                                        {
                                            ViralImmunity = 75;
                                        }
                                    }
                                }
                                else if (restOfArray == "hospital food")
                                {
                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                    if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                                    {
                                        locations[index].Rooms[roomIndex].Items.Add("empty tray");
                                    }
                                    Console.WriteLine("You ate the hospital food which was infested with bacteria.\nYou vomited several times and you feel terrible.\nAt least now you're not hungry.\n");
                                    ViralImmunity /= 2;
                                    Health += 10;
                                    if (Health > 100)
                                    {
                                        Health = 100;
                                    }
                                    if (ViralImmunity > 75)
                                    {
                                        ViralImmunity = 75;
                                    }
                                }
                                else if (restOfArray == "whisky")
                                {
                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                    if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
                                    {
                                        locations[index].Rooms[roomIndex].Items.Add("empty bottle");
                                    }
                                    Console.WriteLine("You drank the entire bottle of whisky.\nAfter you passed out, you started coughing up blood.\nThe alcohol killed all the bacteria in your digestive tract.\n");
                                    ViralImmunity += 10;
                                    Health /= 2;
                                    if (Health > 100)
                                    {
                                        Health = 100;
                                    }
                                    if (ViralImmunity > 75)
                                    {
                                        ViralImmunity = 75;
                                    }
                                }
                                else if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
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
                                    else if (((locations[index].Name == "Sewer Entrance North") || (locations[index].Name == "Sewer Entrance West") || (locations[index].Name == "Sewer Entrance South")) && (TorchIsEnabled == false) && (restOfArray == "surgical torch"))
                                    {
                                        TorchIsEnabled = true;
                                        Console.WriteLine("Torch is on.\n");
                                    }
                                    else if (((locations[index].Rooms[roomIndex].Name == "Sewer Entrance North") || (locations[index].Rooms[roomIndex].Name == "Sewer Entrance West") || (locations[index].Rooms[roomIndex].Name == "Sewer Entrance South")) && (TorchIsEnabled == true) && (restOfArray == "surgical torch"))
                                    {
                                        Console.WriteLine("Torch is already on.\n");
                                    }
                                    else if ((locations[index].Name == "Infected Zone") && (ZombiePresent) && (restOfArray == "pistol") && (Bullets > 0))
                                    {
                                        Bullets--;
                                        if (rand.Next(0, 3) == 0)
                                        {
                                            Console.WriteLine($"You panicked and fired a shot, missing the zombie.\n{Bullets} bullets left.\n");
                                        }
                                        else
                                        {
                                            ZombiePresent = false;
                                            Console.WriteLine($"You shot the zombie in the head, instantly killing it.\n{Bullets} bullets left.\n");
                                            locations[index].Rooms[roomIndex].Items.Add("zombie flesh sample");
                                        }
                                    }
                                    else if ((locations[index].Name == "Infected Zone") && (ZombiePresent == false) && (restOfArray == "pistol") && (Bullets > 0))
                                    {
                                        Bullets--;
                                        Console.WriteLine($"You scared yourself, firing a round and wasting it.\n{Bullets} bullets left.\n");
                                    }
                                    else if ((locations[index].Name == "Infected Zone") && (ZombiePresent) && (restOfArray == "pistol") && (Bullets <= 0))
                                    {
                                        Console.WriteLine("You are out of bullets.\n");
                                        if (Array.IndexOf(Inventory, "magazine") >= 0)
                                        {
                                            Console.WriteLine("Try [Use] \"Magazine\".\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You don't have any more bullets.\nMay God have mercy on your soul.\n");
                                        }
                                    }
                                    else if ((locations[index].Name == "Infected Zone") && (restOfArray == "magazine"))
                                    {
                                        if (Array.IndexOf(Inventory, restOfArray) >= 0)
                                        {
                                            Bullets += 5;
                                            Console.WriteLine($"You reloaded your gun.\n{Bullets} bullets left.\n");
                                            Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                            locations[index].Rooms[roomIndex].Items.Add("empty magazine");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You don't have a replacement magazine.\n");
                                        }

                                    }
                                    else if((restOfArray != "note") && (restOfArray != "cure") && (restOfArray.Contains("beakerS") == false))
                                    {
                                        Console.WriteLine("Can't use that.\n");
                                    }
                                }
                                else if ((restOfArray != "note") && (restOfArray != "cure") && (restOfArray.Contains("beakerS") == false))
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
                                    Console.WriteLine("The Gun Locker is locked.\n");
                                }
                                else if ((locations[index].Rooms[roomIndex].Name == "Ward 2") && ((restOfArray == "commissioner's body") || (restOfArray == "commissioners body") || (restOfArray == "commissioner")))
                                {
                                    Search("commissioner's body", 3, 8, locations, input, playerCoor, world);
                                }
                                else if ((locations[index].Rooms[roomIndex].Name == "Frank in a puddle") && ((restOfArray == "police officer") || (restOfArray == "police officer's body") || (restOfArray == "police officers body") || (restOfArray == "frank's body") || (restOfArray == "franks body") || (restOfArray == "frank")))
                                {
                                    Search("police officer's body", 1, 16, locations, input, playerCoor, world);
                                }
                                else if ((locations[index].Rooms[roomIndex].Name == "Storage Room") && (restOfArray == "locker"))
                                {
                                    Search("locker", 5, 5, locations, input, playerCoor, world);
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
                            if (WrongCommand < 1)
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
            } while ((input != "quit") && (input != "death"));

            return (input);
        }

        static void Search(string searchPlace, int locNum, int roomNum, List<Location> locations, string input, int[] playerCoor, string[,,] world)
        {
            do
            {
                if ((searchPlace == "commissioner's body") || (searchPlace == "police officer's body"))
                {
                    Console.WriteLine($"On the {searchPlace} you found:");
                }
                else
                {
                    Console.WriteLine($"In the {searchPlace} you found:");
                }

                if ((locations[locNum].Rooms[roomNum].Items.Count > 0) && (locations[locNum].Rooms[roomNum].Items[0] != null))
                {
                    for (int i = 0; i < locations[locNum].Rooms[roomNum].Items.Count; i++)
                    {
                        Console.Write($"* {locations[locNum].Rooms[roomNum].Items[i][0].ToString().ToUpper() + locations[locNum].Rooms[roomNum].Items[i].Substring(1)}\n");
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
                        case "inventory":
                            Inventory_Show();
                            break;
                        case "i":
                            Inventory_Show();
                            break;
                        case "back":
                            break;
                        default:
                            Console.WriteLine("When searching type [Get] \"item name\" or [Store] \"item name\" or [I]nventory or [Back].\n");
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

                    restOfArray = restOfArray.Trim().ToLower();

                    switch (command)
                    {
                        case "get":
                            if (restOfArray.Contains("chemicaln"))
                            {
                                restOfArray = "chemicalN" + restOfArray.Substring(9);
                            }
                            if ((world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X") && (locations[locNum].Rooms[roomNum].Items.Contains(restOfArray)))
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
                                    locations[locNum].Rooms[roomNum].Items.Remove(restOfArray);
                                }
                                else
                                {
                                    locations[locNum].Rooms[roomNum].Items.Remove(restOfArray);
                                    locations[locNum].Rooms[roomNum].Items.Add(restOfItemArray);
                                }
                            }
                            break;
                        case "store":
                            if (Array.IndexOf(Inventory, restOfArray) >= 0)
                            {
                                Console.WriteLine($"{restOfArray[0].ToString().ToUpper() + restOfArray.Substring(1)} stored.\n");
                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = null;
                                    locations[locNum].Rooms[roomNum].Items.Add(restOfArray);
                            }
                            else
                            {
                                Console.WriteLine("You don't have that item.\n");
                            }
                            break;
                        default:
                            Console.WriteLine("When searching type [Get] \"item name\" or [Store] \"item name\" or [I]nventory or [Back].\n");
                            break;
                    }
                }
            } while (input != "back");
        }

        public static void Workbench(List<Location> locations, int locNum, int roomNum, string input, int[] playerCoor, string[,,] world, WorkbenchClass workbench)
        {
            do
            {
                if (workbench.ToolOnWorkBench == "beaker")
                {
                    Console.WriteLine("Drop items into the beaker.\nWhen you're finished, type [Get] \"beaker\".\n");

                    if (workbench.ItemsInBeaker.Count > 0)
                    {
                        Console.WriteLine("Items in the beaker:");

                        for (int i = 0; i < workbench.ItemsInBeaker.Count; i++)
                        {
                            if (workbench.ItemsInBeaker[i].Contains("N"))
                            {
                                Console.WriteLine($"* ChemicalN{workbench.ItemsInBeaker[i].Substring(9)}");
                            }
                            else
                            {
                                Console.WriteLine($"* {workbench.ItemsInBeaker[i][0].ToString().ToUpper() + workbench.ItemsInBeaker[i].Substring(1)}");
                            }
                        }

                        if (workbench.ItemsInBeaker.Count == 0)
                        {
                            Console.WriteLine($"\nBeaker State: Nothing.");
                        }
                        else if (workbench.ItemsInBeaker.Count == 1)
                        {
                            Console.WriteLine($"\nBeaker State: Single.");
                        }
                        else if (workbench.ItemsInBeaker.Count > 1)
                        {
                            Console.WriteLine($"\nBeaker State: Mixture.");
                        }
                        Console.WriteLine($"Beaker Vitality Ratio: {workbench.BeakerVitality}");
                        Console.WriteLine($"Mixture Viable: {workbench.Viable}");
                    }
                    else
                    {
                        Console.WriteLine("The beaker is empty.");
                    }
                }
                else if (workbench.ToolOnWorkBench == "bunsen burner")
                {
                    Console.WriteLine("Drop mixture on bunsen burner to create solution.");
                }
                else if (workbench.ToolOnWorkBench == "zombie flesh sample")
                {
                    Console.WriteLine("Please drop solution on to zombie flesh sample to test for a positive cure.");
                }
                else
                {
                    Console.WriteLine("There is nothing on the workbench.");
                }
                
                Console.WriteLine("\nWhat do you want to do next?");
                input = Console.ReadLine().ToLower();
                Console.Clear();
                if (input.Contains(" ") == false)
                {
                    string restOfArray = input;

                    if (restOfArray.Contains("chemicaln"))
                    {
                        restOfArray = restOfArray.Replace("n", "N");
                    }
                    if (restOfArray.Contains("beakermn"))
                    {
                        restOfArray = restOfArray.Replace("mn", "MN");
                    }
                    if (restOfArray.Contains("beakersn"))
                    {
                        restOfArray = restOfArray.Replace("sn", "SN");
                    }
                    if (restOfArray.Contains("beakers"))
                    {
                        restOfArray = restOfArray.Replace("s", "S");
                    }
                    if (restOfArray.Contains("beakerm"))
                    {
                        restOfArray = restOfArray.Replace("m", "M");
                    }
                    if (restOfArray.Contains("beakern"))
                    {
                        restOfArray = restOfArray.Replace("n", "N");
                    }

                    restOfArray = restOfArray.Trim();

                    switch (input)
                    {
                        case "back":
                            break;
                        case "inventory":
                            Inventory_Show();
                            break;
                        case "i":
                            Inventory_Show();
                            break;
                        case "help":
                            using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\Resources\helpWB.txt"))
                            {
                                while (!sr.EndOfStream)
                                {
                                    Console.WriteLine(sr.ReadLine());
                                }
                            }
                            Console.WriteLine();
                            break;
                        default:
                            if (workbench.ToolOnWorkBench != "")
                            {
                                if (Array.IndexOf(Inventory, restOfArray) >= 0)
                                {
                                    if ((workbench.ToolOnWorkBench == "beaker") && (restOfArray != "beaker"))
                                    {
                                        if (restOfArray.Contains("chemical") || restOfArray.Contains("zombie flesh sample"))
                                        {
                                            workbench.ItemsInBeaker.Add(restOfArray);
                                            if (restOfArray != "zombie flesh sample")
                                            {
                                                if (restOfArray.Contains("N"))
                                                {
                                                    locations[5].Rooms[5].Items.Add(restOfArray);
                                                }
                                                else
                                                {
                                                    locations[5].Rooms[2].Items.Add(restOfArray);
                                                }
                                            }
                                            workbench.BeakerVitality += WorkbenchClass.Drop(restOfArray, Inventory, workbench.ToolOnWorkBench);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid item.\nPlease drop in a chemical or zombie flesh sample.\n");
                                        }
                                    }
                                    else if ((workbench.ToolOnWorkBench == "bunsen burner") && (restOfArray.Contains("beaker")))
                                    {
                                        if (workbench.Viable && (restOfArray.Contains("beakerS") == false))
                                        {
                                            if (workbench.ItemsInBeaker.Count > 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"Are you sure you want to finalise the mixture {restOfArray[0].ToString().ToUpper() + restOfArray.Substring(1)}? - [Y]es or [N]o\nThis can not be undone.");
                                                string choice = Console.ReadLine();
                                                Console.Clear();
                                                if ((choice == "yes") || (choice == "y"))
                                                {
                                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = restOfArray.Replace("M", "S");
                                                    WorkbenchClass.MakeSolution(workbench.BeakerVitality, workbench.Viable, Inventory);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("You need more than one item in the mixture!\n");
                                            }
                                        }
                                        else if (restOfArray.Contains("beakerS") == false)
                                        {
                                            if (workbench.ItemsInBeaker.Count > 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"Are you sure you want to finalise the mixture {restOfArray[0].ToString().ToUpper() + restOfArray.Substring(1)}? - [Y]es or [N]o\nIt does NOT contain a zombie flesh sample.\nThis will make it an unviable solution.");
                                                string choice = Console.ReadLine();
                                                Console.Clear();
                                                if ((choice == "yes") || (choice == "y"))
                                                {
                                                    Inventory[Array.IndexOf(Inventory, restOfArray)] = restOfArray.Replace("M", "S");
                                                    WorkbenchClass.MakeSolution(workbench.BeakerVitality, workbench.Viable, Inventory);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("You need more than one item in the mixture!\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("That is already a solution.\nTry adding it to a zombie flesh sample on the work bench.\n");
                                        }
                                    }
                                    else if (workbench.ToolOnWorkBench == "zombie flesh sample")
                                    {
                                        if (restOfArray.Contains("beakerS"))
                                        {
                                            if (workbench.Viable)
                                            {
                                                if (workbench.BeakerVitality == 286)
                                                {
                                                    Console.WriteLine("Test SUCCEEDED - You found the CURE!\n");
                                                    workbench.ToolOnWorkBench = "";
                                                    Inventory[Array.IndexOf(Inventory, "beakerS" + workbench.BeakerVitality.ToString())] = "cure";
                                                    workbench.BeakerVitality = 0;

                                                    int count = workbench.ItemsInBeaker.Count;

                                                    for (int i = 0; i < count; i++)
                                                    {
                                                        workbench.ItemsInBeaker.Remove(workbench.ItemsInBeaker[0]);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Test FAILED - Solution wrong vitality ratio.\nSolution destroyed.\nSample destroyed.\n");
                                                    workbench.ToolOnWorkBench = "";
                                                    Inventory[Array.IndexOf(Inventory, "beakerS" + workbench.BeakerVitality.ToString())] = "beaker";
                                                    workbench.BeakerVitality = 0;

                                                    int count = workbench.ItemsInBeaker.Count;

                                                    for (int i = 0; i < count; i++)
                                                    {
                                                        workbench.ItemsInBeaker.Remove(workbench.ItemsInBeaker[0]);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Test FAILED - Solution is missing zombie flesh sample.\nSolution destroyed.\nSample destroyed.\n");
                                                workbench.ToolOnWorkBench = "";
                                                Inventory[Array.IndexOf(Inventory, "beakerS" + workbench.BeakerVitality.ToString())] = "beaker";
                                                workbench.BeakerVitality = 0;

                                                int count = workbench.ItemsInBeaker.Count;

                                                for (int i = 0; i < count; i++)
                                                {
                                                    workbench.ItemsInBeaker.Remove(workbench.ItemsInBeaker[0]);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can't use that.\n");
                                        }
                                    }
                                    else if (workbench.ToolOnWorkBench == "")
                                    {
                                        Console.WriteLine("Please [Place] something on the workbench.\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Can't do that.\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You don't have this item.\n");
                                }

                                if (workbench.ItemsInBeaker.Contains("zombie flesh sample"))
                                {
                                    workbench.Viable = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("For help using the workbench type the [Help] command.\n");
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

                    if (restOfArray.Contains("chemicaln"))
                    {
                        restOfArray = restOfArray.Replace("n", "N");
                    }
                    if (restOfArray.Contains("beakermn"))
                    {
                        restOfArray = restOfArray.Replace("mn", "MN");
                    }
                    if (restOfArray.Contains("beakersn"))
                    {
                        restOfArray = restOfArray.Replace("sn", "SN");
                    }
                    if (restOfArray.Contains("beakers"))
                    {
                        restOfArray = restOfArray.Replace("s", "S");
                    }
                    if (restOfArray.Contains("beakerm"))
                    {
                        restOfArray = restOfArray.Replace("m", "M");
                    }
                    if (restOfArray.Contains("beakern"))
                    {
                        restOfArray = restOfArray.Replace("n", "N");
                    }

                    restOfArray = restOfArray.Trim();

                    switch (command)
                    {
                        case "get":
                            if ((restOfArray == "beaker") && (workbench.ToolOnWorkBench == "beaker"))
                            {
                                workbench.ToolOnWorkBench = "";
                                if (workbench.ItemsInBeaker.Count > 1)
                                {
                                    if (workbench.BeakerVitality > 0)
                                    {
                                        restOfArray = "beaker" + "M" + workbench.BeakerVitality;
                                    }
                                    else
                                    {
                                        restOfArray = "beaker" + "M" + "N" + workbench.BeakerVitality.ToString().Replace("-", "");
                                    }
                                }
                                else if (workbench.BeakerVitality > 0)
                                {
                                    restOfArray = "beaker" + workbench.BeakerVitality;
                                }
                                else if (workbench.BeakerVitality < 0)
                                {
                                    restOfArray = "beaker" + "N" + workbench.BeakerVitality.ToString().Replace("-", "");
                                }
                                else
                                {
                                    restOfArray = "beaker";
                                }

                                string[] temp2 = Inventory_Check(restOfArray).Split(' ');
                                string itemInstruction = temp2[0];
                                string restOfItemArray = "";

                                for (int i = 1; i < temp2.Length; i++)
                                {
                                    restOfItemArray += temp2[i] + " ";
                                }

                                restOfItemArray = restOfItemArray.Trim();

                                if (itemInstruction != "pickup")
                                {
                                    locations[locNum].Rooms[roomNum].Items.Add(restOfItemArray.ToLower());
                                }
                            }
                            else if (restOfArray == "bunsen burner")
                            {
                                workbench.ToolOnWorkBench = "";
                                string[] temp2 = Inventory_Check(restOfArray).Split(' ');
                                string itemInstruction = temp2[0];
                                string restOfItemArray = "";

                                for (int i = 1; i < temp2.Length; i++)
                                {
                                    restOfItemArray += temp2[i] + " ";
                                }

                                restOfItemArray = restOfItemArray.Trim();

                                if (itemInstruction != "pickup")
                                {
                                    locations[locNum].Rooms[roomNum].Items.Add(restOfItemArray.ToLower());
                                }
                            }
                            else if (restOfArray == "zombie flesh sample")
                            {
                                workbench.ToolOnWorkBench = "";
                                string[] temp2 = Inventory_Check(restOfArray).Split(' ');
                                string itemInstruction = temp2[0];
                                string restOfItemArray = "";

                                for (int i = 1; i < temp2.Length; i++)
                                {
                                    restOfItemArray += temp2[i] + " ";
                                }

                                restOfItemArray = restOfItemArray.Trim();

                                if (itemInstruction != "pickup")
                                {
                                    locations[locNum].Rooms[roomNum].Items.Add(restOfItemArray.ToLower());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Can't get that.\n");
                            }
                            break;
                        case "drop":
                            
                            break;
                        case "place":
                            if (Array.IndexOf(Inventory, restOfArray) >= 0)
                            {
                                if ((restOfArray.Contains("beaker") && (restOfArray.Contains("beakerS") == false)) || (restOfArray == "zombie flesh sample") || (restOfArray == "bunsen burner"))
                                {
                                    string returnString = "";

                                    if (restOfArray.Contains("beaker") && (restOfArray != "beaker"))
                                    {
                                        returnString = WorkbenchClass.Place(Inventory, "beaker", workbench.ToolOnWorkBench);
                                    }
                                    else if (restOfArray == "beaker")
                                    {
                                        returnString = WorkbenchClass.Place(Inventory, restOfArray, workbench.ToolOnWorkBench);
                                    }
                                    else
                                    {
                                        returnString = WorkbenchClass.Place(Inventory, restOfArray, workbench.ToolOnWorkBench);
                                    }

                                    if (returnString != "Tool already on workbench.")
                                    {
                                        workbench.ToolOnWorkBench = returnString;

                                        if (restOfArray.Contains("beaker") && (restOfArray != "beaker"))
                                        {
                                            returnString = restOfArray;
                                        }

                                        Inventory[Array.IndexOf(Inventory, returnString)] = null;
                                    }
                                }
                                else if (restOfArray.Contains("beaker") && restOfArray.Contains("beakerS"))
                                {
                                    Console.WriteLine("That mixture has already been finalised as a solution and can not be edited.\n");
                                }
                                else if (restOfArray == "zombie flesh sample")
                                {
                                    workbench.ToolOnWorkBench = "zombie flesh sample";
                                }
                                else
                                {
                                    Console.WriteLine("You can't place that object.\n");
                                }
                            }
                            else
                            {
                                bool solution = false;

                                for (int i = 0; i < Inventory.Length; i++)
                                {
                                    if ((Inventory[i] != null) && Inventory[i].Contains("beakerS"))
                                    {
                                        solution = true;
                                    }
                                }

                                if ((restOfArray == "zombie flesh sample") && solution)
                                {
                                    Console.WriteLine("You don't have a zombie flesh sample.\nFind a zombie flesh sample to test with,\nor test it on yourself using [Use] \"item name\".\n");
                                }
                                else
                                {
                                    Console.WriteLine("You don't have this item.\n");
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("For help using the workbench type the [Help] command.\n");
                            break;
                    }
                }
            } while (input != "back");
        }

        static void Movement(string[,,] world, int[] playerCoor, int[] playerCoorLocation, int condition1, int condition2, int num, int index, List<Location> locations, int locIndex, ref string input, ref bool firstTime)
        {
            bool moved = false;

            if (world[playerCoor[0], playerCoor[1], playerCoor[2]] != "X")
            {
                if (condition1 > condition2)
                {
                    if ((locations[locIndex].Name != "Sewer Entrance North") && (locations[locIndex].Name != "Sewer Entrance South") && (locations[locIndex].Name != "Sewer Entrance West") && (locations[locIndex].Name != "North Forest") && (locations[locIndex].Name != "West Forest") && (locations[locIndex].Name != "South Forest"))
                    {
                        playerCoorLocation[index] += num;
                        moved = true;

                        if ((locations[locIndex].Name == "Infected Zone") && (ZombiePresent == false))
                        {
                            Random rand = new Random();
                            if (rand.Next(0, 3) == 0)
                            {
                                ZombiePresent = true;
                            }
                        }
                        else if (ZombiePresent)
                        {
                            Death(6, ref input);
                        }
                    }
                    else if ((locations[locIndex].Name == "Sewer Entrance North") || (locations[locIndex].Name == "Sewer Entrance South") || (locations[locIndex].Name == "Sewer Entrance West"))
                    {
                        if ((TorchIsEnabled == false) && (index != 2))
                        {
                            string choice = "";

                            do
                            {
                                Console.Clear();
                                if ((Array.IndexOf(Inventory, "surgical torch") >= 0) && (TorchIsEnabled == false))
                                {
                                    Console.WriteLine("You have a torch but it is off.\ntry the [Use] command.\n");
                                }
                                else if (TorchIsEnabled == false)
                                {
                                    Console.WriteLine("You do not have a torch.\n");
                                }
                                Console.WriteLine("It's really dark in the sewer and you may injure yourself.\nAre you sure you want to explore? - [Y]es or [N]o");
                                choice = Console.ReadLine();
                                Console.Clear();
                            } while ((choice != "yes") && (choice != "y") && (choice != "no") && (choice != "n"));

                            if ((choice == "y") || (choice == "yes"))
                            {
                                Console.Clear();
                                Death(5, ref input);
                            }
                        }
                        else if ((TorchIsEnabled) || (index == 2))
                        {
                            switch (index)
                            {
                                case 0:
                                    if (locations[locIndex].LocationMap[playerCoorLocation[0] + num, playerCoorLocation[1], playerCoorLocation[2]] != "wall")
                                    {
                                        playerCoorLocation[index] += num;
                                        moved = true;
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
                                        moved = true;
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
                                                if (Array.IndexOf(Inventory, "building key") >= 0)
                                                {
                                                    PoliceStationUnlocked = true;
                                                    Console.WriteLine("Police Station Unlocked.\n");
                                                    playerCoor[0] = 4;
                                                    playerCoor[1] = 1;
                                                    playerCoor[2] = 0;
                                                    playerCoorLocation[0] = 0;
                                                    playerCoorLocation[1] = 0;
                                                    playerCoorLocation[2] = 0;
                                                    firstTime = true;
                                                }
                                                else
                                                {
                                                    Death(2, ref input);
                                                }
                                                break;
                                            case "Sewer Exit Infected Zone":
                                                if ((Array.IndexOf(Inventory, "pistol") >= 0) && (Bullets > 0))
                                                {
                                                    playerCoor[0] = 0;
                                                    playerCoor[1] = 4;
                                                    playerCoor[2] = 0;
                                                    playerCoorLocation[0] = 0;
                                                    playerCoorLocation[1] = 0;
                                                    playerCoorLocation[2] = 0;
                                                    firstTime = true;
                                                }
                                                else
                                                {
                                                    Death(3, ref input);
                                                }
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
                    }
                    else if ((locations[locIndex].Name == "North Forest") || (locations[locIndex].Name == "West Forest") || (locations[locIndex].Name == "South Forest"))
                    {
                        switch (index)
                        {
                            case 0:
                                if (locations[locIndex].LocationMap[playerCoorLocation[0] + num, playerCoorLocation[1], playerCoorLocation[2]] != "wall")
                                {
                                    playerCoorLocation[index] += num;
                                    moved = true;
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
                                    moved = true;
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
                        string choice = "";

                        do
                        {
                            Console.WriteLine($"Are you sure you want to leave the {locations[locIndex].Name}? - [Y]es or [N]o");
                            if (((playerCoor[index] + num) > mapDim[index]) || ((playerCoor[index] + num) < 0))
                            {
                                Console.WriteLine("CAUTION! - You are about to leave the town");
                            }
                            if (playerCoorLocation[2] != 0)
                            {
                                Console.WriteLine("You are not on the ground floor.");
                            }

                            choice = Console.ReadLine().ToLower();
                            Console.Clear();

                            if ((choice == "yes") || (choice == "y"))
                            {
                                if (playerCoorLocation[2] > 0)
                                {
                                    Death(0, ref input);
                                }
                                playerCoor[index] += num;
                                moved = true;
                                playerCoorLocation[2] = 0;
                                for (int i = 0; i < playerCoorLocation.Length; i++)
                                {
                                    playerCoorLocation[i] = 0;
                                }
                                firstTime = true;
                            }
                        } while ((choice != "yes") && (choice != "y") && (choice != "no") && (choice != "n"));
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
                                moved = true;
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
                                    Console.WriteLine("The Police Station is locked and you don't have the key.\nYou then notice a note left on the door.\n\n\"I've locked up and gone to the lab to investigate a disturbance\"\n\n  -Frank\n");
                                }
                            }
                            else if (((playerCoor[0] + num) == locations[4].Dimensions[0]) && (playerCoor[1] == locations[4].Dimensions[1]) && (playerCoor[2] == locations[4].Dimensions[2]))
                            {
                                playerCoor[index] += num;
                                Death(4, ref input);
                            }
                            else
                            {
                                playerCoor[index] += num;
                                moved = true;
                            }
                            break;
                        case 1:
                            if (((playerCoor[1] + num) == locations[6].Dimensions[1]) && (playerCoor[0] == locations[6].Dimensions[0]) && (playerCoor[2] == locations[6].Dimensions[2]) && PoliceStationUnlocked)
                            {
                                playerCoor[index] += num;
                                moved = true;
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
                            else if (((playerCoor[1] + num) == locations[4].Dimensions[1]) && (playerCoor[0] == locations[4].Dimensions[0]) && (playerCoor[2] == locations[4].Dimensions[2]))
                            {
                                playerCoor[index] += num;
                                Death(4, ref input);
                            }
                            else
                            {
                                playerCoor[index] += num;
                                moved = true;
                            }
                            break;
                        case 2:
                            if (((playerCoor[2] + num) == locations[6].Dimensions[2]) && (playerCoor[1] == locations[6].Dimensions[1]) && (playerCoor[0] == locations[6].Dimensions[0]) && PoliceStationUnlocked)
                            {
                                playerCoor[index] += num;
                                moved = true;
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
                            else if (((playerCoor[2] + num) == locations[4].Dimensions[2]) && (playerCoor[1] == locations[4].Dimensions[1]) && (playerCoor[0] == locations[4].Dimensions[0]))
                            {
                                playerCoor[index] += num;
                                Death(4, ref input);
                            }
                            else
                            {
                                playerCoor[index] += num;
                                moved = true;
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

            if ((Array.IndexOf(Inventory, "zombie flesh sample") >= 0) && moved)
            {
                if (ViralImmunity > 0)
                {
                    ViralImmunity -= 5;
                }
                else
                {
                    Health -= 5;
                }
                if (Health <= 0)
                {
                    Death(7, ref input);
                }
            }
        }

        static void Death(int number, ref string input)
        {
            if (Health <= 0)
            {
                Health = 100;
            }
            if (ViralImmunity <= 0)
            {
                ViralImmunity = 75;
            }
            if (Array.IndexOf(Inventory, "cure") < 0)
            {
                DeathCount++;
            }
            string[] deaths = { "You step in the direction you thought to be the door, soon realising that it was infact the window.\nYou try to stop yourself, but you've stepped with so much conviction that you can't.\nYou fly through the window, sending glass fragments everywhere.\nWith shards of glass embedded in your face and arms, you fall helplessly to the ground.\nAnd there your lifeless body stays, with humanity doomed due to a simple navigational error.",
                "As you attempt to flee from the town, you hear a thumping through the ground.\nAs you turn in horror towards the vibrations, you see a horde of green shambling corpses running towards you at a speed you couldn't believe was possible.\nYou try desperately to run.\nYour last thoughts on how you failed this town and have doomed this world to a zombie apocalypse.",
                "You enter the police station through the maintenance hatch.\nAs it closes behind you, you realise that it can only be opened from the sewer.\nYou soon discover that the police station is locked, with you, trapped inside.\nAfter many weeks of agonising pain you finaly starve to death on the cold tile floors.\nForgotten by the world of undead, hopelessly wandering for the rest of enternity.",
                "You entered the Steel port apartment complex unarmed and stumbled into a zombie.\nIt ran at you and ripped apart your flesh with it's decaying nails as you lay helplessly on the ground screaming in agony.",
                "You foolishly entered the apartment complex infront of the horde of zombies lurking in the lobby.\nYou try to escape, inadvertently shutting the door.\nThe horde of decaying flesh forces you into the closed door,\nallowing you to get one last glimpse of the world before they break open your body with you blacking out on the lobby floor.",
                "You tried to wander about the sewers in the pitch black darkness.\nYou managed to get a fair way through the sewer system,\nhowever at this point you could't see your hand in front of your face.\nThe floor stepped down, throwing you off balance.\nYour arms flying frantically through the air.\nYou fall forward, heart racing.\nThe next thing you felt was your head colliding with the cold concrete sewer wall.\nThere your body lay, face down in the murky water, with your blood streaming down your lifeless head.",
                "You feel pressure on your neck as it's hands grasp around your throat.\nYou lose feeling in your body as it rips apart your neck,\nseperating your head from your now lifeless body.",
                "You feel your sanity slowly slip as the world goes out of focus.\nYou collapse to the ground feeling the toxins raging through your veins.\nAs the infection rages stronger you start to lose muscle control.\nYour thoughts becoming empty and mindless, as you slip into an eternity of limbo.\nYourself, lost, to the hands of the undead.\nNever to be saved from the plague that consumes you.\nCursed to wander the Earth forever.",
                "After using the solution on yourself you start to feel the bacteria inside you receeding.\nYou breath a sigh of relief, only to collapse to the floor in crippling pain.\nCoughing up blood on your side, as the infection and the solution rip apart your insides,\ndestroying everything inside you.\nA pink slime oozes out of your mouth as you splutter your last breath,\nsacraficing your life, only to doom humanity anyway.",
                $"You take the cure to immunise yourself.\nYou then proceed to the Steelport apartment complex with the cure in hand.\nYou go back down into the sewer system, and up into the building through the maintenance hatch.\nOnce at the ground floor you proceed to the ventalation room, managing not to be spotted by any of the residents.\nYou use a bunsen burner from your inventory to vaporise the cure,\nsending it throughout the building.\nAfter cautiously waiting a few minutes, you emerge from hiding just in time to see the zombies reverting into people.\nCongratulations! You successfully saved humanity and you only died {DeathCount} times.\nHave fun cleaning up the mess. ;)\n\nGame created by:\n* Clayton Davidson - Lead Programmer\n* Blake Chalmers - Lead Story Writer\n* Liam O Brien - Programmer" };

            Console.WriteLine(deaths[number] + "\n\nPress enter to continue.");
            input = "death";
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
                    east = $"The {locations[index].Name} is to the East.";
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
                    west = $"The {locations[index].Name} is to the West.";
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
                    south = $"The {locations[index].Name} is to the South.";
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
                    north = $"The {locations[index].Name} is to the North.";
                }
            }
            catch
            {
                north = "X";
            }

            if ((north == "X") || (west == "X") || (east == "X") || (south == "X"))
            {
                Console.WriteLine();
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

            if (((north != "X") && (north != "")) || ((west != "X") && (west != "")) || ((east != "X") && (east != "")) || ((south != "X") && (south != "")))
            {
                Console.WriteLine();
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
            int roomIndex = 0;
            for (int i = 0; i < locations[index].RoomCount; i++)
            {
                if ((locations[index].Rooms[i].Coor[0] == playerCoorLocation[0]) && (locations[index].Rooms[i].Coor[1] == playerCoorLocation[1]) && (locations[index].Rooms[i].Coor[2] == playerCoorLocation[2]))
                {
                    roomIndex = i;
                }
            }

            if ((locations[index].Name != "Sewer Entrance North") && (locations[index].Name != "Sewer Entrance West") && (locations[index].Name != "Sewer Entrance South") && (locations[index].Name != "South Forest") && (locations[index].Name != "North Forest") && (locations[index].Name != "West Forest") && (locations[index].Name != "Infected Zone"))
            {
                Console.Write($"You are in the {locations[index].Name}, ");
                if (playerCoorLocation[2] == 0)
                {
                    Console.WriteLine("on the Ground floor.");
                }
                else
                {
                    Console.WriteLine($"on floor No. {playerCoorLocation[2]}.");
                }
                Console.WriteLine($"You are in the {locations[index].LocationMap[playerCoorLocation[0], playerCoorLocation[1], playerCoorLocation[2]]}.");
            }
            else if (locations[index].Name == "Infected Zone")
            {
                Console.Write("You are in the Steelport apartment complex, ");
                if (playerCoorLocation[2] == 0)
                {
                    Console.WriteLine("on the Ground floor.");
                    Console.WriteLine($"You are in the {locations[index].LocationMap[playerCoorLocation[0], playerCoorLocation[1], playerCoorLocation[2]]}.");
                    Console.WriteLine("\n" + locations[index].Rooms[roomIndex].Description);
                }
                else
                {
                    Console.WriteLine($"on floor No. {playerCoorLocation[2]}.");
                    if ((playerCoorLocation[2] >= 0) && (playerCoorLocation[0] == 1))
                    {
                        Console.WriteLine($"You are in the hallway.");
                        Console.WriteLine($"The room {playerCoorLocation[2]}{(char)(65 + playerCoorLocation[1])} on the left.\nThe room {playerCoorLocation[2]}{(char)(68 + playerCoorLocation[1])} on the right.");
                    }
                    else if (playerCoorLocation[0] != 1)
                    {
                        if (playerCoorLocation[0] == 0)
                        {
                            Console.WriteLine($"You are in room {playerCoorLocation[2]}{(char)(65 + playerCoorLocation[1])}");
                        }
                        else
                        {
                            Console.WriteLine($"You are in room {playerCoorLocation[2]}{(char)(68 + playerCoorLocation[1])}");
                        }

                        Random rand = new Random();
                        string[] descriptions = { "The room has been abandoned, everything still in its place; like a snapshot of time.", "Ransacked and looted. This room makes you feel uneasy.", "An unforgivable stench invades your nose. This room filled with death.", "Another room empty and barren. The furniture left behind.", "Glass and china covers the floor, you navigate the surroundings cautiously.", "This room is filled with corpses of the dead. A horrific sight that will haunt you.", "This room is accompanied by a feeling that you are being watched.", "The room you have found is eerily quiet. Too quiet.", "The stale musty air is followed by the sight of skeletons scattered over the floor." };
                        Console.WriteLine("\n" + descriptions[rand.Next(0, descriptions.Length)]);
                    }
                }
                if (ZombiePresent == false)
                {
                    Console.WriteLine("Be careful, there could be a zombie just around the corner.");
                }
                else
                {
                    Console.WriteLine("WARNING! - A zombie has noticed you and is about to attack.");
                }
            }
            else if ((locations[index].Name == "Sewer Entrance North") || (locations[index].Name == "Sewer Entrance West") || (locations[index].Name == "Sewer Entrance South"))
            {
                Console.WriteLine("You are in the Sewer.");
            }
            else if ((locations[index].Name == "South Forest") || (locations[index].Name == "North Forest") || (locations[index].Name == "West Forest"))
            {
                Console.WriteLine("You are in a Forest.");
            }
            if (locations[index].Name != "Infected Zone")
            {
                Console.WriteLine("\n" + locations[index].Rooms[roomIndex].Description);
            }
            if ((locations[index].Rooms[roomIndex].Items.Count > 0) && (locations[index].Rooms[roomIndex].Items[0] != null))
            {
                Console.Write("\nThere is: \n");
                for (int i = 0; i < locations[index].Rooms[roomIndex].Items.Count; i++)
                {
                    Console.Write($"* {locations[index].Rooms[roomIndex].Items[i][0].ToString().ToUpper() + locations[index].Rooms[roomIndex].Items[i].ToString().Substring(1)}\n");
                }
            }
        }

        static void LoadData(List<Location> locations)
        {
            string locationDir = Directory.GetCurrentDirectory() + @"\Resources\Location\";
            string locationRoomDir = Directory.GetCurrentDirectory() + @"\Resources\LocationRooms\";
            string[] locationFilePaths = Directory.GetFiles(locationDir);
            string[] roomFilePaths = new string[locationFilePaths.Length];
            for (int i = 0; i < roomFilePaths.Length; i++)
            {
                roomFilePaths[i] = Directory.GetCurrentDirectory() + @"\Resources\LocationRooms\" + locationFilePaths[i].Split('\\')[locationFilePaths[i].Split('\\').Length - 1].Replace(".txt", "rooms.txt");
            }
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
            Console.WriteLine();
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
