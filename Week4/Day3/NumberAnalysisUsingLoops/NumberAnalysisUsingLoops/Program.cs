namespace NumberAnalysisUsingLoops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int evenCount = 0;
            int oddCount = 0;
            int sum =0;
            Console.Write("Enter the Number N : ");
            n = int.Parse(Console.ReadLine());
            if (n <= 0) return;
            for (int i = 1; i <=n; i++)
            {
                if (i % 2 == 0){ evenCount++; }
                else{ oddCount++; }
                sum += i;
            }
            Console.WriteLine($"Even Count: {evenCount}\nOdd Count: {oddCount}\nSum: {sum}\n");
        }
    }
}
