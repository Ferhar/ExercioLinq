using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using ExercioLinq.Entites;

namespace ExercioLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\in.txt";

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }

                Console.Write("Enter salary:");
                double salarySearch = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                var emails = list.Where(s => s.Salary > salarySearch).OrderBy(s => s.Name).Select(s => s.Email);

                foreach(string e in emails)
                {
                    Console.WriteLine(e);
                }

                var sumSalary = list.Where(s => s.Name[0] == 'M').Sum(s => s.Salary);

                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sumSalary.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
