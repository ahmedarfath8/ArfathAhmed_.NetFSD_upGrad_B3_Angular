namespace Practice
{
    internal class Program
    {
        class Employee
        {
            public String Name { get; set; }
            public decimal Salary { get; set; }
            public Employee(String name, decimal salary)
            {
                if (String.IsNullOrEmpty(name)) { throw new Exception("Name Cannot Be Empty"); }
                if (salary < 0) { throw new Exception("Salary Cannot be 0 "); }
                Name = name;
                Salary = salary;
            }
            public virtual void CalculateSalary()
            {
                decimal fSalary = Salary + (Salary * 0.05m);
                Console.WriteLine($"Employee {Name} Final Salary: {fSalary:F2}");
            }
        }
        class Manager : Employee
        {
            public String Position {  get; set; }
            public Manager(String name, decimal salary, String position = "Manager") : base(name,salary) {
                Position = position;
            }
            public override void CalculateSalary()
            {
                decimal fSalary = Salary + (Salary * 0.2m);
                Console.WriteLine(" ** Employee Information ** ");
                Console.WriteLine($"Name : {Name} \n Role : Manager \n Bonus : 10 % \n Salary : {Salary} \n Final Salary : {fSalary:F2}");
                Console.WriteLine("----------------------------");
            }
        }
        class Developer : Employee
        {
            public String Position { get; set; }
            public Developer(String name, decimal salary,String position = "Developer") : base(name, salary)
            {
                Position = position;
            }
            public override void CalculateSalary()
            {
                decimal fSalary = Salary + (Salary * 0.1m);
                Console.WriteLine(" ** Employee Information ** ");
                Console.WriteLine($"Name : {Name} \n Role : Developer \n Bonus : 10 % \n Salary : {Salary} \n Final Salary : {fSalary:F2}");
                Console.WriteLine("----------------------------");
            }
        }
        static void Main(string[] args)
        {
            Employee emp1 = new Manager("arfth", 60000m);
            Employee emp2 = new Developer("ahmed", 60000m);
            emp1.CalculateSalary();
            emp2.CalculateSalary();
        }
    }
}
