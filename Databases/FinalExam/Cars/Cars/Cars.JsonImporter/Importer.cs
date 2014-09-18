namespace Cars.JsonImporter
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using Cars.Data;
    using Cars.Models;
    using Newtonsoft.Json.Linq;

    public static class Importer
    {
        private static CarsDbContext db;

        public static void ImportFromDir(string dataFilesDirectory)
        {
            string[] jsonFilePaths = Directory.GetFiles(dataFilesDirectory + "Json", "*.json");
            int currentlyAddedCarsCounter = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            db = new CarsDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;

            Console.WriteLine("Adding cars into DB from  Json - one dot = 100 cars added (saving after each car)");
            foreach (var filePath in jsonFilePaths)
            {
                string currentFileText = File.ReadAllText(filePath);
                JArray allCarInfoAsObjects = JArray.Parse(currentFileText);

                foreach (JObject item in allCarInfoAsObjects)
                {
                    currentlyAddedCarsCounter++;
                    if (currentlyAddedCarsCounter >= 100)
                    {
                        Console.Write(".");

                        db = new CarsDbContext();
                        db.Configuration.AutoDetectChangesEnabled = false;

                        currentlyAddedCarsCounter = 0;
                    }

                    var year = (int)item["Year"];
                    var transmissionType = (int)item["TransmissionType"];
                    var manufacturerName = (string)item["ManufacturerName"];
                    var model = (string)item["Model"];
                    var price = (decimal)item["Price"];
                    var dealerName = (string)item["Dealer"]["Name"];
                    var cityName = (string)item["Dealer"]["City"];

                    Manufacturer currentManufacturer = GetManufacturer(manufacturerName);
                    if (!ManufacturerExists(manufacturerName))
                    {
                        db.Manufacturers.Add(currentManufacturer);
                    }

                    City currentCity = GetCity(cityName);
                    if (!CityExists(cityName))
                    {
                        db.Cities.Add(currentCity);
                    }

                    Dealer currentDealer = new Dealer
                    {
                        Name = dealerName,
                    };

                    currentDealer.Cities.Add(currentCity);
                    db.Dealers.Add(currentDealer);

                    Car currentCar = new Car
                    {
                        Year = year,
                        TransmissionType = (TransmissionType)transmissionType,
                        Manufacturer = currentManufacturer,
                        Model = model,
                        Price = price,
                        Dealer = currentDealer
                    };

                    db.Cars.Add(currentCar);
                    db.SaveChanges();
                }
            }

            Console.WriteLine("\nAll cars added! Finally.....");
            Console.WriteLine("Elapsed time: {0}", sw.Elapsed);

            db.Configuration.AutoDetectChangesEnabled = true;
        }

        private static City GetCity(string cityName)
        {
            var city = db.Cities.FirstOrDefault(c => c.Name == cityName);
            if (city == null)
            {
                city = new City
                {
                    Name = cityName
                };
            }

            return city;
        }

        private static Manufacturer GetManufacturer(string manufacturerName)
        {
            var manufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
            if (manufacturer == null)
            {
                manufacturer = new Manufacturer
                {
                    Name = manufacturerName
                };
            }

            return manufacturer;
        }

        private static bool CityExists(string cityName)
        {
            var cityExists = db.Cities.Any(c => c.Name == cityName);

            return cityExists;
        }

        private static bool ManufacturerExists(string manufacturerName)
        {
            var manufacturerExists = db.Manufacturers.Any(m => m.Name == manufacturerName);

            return manufacturerExists;
        }
    }
}
