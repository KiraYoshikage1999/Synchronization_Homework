namespace Synchronization_Homework
{
    internal class Program
    {
        static Random random = new Random();
        
        static ManualResetEvent mre = new ManualResetEvent(true);
        static async Task Main(string[] args)
        {
            
            Thread[] threads = new Thread[4];
           
            
            List<int> ints = new List<int>();


            await new Program().GenerationNumber(ints);
            var maxTask = new Program().MaxinumNumber(ints);
            var minTask = new Program().MinimumNumber(ints);
            var avgTask = new Program().AverageNumber(ints);

            //Гуглил как вызываются задачи нашел этот вариант от Гемини, узнал, что оказывается не статические
            // методы нельзя вызывать в блоке Main, не замечал этого, ну теперь знаю, надеюсь теперь домашка корректная.

            await Task.WhenAll(maxTask, minTask, avgTask);
        }
        public async Task GenerationNumber(List<int> num)
        {
            mre.Reset();
            for (int i = 0; i < 1000; i++)
            {
                num.Add(random.Next(0, 10000));
                
            }
            mre.Set();
            
            
        }

        public async Task MaxinumNumber(List<int> num) {
            mre.Reset();
            Console.WriteLine($"Number Max: {num.Max()}");
            mre.Set();
            
        }

        public async Task MinimumNumber(List<int> num)
        {
            mre.Reset();
            Console.WriteLine($"Number Min: {num.Min()}");
            mre.Set();
        }

        public async Task AverageNumber(List<int> num)
        {
            mre.Reset();
            double number = num.Average();
            Console.WriteLine($"Average number {number}");
            mre.Set();

        }
    }

    
}
