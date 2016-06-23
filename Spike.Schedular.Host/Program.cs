
namespace Spike.Schedular.Host
{
    using System;
    using System.Threading;
    using Books;

    public class Program
    {
        private const int TicTimeInMilliseconds = 8000;

        public static void Main()
        {
            Thread.Sleep(2000);

            // Because this is a different thread and database stub is a static we need to add book to this instance 
            BookWorker.AddBullsEye();

            var timer = new Timer(TimerCallback, null, 0, TicTimeInMilliseconds);
            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
            Console.Clear();

            if (BookWorker.IsBusy) { return;}

            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            lock (typeof(BookWorker))
            {
                var task = BookWorker.GetBookAsync(1);

                if (task.IsCompleted)
                {
                    Console.WriteLine(task.Result.ToString());
                }
            }

            Thread.Sleep(TicTimeInMilliseconds/2);

            Console.Clear();
            Console.WriteLine("*** APP: Schedular ***");
            Console.WriteLine();
            Console.WriteLine("Press Any Key to Exit");

            GC.Collect();
        }
    }
}
