namespace Practice
{
    internal class Program
    {
        public  static int[] GetEvenOddCount(int[] arr)
        {
            int evenCount = 0;int oddCount = 0;
            for (int i = 0; i < arr.Length; i++){
                if (arr[i] % 2 == 0) { evenCount++; }
                else { oddCount++; }
            }
            return new int[] {oddCount,evenCount};
        }
        public  static int [] GetEvenOddSum(int[] arr)
        {
            int evensum = 0;int oddSum = 0;
            for (int i = 0; i < arr.Length; i++){
                if (arr[i] % 2 == 0) { evensum += arr[i]; }
                else { oddSum += arr[i]; }
            }
            return new int[] { evensum, oddSum };
        }
        static void Main(string[] args)
        {
            //int n = 0;
            //Console.Write("Enter the lenght of array : ");
            //n = int.Parse(Console.ReadLine());
            //int[] arr = new int[n];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write("Enter the number : ");
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            //int [] count = GetEvenOddCount(arr);
            //int[] sum = GetEvenOddSum (arr);
            //Console.WriteLine($"the no of even numbers are : {count[0]} and no of odd numbers are : {count[1]}");
            //Console.WriteLine($"the Sum of even numbers are : {sum[0]} and Sum of odd numbers are : {sum[1]}");
            Program p1 = new Program();
            Program p2 = new Program();
            Console.WriteLine(p1 == p2);


        }
    }
}
