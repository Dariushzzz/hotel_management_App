using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7_2
{
    public interface IHotel
    {
        string Name { get; set; }
        string ConstructionDate { get; set; }
        string Address { get; set; }
        int Stars { get; set; }
        List<Room> Rooms { get; set; }
        List<Customer> Customers { get; set; }
    }
}
