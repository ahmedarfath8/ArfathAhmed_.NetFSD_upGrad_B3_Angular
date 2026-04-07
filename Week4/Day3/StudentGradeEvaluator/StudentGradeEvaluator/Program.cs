namespace StudentGradeEvaluator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name = "";
            Byte marks = 0;
            Char grade = '0';
            Console.Write("Enter Student Name : ");
            name = Console.ReadLine();
            Console.Write("Enter the Marks [0-100] : ");
            marks = Byte.Parse(Console.ReadLine());
            if (marks >= 0 && marks <= 100) {
                switch (marks)
                {
                    case > 85:
                        grade = 'A';
                        Console.WriteLine($"{name}'s grade is : {grade}");
                        break;

                    case > 70:
                        grade = 'B';
                        Console.WriteLine($"{name}'s grade is : {grade}");
                        break;

                    case > 55:
                        grade = 'C';
                        Console.WriteLine($"{name}'s grade is : {grade}");
                        break;

                    case > 40:
                        grade = 'D';
                        Console.WriteLine($"{name}'s grade is : {grade}");
                        break;

                    default:
                        grade = 'F';
                        Console.WriteLine($"{name}'s grade is : {grade}");
                        break;
                }
            }
        }
    }
}
