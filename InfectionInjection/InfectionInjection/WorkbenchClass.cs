using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace InfectionInjection
{
    public class WorkbenchClass
    {
        public string ToolOnWorkBench = "";
        public List<string> ItemsInBeaker = new List<string>();
        public int BeakerVitality;
        public bool Viable = false;

        public static string Place(string[] Inventory, string restOfArray, string currentTool)
        {
            if (currentTool == "")
            {
                currentTool = restOfArray;
                return (currentTool);
            }
            else
            {
                Console.WriteLine("Tool is already on workbench.\n");
                return ("Tool already on workbench.");
            }
        }

        public static int Drop(string droppedItem, string[] Inventory, string tool)
        {
            Inventory[Array.IndexOf(Inventory, droppedItem)] = null;
            if (tool == "beaker")
            {
                if (droppedItem[8] == 'M')
                {
                    droppedItem = droppedItem.Replace("m", "");
                }
                if (droppedItem.Contains("chemical"))
                {
                    Console.WriteLine(droppedItem[0].ToString().ToUpper() + droppedItem.Substring(1) + " added.\n");
                    if (droppedItem.Contains("N"))
                    {
                        return Convert.ToInt32("-" + droppedItem.Split('N')[1]);
                    }
                    else
                    {
                        droppedItem = droppedItem.Replace("chemical", "");
                        return Convert.ToInt32(droppedItem);
                    }
                }
                else if (droppedItem.Contains("zombie flesh sample"))
                {
                    Console.WriteLine("Zombie Flesh Sample added.\n");
                    return 26;
                }
                else
                {
                    Console.WriteLine("You can't put that in the beaker.\n");
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public static void MakeSolution(int vitality, bool viable, string[] Inventory)
        {
            Console.Clear();
            Console.WriteLine("Heating Mixture - Creating Solution");
            Console.WriteLine("" +
                " _________________________________________________________________ \n" +
                "|                                                                 |\n" +
                "|_________________________________________________________________|\n");

            string[] phrase = { $"Creating solution from BeakerM{vitality}.", $"Solution made from BeakerM{vitality} is a viable solution: {viable}.", $"Will BeakerM{vitality} be the cure?", "You think this is taking too long!", "How many of your friends are dying right now?", "Will you be able to save humanity?", "Solution 50% complete.", "The pressure is on, the stakes are high.", "Humanity is counting on you.", "Will this be the cure that saves everyone?", "You're starting to get annoyed with how long this is taking.", "You're tapping your foot with irritation.", $"Solution BeakerS{vitality} almost completed." };

            Console.SetCursorPosition(0, 5);
            Console.WriteLine(phrase[0]);

            for (int i = 0; i < 13; i++)
            {
                for (int n = 0; n < 5; n++)
                {
                    Console.SetCursorPosition(1, 3);
                    for (int c = 0; c < 65; c++)
                    {
                        Console.Write("#");
                        Thread.Sleep(10);
                    }
                    Console.SetCursorPosition(1, 3);
                    for (int c = 0; c < 65; c++)
                    {
                        Console.Write(" ");
                    }
                    for (int c = 0; c < 65; c++)
                    {
                        Console.Write("\b");
                    }
                    Console.SetCursorPosition(i*5 + n + 1, 2);
                    Console.Write("#");
                }

                Console.SetCursorPosition(0, 5);
                for (int c = 0; c < 65; c++)
                {
                    Console.Write(" ");
                }
                for (int c = 0; c < 65; c++)
                {
                    Console.Write("\b");
                }
                try
                {
                    Console.WriteLine(phrase[i + 1]);
                }
                catch
                {
                    if (Array.IndexOf(Inventory, "zombie flesh sample") >= 0)
                    {
                        Console.WriteLine($"Solution BeakerS{vitality} successfully completed.\nPlace your zombie flesh sample on the workbench to test the solution.\nPress enter to continue.");
                    }
                    else
                    {
                        Console.WriteLine($"Solution BeakerS{vitality} successfully completed.\nYou don't have a zombie flesh sample.\nFind a zombie flesh sample to test with,\nor test it on yourself using [Use] \"item name\".\nPress enter to continue.");
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
