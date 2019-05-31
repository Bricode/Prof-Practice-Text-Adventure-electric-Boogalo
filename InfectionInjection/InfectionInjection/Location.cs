using System;
using System.Collections.Generic;

namespace InfectionInjection
{
    public class Location
    {
        public string Name { get; set; }
        public int[] Dimensions { get; set; } = new int[6];
        public List<int[]> HalwayCoor { get; set; } = new List<int[]>();
        public int RoomCount { get; set; }
        public int EntryCount { get; set; }
        public List<int[]> EntryCoor { get; set; } = new List<int[]>();
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
