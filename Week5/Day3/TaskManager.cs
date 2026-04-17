using Microsoft.VisualBasic.FileIO;
using System;


namespace Practice
{
    internal class Program
    {
        static List<string> list = new List<String>();

        public static void AddTask()
        {
            Console.Write("\nEnter task : ");
            String task = Console.ReadLine();
            if(String.IsNullOrEmpty(task))
            {
                Console.WriteLine("Task Cannot Be Empty");
                return;
            }
            list.Add(task);
            Console.WriteLine("Task added!");
        }

        public static void ViewTask()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            Console.WriteLine("Task");
            int count = 1;
            foreach (var item in list) { 
                Console.WriteLine($"{count}. { item}"); 
                count++;
            }
        }
        public static void RemoveTask() {
            if (list.Count == 0)
            {
                Console.WriteLine("No tasks to remove.");
                return;
            }
            Console.Write("\nEnter the task number to remove : ");
            int index;
            if (!int.TryParse(Console.ReadLine(), out index) && index-1<=list.Count)
            {
                Console.Write("please enter a valid number : ");
                return;
            }
            string task = list[index - 1];
            list.RemoveAt(index - 1);
        }
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\nTo-Do List Manager \n1. Add Task \r\n2. View Tasks \r\n3. Remove Task \r\n4. Exit ");
                int option;
                Console.Write("\nChoose an option :");
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    return;
                }
                switch (option)
                {
                    case 1: AddTask(); break;
                    case 2: ViewTask(); break;
                    case 3: RemoveTask(); break;
                    case 4: Console.WriteLine("\nthankyou.."); return;
                    default:Console.WriteLine("Invalid input. Try again.");continue;
                }

            }
        }
    }
}