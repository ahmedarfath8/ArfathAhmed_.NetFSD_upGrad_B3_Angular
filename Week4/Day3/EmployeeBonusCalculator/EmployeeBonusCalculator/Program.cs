namespace EmployeeBonusCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name = "";
            int experience = 0;
            float salary = 0;
            float bonus = 0;
            Console.Write("Enter Name : ");
            name = Console.ReadLine();
            Console.Write("Enter Experience : ");
            experience = int.Parse(Console.ReadLine());
            Console.Write("Enter Salary : ");
            salary = float.Parse(Console.ReadLine());
            Console.WriteLine();
            if(salary <0 || experience  <0) return
            if (experience < 2)
            {
                bonus = salary * 0.05f;
            }
            else if (experience >= 2 && experience < 5)
            {
                bonus = salary * 0.10f;
            }
            else
            {
                bonus = salary * 0.15f;
            }
            salary += bonus;
            Console.WriteLine($"Salary BreakUp \n Employee : {name}\n Bonus : {bonus} \n Final Salary : {salary}");
        }
    }
}
