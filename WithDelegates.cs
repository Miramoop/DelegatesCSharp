// CSCI 436 - Assignment #5 - Delegates (function pointers)		       	          
// Miranda Morris		      										       
// 5/4/2024

// Write a C# program that demonstrates the use of delegates to pass a method into another method as a parameter.

using System;
using System.Collections.Generic;

namespace WithDelegateExample
{
    public class Students
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }

    public delegate bool StudentsDelegate(Students s);

    public class Program
    {
        public static void Main()
        {
            List<Students> students = new List<Students>()
                {
                    new Students {Name = "Abby", Age = 25},
                    new Students {Name = "Bobby", Age = 15},
                    new Students {Name = "Carly", Age = 19},
                    new Students {Name = "Danny", Age = 30},
                    new Students {Name = "Edward", Age = 45},
                    new Students {Name = "Favian", Age = 13},
                    new Students {Name = "Gabby", Age = 18}
                };

            GetStudentsList(students, "Middle School", CheckEligibleForMiddleSchool);
            GetStudentsList(students, "High School", CheckEligibleForHighSchool);
            GetStudentsList(students, "University", CheckEligibleForUniversity);

            Console.ReadLine();
        }

        public static bool CheckEligibleForMiddleSchool(Students s)
        {
            return s.Age >= 12 && s.Age <= 13;
        }

        public static bool CheckEligibleForHighSchool(Students s)
        {
            return s.Age >= 14 && s.Age > 17;
        }

        public static bool CheckEligibleForUniversity(Students s)
        {
            return s.Age >= 18;
        }


        public static void GetStudentsList(List<Students> students, string schoolname, StudentsDelegate obj)
        {
            foreach (var item in students)
            {
                if (obj(item))
                {
                    Console.WriteLine("{0} is eligible for {1}", item.Name, schoolname);
                }
            }
        }

    }
}
