using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
