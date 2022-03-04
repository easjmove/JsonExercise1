using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExercise1.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public int MonthsEmployed { get; set; }
        public List<string> JobAreas { get; set; }

        public override string ToString()
        {
            string result = $"Name: {Name} - Salary: {Salary} - MonthsEmployed: {MonthsEmployed}\r\n      JobAreas:\r\n";
            foreach (string area in JobAreas)
            {
                result += $"        Area: {area}\r\n";
            }
            return result;
        }
    }
}
