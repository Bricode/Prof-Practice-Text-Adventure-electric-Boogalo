using System;
using System.Collections.Generic;

namespace InfectionInjection
{
    public class Location
    {
        public string Name { get; set; }
        public int[] Dimensions { get; set; } = new int[6];
        public List<int[]> HallwayCoor { get; set; } = new List<int[]>();
        public int RoomCount { get; set; }
        public int HallwayCount { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public string[,,] LocationMap { get; set; }
    }
}
