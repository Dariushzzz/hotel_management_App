using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7_2
{
    public interface ICustomer
    {
        string Name { get; set; }
        string Address { get; set; }
        int RoomNumber { get; set; }
        string ArrivalDate { get; set; }
        int LengthOfStay { get; set; }
    }
}
