using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfectionInjection
{
    public class Room
    {
        public string Name { get; set; }
        public int[] Coor { get; set; } = new int[3];
        public string[] Items { get; set; }
    }
}
