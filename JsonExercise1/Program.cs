using JsonExercise1.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup            
            Car myCar = ReadCarFromConsole();
            string manualSerialized = "{\"Brand\":\"" + myCar.Brand + "\",\"Model\":\"" + myCar.Model +
                "\",\"Color\":\"" + myCar.Color + "\",\"Mileage\":" + myCar.Mileage + "}";
            string manualSerializedSpecial = "{\"Brand\":\"BM\\\"W\",\"Model\":\"330e\",\"Color\":\"Black\",\"Mileage\":123}";

            List<Car> multipleCars = new List<Car>();
            multipleCars.Add(myCar);
            multipleCars.Add(ReadCarFromConsole());

            //Part 2
            ShowSerializationSingleCar(myCar, manualSerialized);
            ShowSerializationListOfCars(multipleCars);

            //Part 3
            ShowDeSerializationSingleCar(myCar);
            ShowDeSerializationListOfCars(multipleCars);
            ShowDeserializeManualCarString(manualSerialized, myCar);

            //Part 4
            ShowDeserializeManualCarStringSpecialChar(manualSerializedSpecial);

            //Part 5
            string toBeDeserialized = "{\"Name\":\"Move Cars\",\"Address\":\"MagleGaardsvej 2\",\"Cars\":[{\"Brand\":\"BMW\",\"Model\":\"330e\",\"Color\":\"Green\",\"Mileage\":45721},{\"Brand\":\"VW\",\"Model\":\"Golf\",\"Color\":\"Red\",\"Mileage\":20},{\"Brand\":\"Ford\",\"Model\":\"Galaxy\",\"Color\":\"Black\",\"Mileage\":124326}],\"Employees\":[{\"Name\":\"Move\",\"Salary\":1000000,\"MonthsEmployed\":28,\"JobAreas\":[\"President\",\"Mechanic\"]},{\"Name\":\"Not Move\",\"Salary\":100,\"MonthsEmployed\":13,\"JobAreas\":[\"Vice-President\",\"Mechanic\"]}]}";
            ShowCarDealerShipDeserialized(toBeDeserialized);
        }

        public static Car ReadCarFromConsole()
        {
            Console.WriteLine("Enter values for the car:");

            Console.WriteLine("Brand:");
            string brand = Console.ReadLine();

            Console.WriteLine("Model:");
            string model = Console.ReadLine();

            Console.WriteLine("Color:");
            string color = Console.ReadLine();

            Console.WriteLine("Mileage:");
            int mileage = 0;
            while (!int.TryParse(Console.ReadLine(), out mileage))
            {
                Console.WriteLine("Not a valid integer!");
            }

            return new Car() { Brand = brand, Model = model, Color = color, Mileage = mileage };
        }

        public static void ShowSerializationSingleCar(Car myCar, string manualSerialized)
        {
            Console.WriteLine(myCar.ToString()); //showing the toString method
            string serializedCar = JsonSerializer.Serialize(myCar);

            Console.WriteLine("Manually serialized: " + manualSerialized); // showing the expected serialization
            Console.WriteLine("Serialized: " + serializedCar); // showing the result of the serialization

            if (serializedCar.Equals(manualSerialized, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Manual serialization matches actual serialization");
            }
            else
            {
                Console.WriteLine("Manual serialization does not match actual serialization");
            }
        }

        public static void ShowSerializationListOfCars(List<Car> cars)
        {
            string serializedCars = JsonSerializer.Serialize(cars);
            Console.WriteLine("Serialized list: " + serializedCars);
        }

        public static void ShowDeSerializationSingleCar(Car myCar)
        {
            string serializedCar = JsonSerializer.Serialize(myCar);
            Car deserializedCar = JsonSerializer.Deserialize<Car>(serializedCar);
            Console.WriteLine("ToString on original Car: " + myCar.ToString());
            Console.WriteLine("ToString on Deserialized Car: " + deserializedCar.ToString());

            if (myCar.ToString().Equals(deserializedCar.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Original and deserialized car ToString methods match :)");
            }
            else
            {
                Console.WriteLine("Original and deserialized car ToString methods does not match :(");
            }
        }

        public static void ShowDeSerializationListOfCars(List<Car> cars)
        {
            string serializedCars = JsonSerializer.Serialize(cars);
            List<Car> deserializedCars = JsonSerializer.Deserialize<List<Car>>(serializedCars);
            foreach (Car deserializedCar in deserializedCars)
            {
                Console.WriteLine(deserializedCar.ToString());
            }
        }

        public static void ShowDeserializeManualCarString(string manualSerializedCar, Car myCar)
        {
            Car deserializedCar = JsonSerializer.Deserialize<Car>(manualSerializedCar);
            Console.WriteLine("deserializedCar ToString: " + deserializedCar.ToString());
            Console.WriteLine("myCar ToString: " + myCar.ToString());

            if (myCar.ToString().Equals(deserializedCar.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Manual deserialized car and original car ToString methods match :)");
            }
            else
            {
                Console.WriteLine("Manual deserialized car and original car ToString methods does not match :(");
            }
        }

        public static void ShowDeserializeManualCarStringSpecialChar(string manualSerialized)
        {
            
            Console.WriteLine(manualSerialized);
            Car deserializedCar = JsonSerializer.Deserialize<Car>(manualSerialized);
            Console.WriteLine(deserializedCar.ToString());

            if (deserializedCar.Brand.Equals("BM\\\"W", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Special charecter ok :)");
            }
            else
            {
                Console.WriteLine("Special charecter not ok :(");
            }
        }

        public static void ShowCarDealerShipDeserialized(string toBeDeserialized)
        {
            CarDealerShip myDealerShip = JsonSerializer.Deserialize<CarDealerShip>(toBeDeserialized);
            Console.WriteLine(myDealerShip.ToString());
        }
    }
}
