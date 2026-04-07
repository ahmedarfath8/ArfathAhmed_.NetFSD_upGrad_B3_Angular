using System.Diagnostics;

namespace Practice
{
    internal class Program
    {
        class StudentGrade
        {
            public int Average(params int[] marks)
            {
                int sum = 0;
                for (int i = 0; i < marks.Length; i++)
                {
                    if (marks[i] >= 0 && marks[i] <= 100){ 
                    sum += marks[i];
                    }
                    else{
                        Console.WriteLine("Please Check the Marks Entered"); return -1;
                    }
                }
                return sum/marks.Length;
            }
            public void grade(int avg)
            {
                switch (avg)
                {
                    case > 80 : Console.WriteLine("A"); break;
                    case > 70 : Console.WriteLine("B"); break;
                    case > 60 : Console.WriteLine("C"); break;
                    case > 50 : Console.WriteLine("D"); break;
                    case > 40 : Console.WriteLine("E"); break;
                    case <= 30: Console.WriteLine("F"); break;
                    default: Console.WriteLine("Please Check the Marks Entered");
                        return;
                }
            }
        }
        static void Main(string[] args)
        {
            StudentGrade s1 = new StudentGrade();
            //int avg = (int)s1.Average(80,78,98,54,88);
            Console.WriteLine("Result");
            Console.WriteLine(" - Average Marks : " + s1.Average(80,78,98,54,88));
            Console.Write(" - Grade Awarded : ");s1.grade(s1.Average(80,78,98,54,88));
        }
    }
}
