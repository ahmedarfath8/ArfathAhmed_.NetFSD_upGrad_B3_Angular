using System;
using System.Collections.Generic;

namespace Practice
{
    // 1. Define Record
    public record Student(int RollNumber, string Name, string Course, int Marks);

    internal class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== Student Record Management System =====");
                Console.WriteLine("1. Add Students");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search by Roll Number");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddStudents();
                        break;
                    case 2:
                        DisplayStudents();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        // 2. Add Students
        static void AddStudents()
        {
            Console.Write("Enter number of students: ");
            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEntering details for Student {i + 1}:");

                int roll;
                while (true)
                {
                    Console.Write("Enter Roll Number: ");
                    if (int.TryParse(Console.ReadLine(), out roll) && roll > 0)
                        break;
                    Console.WriteLine("Invalid Roll Number!");
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                int marks;
                while (true)
                {
                    Console.Write("Enter Marks (0-100): ");
                    if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                        break;
                    Console.WriteLine("Invalid Marks!");
                }

                students.Add(new Student(roll, name, course, marks));
            }
        }

        // 3. Display All Records
        static void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No records available.");
                return;
            }

            Console.WriteLine("\nStudent Records:");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }

        // 4. Search by Roll Number
        static void SearchStudent()
        {
            Console.Write("Enter Roll Number to search: ");
            int roll;

            if (!int.TryParse(Console.ReadLine(), out roll))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            var student = students.Find(s => s.RollNumber == roll);

            Console.WriteLine("\nSearch Result:");
            if (student != null)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine($"Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}