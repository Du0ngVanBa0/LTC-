using System;
using System.Collections.Generic;
using System.Linq;

namespace UseLinQ
{
    class Brand
    {
        public string code { get; set; }
        public string name { get; set; }

        public Brand(string code, string name)
        {
            this.code = code;
            this.name = name;
        }
    }
    class Vehicle
    {
        public string code { get; set; }
        public string name { get; set; }
        public long price { get; set; }
        public int releaseYear { get; set; }
        public Brand brand { get; set; }

        public Vehicle(string code, string name, long price, int releaseYear, Brand brand)
        {
            this.code = code;
            this.name = name;
            this.price = price;
            this.releaseYear = releaseYear;
            this.brand = brand;
        }

        public Vehicle()
        {
        }
    }
    class Car : Vehicle
    {
        public Car(string code, string name, long price, int releaseYear, Brand brand) : base(code, name, price, releaseYear, brand)
        {
        }
    }

    class Truck: Vehicle
    {
        //khả năng chịu tải
        public double PayloadCapacity { get; set; }
        public Truck(string code, string name, long price, int releaseYear, Brand brand, double payloadCapacity) : base(code, name, price, releaseYear, brand)
        {
            PayloadCapacity = payloadCapacity;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Brand> brands = new List<Brand>
            {
                new Brand("B001","Toyota"),
                new Brand("B002","Ford"),
                new Brand("B003","Honda"),
                new Brand("B004","Chevrolet"),
                new Brand("B005","Nissan"),
            };
            List<Car> cars = new List<Car>
            {
                new Car("C001", "Camry", 300000, 1990, brands[0]),
                new Car("C002", "F-150", 400000, 1920, brands[1]),
                new Car("C003", "Civic", 250000, 1888, brands[2]),
                new Car("C004", "Silverado", 450000, 2021, brands[3]),
                new Car("C005", "Altima", 280000, 2023, brands[4]),
            };
            List<Truck> trucks = new List<Truck>
            {
                new Truck("T001", "Ram", 350000, 2022, brands[1], 12000),
                new Truck("T002", "F-250", 450000, 2023, brands[1], 16000),
                new Truck("T003", "Tundra", 400000, 2000, brands[0], 14000),
                new Truck("T004", "Silverado HD", 500000, 1998, brands[3], 18000),
                new Truck("T005", "Titan XD", 380000, 2023, brands[4], 15000),
            };
            var filteredPriceCars = cars
                .Where(car => car.price >= 100000 && car.price <= 250000);
            var filteredYearCars = cars
                .Where(car => car.releaseYear > 1990);
            var groupedByBrand = cars
              .GroupBy(car => car.brand)
              .Select(group => new
              {
                  BrandName = group.Key.name,
                  TotalPrice = group.Sum(car => car.price)
              });
            Console.WriteLine("\n-----List Car have price from 100000 to 250000:");
            foreach (var car in filteredPriceCars)
            {
                Console.WriteLine($"Car Code: {car.code}, Name: {car.name}, Price: {car.price}, Year: {car.releaseYear}, Brand: {car.brand.name}");
            }
            Console.WriteLine("\n----List Car have releasedYear after 1990:");
            foreach (var car in filteredYearCars)
            {
                Console.WriteLine($"Car Code: {car.code}, Name: {car.name}, Price: {car.price}, Year: {car.releaseYear}, Brand: {car.brand.name}");
            }
            Console.WriteLine("\n----Total price of cars group by brand:");
            foreach (var group in groupedByBrand)
            {
                Console.WriteLine($"Brand: {group.BrandName}, Total Price: {group.TotalPrice}");
            }
            var sortedTrucks = trucks.OrderByDescending(truck => truck.releaseYear);
            Console.WriteLine("\n----List Trucks Sorted by Release Year (Newest First):");
            foreach (var truck in sortedTrucks)
            {
                Console.WriteLine($"Truck Code: {truck.code}, Name: {truck.name}, Release Year: {truck.releaseYear}");
            }
            Console.WriteLine("\n---Company Owners of Trucks:");
            foreach (var truck in trucks)
            {
                Console.WriteLine($"Truck Code: {truck.code}, Company Owner: {truck.brand.name}");
            }
        }
    }
}
