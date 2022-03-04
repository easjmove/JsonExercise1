using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExercise1.Models
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }

        public Car()
        {
            //Empty constructor needed for (de)serialization
        }

        public Car(string brand, string model, string color, int mileage)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Mileage = mileage;
        }

        public override string ToString()
        {
            return $"Brand: {Brand} - Model: {Model} - Color: {Color} - Mileage: {Mileage}";
        }
    }
}