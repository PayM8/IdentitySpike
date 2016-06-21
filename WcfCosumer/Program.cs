
namespace WcfCosumer
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var response = 's';

            while (!response.Equals('x'))
            {
                switch (response)
                {
                     case 'a' : BookWorker.AddBullsEye();
                        break;
                     case 'b' : BookWorker.AddFiveDysfunctions();
                        break;
                     case 'c' : BookWorker.GetBullsEyeBook();
                        break;
                     case 'd': BookWorker.GetAllBooks();
                        break;
                }
                
                Console.Clear();
                Console.WriteLine("*** WCF Consumer ***");
                Console.WriteLine("[a] Add BullsEye book");
                Console.WriteLine("[b] Add FiveDysfunctions book");
                Console.WriteLine("[c] Get BullsEye book");
                Console.WriteLine("[d] Get all books");

                Console.WriteLine("Press [x] to exit.");
                var raw = Console.ReadKey().KeyChar;
                response = Convert.ToChar(raw);
                Console.Clear();
            }
         
        }
    }
}
