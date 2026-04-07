namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            char op = '0';
            int result = 0;
            Console.Write("Enter The First Number : ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter The Second Number : ");
            num2 = int.Parse(Console.ReadLine());
            Console.Write("Enter The Operator : ");
            op=char.Parse(Console.ReadLine());
            switch (op) { 
            case '+':
                    Console.Write("Result : "+ (num1 + num2));
                    break;
            case '-':
                    Console.Write("Result : " + (num1 - num2));
                    break;
            case '*':
                    Console.Write("Result : " + (num1 * num2));
                    break;
            case '/':
                    if (num2 == 0) {
                        Console.Write("Cannot Divide By 0 ");
                        return;
                    }
                    Console.Write("Result : " + (num1 / num2));
                    break;
            default:
                    Console.Write("Invalid Operator");
                    Console.ReadLine(); //waits for response before closing 
                    return;
            }
        }
    }
}
