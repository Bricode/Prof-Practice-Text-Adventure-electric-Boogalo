using System;
using System.Collections.Generic;

namespace InfectionInjection
{
    public class Location
    {
        public string Name { get; set; }
        public int[] Dimensions { get; set; } = new int[6];
        public int RoomCount { get; set; }
        public int[] StartPosN { get; set; } = new int[3];
        public int[] StartPosE { get; set; } = new int[3];
        public int[] StartPosW { get; set; } = new int[3];
        public int[] StartPosS { get; set; } = new int[3];
        public List<Room> Rooms { get; set; } = new List<Room>();
        public string[,,] LocationMap { get; set; }
    }
}
