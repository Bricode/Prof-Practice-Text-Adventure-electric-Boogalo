﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfectionInjection
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] Coor { get; set; } = new int[3];
        public List<string> Items { get; set; } = new List<string>();
    }
}
