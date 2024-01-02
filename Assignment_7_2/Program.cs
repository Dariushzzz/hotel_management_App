using System;

namespace Assignment_7_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Hotel class
            Hotel hotel = new Hotel
            {
                Name = "Sokos",
                ConstructionDate = "23-3-2021",
                Address = "Joku",
                Stars = 5
            };

            // Add rooms and customers to the hotel
            hotel.Rooms.Add(new Room { RoomNumber = 123, Area = 30.5, Type = "Double", PricePerNight = 120, Description = "Room with two beds" });
            hotel.Rooms.Add(new Room { RoomNumber = 234, Area = 20.5, Type = "Single", PricePerNight = 80, Description = "Room with a single bed" });
            hotel.Rooms.Add(new Room { RoomNumber = 345, Area = 60.2, Type = "Family", PricePerNight = 250, Description = "Big room for a family" });
            hotel.Rooms.Add(new Room { RoomNumber = 200, Area = 30.5, Type = "Double", PricePerNight = 110, Description = "Room with street view" });
            hotel.Rooms.Add(new Room { RoomNumber = 210, Area = 30.5, Type = "Double", PricePerNight = 110, Description = "Room with street view" });

            hotel.Customers.Add(new Customer { Name = "Lalli Laktoosi", Address = "Suvilahti", RoomNumber = 200, ArrivalDate = "3-1-2023", LengthOfStay = 3 });
            hotel.Customers.Add(new Customer { Name = "Loka Laitinen", Address = "Keskusta", RoomNumber = 123, ArrivalDate = "3-6-2023", LengthOfStay = 2 });
            hotel.Customers.Add(new Customer { Name = "Kyröön Humppaministeri", Address = "kyröö", RoomNumber = 345, ArrivalDate = "3-10-2023", LengthOfStay = 7 });
            hotel.Customers.Add(new Customer { Name = "Antti Kruuti", Address = "Sjoki", RoomNumber = 210, ArrivalDate = "3-5-2023", LengthOfStay = 6 });
            hotel.Customers.Add(new Customer { Name = "Samu Laine", Address = "Salo", RoomNumber = 234, ArrivalDate = "3-4-2023", LengthOfStay = 3 });

        

            // Save hotel data to files
            hotel.SaveToBinary(@"C:\Temp\info.dat");
            hotel.SaveToText(@"C:\Temp\info.txt");
            hotel.SaveToXml(@"C:\Temp\info.xml", hotel);
            hotel.SaveToJson(@"C:\Temp\info.json", hotel);

            // Load data from files
            Hotel loadedHotelBinary = new Hotel();
            loadedHotelBinary.LoadFromBinary(@"C:\Temp\info.dat");

            Hotel loadedHotelText = new Hotel();
            loadedHotelText.LoadFromText(@"C:\Temp\info.txt");

            Hotel loadedHotelXml = new Hotel();
            loadedHotelXml.LoadFromXml(@"C:\Temp\info.xml");

            Hotel loadedHotelJson = new Hotel();
            loadedHotelJson.LoadFromJson(@"C:\Temp\info.json");

            // Test and display loaded data
            Console.WriteLine("binary file:");
            Hotel.DisplayHotelInfo(loadedHotelBinary);

            Console.WriteLine("\ntext file:");
            Hotel.DisplayHotelInfo(loadedHotelText);

            Console.WriteLine("\nXML file:");
            Hotel.DisplayHotelInfo(loadedHotelXml);

            Console.WriteLine("\nJSON file:");
            Hotel.DisplayHotelInfo(loadedHotelJson);

            Console.ReadLine();
        }
    }
}