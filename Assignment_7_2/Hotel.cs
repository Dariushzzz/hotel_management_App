using Assignment_7_2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

[Serializable]
public class Hotel
{
    // Properties to store information about the hotel
    public string Name { get; set; }
    public string ConstructionDate { get; set; }
    public string Address { get; set; }
    public int Stars { get; set; }

    // Lists to store rooms and customers associated with the hotel
    public List<Room> Rooms { get; set; } = new List<Room>();
    public List<Customer> Customers { get; set; } = new List<Customer>();

    
    public Hotel() 
    {
        // Default constructor
    }


    public Hotel(string name, string constructionDate, string address, int stars)
    {
        Name = name;
        ConstructionDate = constructionDate;
        Address = address;
        Stars = stars;
        Rooms = new List<Room>();
        Customers = new List<Customer>();
    }

    // Method to save hotel information to a binary file
    public void SaveToBinary(string file)
    {
       
        using (BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.Create)))
        {
          
            writer.Write(Name);
            writer.Write(ConstructionDate);
            writer.Write(Address);
            writer.Write(Stars);

            
            writer.Write(Rooms.Count);
            foreach (var room in Rooms)
            {
                writer.Write(room.RoomNumber);
                writer.Write(room.Area);
                writer.Write(room.Type);
                writer.Write(room.PricePerNight);
                writer.Write(room.Description);
            }

           
            writer.Write(Customers.Count);
            foreach (var customer in Customers)
            {
                writer.Write(customer.Name);
                writer.Write(customer.Address);
                writer.Write(customer.RoomNumber);
                writer.Write(customer.ArrivalDate);
                writer.Write(customer.LengthOfStay);
            }
        }
    }

    // Method to save hotel information to a text file
    public void SaveToText(string file)
    {
      
        using (TextWriter writer = new StreamWriter(file))
        {
          
            writer.WriteLine(Name);
            writer.WriteLine(ConstructionDate);
            writer.WriteLine(Address);
            writer.WriteLine(Stars);

          
            writer.WriteLine(Rooms.Count);
            foreach (var room in Rooms)
            {
                writer.WriteLine(room.RoomNumber);
                writer.WriteLine(room.Area);
                writer.WriteLine(room.Type);
                writer.WriteLine(room.PricePerNight);
                writer.WriteLine(room.Description);
            }

            writer.WriteLine(Customers.Count);
            foreach (var customer in Customers)
            {
                writer.WriteLine(customer.Name);
                writer.WriteLine(customer.Address);
                writer.WriteLine(customer.RoomNumber);
                writer.WriteLine(customer.ArrivalDate);
                writer.WriteLine(customer.LengthOfStay);
            }
        }
    }

    // Method to save hotel information to an XML file
    public void SaveToXml(string file, Hotel hotel)
    {
      
        using (TextWriter writer = new StreamWriter(file))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Hotel));
            xmlSerializer.Serialize(writer, hotel);
        }
    }

    
    public void SaveToJson(string file, Hotel hotel)
    {
        // Using JsonConvert to serialize the hotel object to a JSON string and write it to the file
        string jsonString = JsonConvert.SerializeObject(hotel);
        File.WriteAllText(file, jsonString);
    }

  
    public void LoadFromBinary(string file)
    {
        // Using BinaryReader to read binary data from the file
        using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
        {
            Name = reader.ReadString();
            ConstructionDate = reader.ReadString();
            Address = reader.ReadString();
            Stars = reader.ReadInt32();

            
            int roomCount = reader.ReadInt32();
            Rooms.Clear();
            for (int i = 0; i < roomCount; i++)
            {
                Room room = new Room
                {
                    RoomNumber = reader.ReadInt32(),
                    Area = reader.ReadDouble(),
                    Type = reader.ReadString(),
                    PricePerNight = reader.ReadDouble(),
                    Description = reader.ReadString()
                };
                Rooms.Add(room);
            }

          
            int customerCount = reader.ReadInt32();
            Customers.Clear();
            for (int i = 0; i < customerCount; i++)
            {
                Customer customer = new Customer
                {
                    Name = reader.ReadString(),
                    Address = reader.ReadString(),
                    RoomNumber = reader.ReadInt32(),
                    ArrivalDate = reader.ReadString(),
                    LengthOfStay = reader.ReadInt32()
                };
                Customers.Add(customer);
            }
        }
    }

    // Method to load hotel information from a text file
    public void LoadFromText(string file)
    {
      
        using (TextReader reader = new StreamReader(file))
        {
            
            Name = reader.ReadLine();
            ConstructionDate = reader.ReadLine();
            Address = reader.ReadLine();
            Stars = int.Parse(reader.ReadLine());

           
            int roomCount = int.Parse(reader.ReadLine());
            Rooms.Clear();
            for (int i = 0; i < roomCount; i++)
            {
                Room room = new Room
                {
                    RoomNumber = int.Parse(reader.ReadLine()),
                    Area = double.Parse(reader.ReadLine()),
                    Type = reader.ReadLine(),
                    PricePerNight = double.Parse(reader.ReadLine()),
                    Description = reader.ReadLine()
                };
                Rooms.Add(room);
            }

          
            int customerCount = int.Parse(reader.ReadLine());
            Customers.Clear();
            for (int i = 0; i < customerCount; i++)
            {
                Customer customer = new Customer
                {
                    Name = reader.ReadLine(),
                    Address = reader.ReadLine(),
                    RoomNumber = int.Parse(reader.ReadLine()),
                    ArrivalDate = reader.ReadLine(),
                    LengthOfStay = int.Parse(reader.ReadLine())
                };
                Customers.Add(customer);
            }
        }
    }

    // Method to load hotel information from an XML file
    public void LoadFromXml(string file)
    {
        
        using (TextReader reader = new StreamReader(file))
        {
            // Using XmlSerializer to deserialize the XML data and populate the current hotel object
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Hotel));
            Hotel loadedHotel = (Hotel)xmlSerializer.Deserialize(reader);

            Name = loadedHotel.Name;
            ConstructionDate = loadedHotel.ConstructionDate;
            Address = loadedHotel.Address;
            Stars = loadedHotel.Stars;
            Rooms = new List<Room>(loadedHotel.Rooms);
            Customers = new List<Customer>(loadedHotel.Customers);
        }
    }

    // Method to load hotel information from a JSON file
    public void LoadFromJson(string file)
    {
        
        string jsonString = File.ReadAllText(file);

        
        Hotel loadedHotel = JsonConvert.DeserializeObject<Hotel>(jsonString);

        
        Name = loadedHotel.Name;
        ConstructionDate = loadedHotel.ConstructionDate;
        Address = loadedHotel.Address;
        Stars = loadedHotel.Stars;
        Rooms = new List<Room>(loadedHotel.Rooms);
        Customers = new List<Customer>(loadedHotel.Customers);
    }

    // method to display hotel information
    public static void DisplayHotelInfo(Hotel hotel)
    {
        Console.WriteLine($"Hotel Name: {hotel.Name}");
        Console.WriteLine($"Construction Date: {hotel.ConstructionDate}");
        Console.WriteLine($"Address: {hotel.Address}");
        Console.WriteLine($"Number of Stars: {hotel.Stars}");

        Console.WriteLine("\nRooms:");
        foreach (var room in hotel.Rooms)
        {
            Console.WriteLine($"Room {room.RoomNumber}: {room.Type}, {room.Area} square meters, ${room.PricePerNight} per night");
        }

        Console.WriteLine("\nCustomers:");
        foreach (var customer in hotel.Customers)
        {
            Console.WriteLine($"Customer: {customer.Name}, Address: {customer.Address}, Room Number: {customer.RoomNumber}, Arrival Date: {customer.ArrivalDate}, Length of Stay: {customer.LengthOfStay} nights");
        }
    }
}