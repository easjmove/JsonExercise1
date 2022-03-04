using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExercise1.Models
{
    public class CarDealerShip
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Car> Cars { get; set; }
        public List<Employee> Employees { get; set; }

        public override string ToString()
        {
            string result = $"Name: {Name} - Address: {Address}\r\n  Cars:\r\n";
            foreach (Car car in Cars)
            {
                result += $"    Car: {car.ToString()}\r\n";
            }
            result += "  Employees:\r\n";
            foreach (Employee employee in Employees)
            {
                result += $"    Employee: {employee.ToString()}\r\n";
            }
            return result;
        }
    }
}
