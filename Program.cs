namespace Synchronization_Homework
{
    internal class Program
    {
        static Random random = new Random();
        
        static ManualResetEvent mre = new ManualResetEvent(true);
        static void Main(string[] args)
        {
            
            Thread[] threads = new Thread[4];

            
            
            List<int> ints = new List<int>();
           

            GenerationNumber(ints);
            MaxinumNumber(ints);
            MinimumNumber(ints);
            AverageNumber(ints);

        }
        public  static List<int> GenerationNumber(List<int> num)
        {
            mre.Reset();
            for (int i = 0; i < 1000; i++)
            {
                num.Add(random.Next(0, 10000));
                
            }
            mre.Set();
            return num;
            
        }

        public static void MaxinumNumber(List<int> num) {
            mre.Reset();
            Console.WriteLine($"Number Max: {num.Max()}");
            mre.Set();
            
        }

        public static void MinimumNumber(List<int> num)
        {
            mre.Reset();
            Console.WriteLine($"Number Min: {num.Min()}");
            mre.Set();
        }

        public static void AverageNumber(List<int> num)
        {
            mre.Reset();
            double number = num.Average();
            Console.WriteLine($"Average number {number}");
            mre.Set();

        }
    }

    
}
