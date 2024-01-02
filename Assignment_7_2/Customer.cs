using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7_2
{
    [Serializable]
  public class Customer : ICustomer
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public int RoomNumber { get; set; }
        public string ArrivalDate { get; set; }
        public int LengthOfStay { get; set; }
    }
}
