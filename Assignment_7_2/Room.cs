using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7_2
{
    [Serializable]
    public class Room : IRoom
    {
        public int RoomNumber { get; set; }
        public double Area { get; set; }
        public string Type { get; set; }
        public double PricePerNight { get; set; }
        public string Description { get; set; }

    }
}

