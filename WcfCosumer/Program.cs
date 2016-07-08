
namespace WcfCosumer
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var response = 's';

            var username = String.Empty;
            var password = String.Empty;

            while (!response.Equals('x'))
            {

                switch (response)
                {
                    case 'a':
                        Console.Write("Enter Username: ");
                        username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        password = Console.ReadLine();
                        BookWorker.AddBullsEye(username, password);
                        break;
                    case 'b':
                        Console.Write("Enter Username: ");
                        username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        password = Console.ReadLine();
                        BookWorker.AddFiveDysfunctions(username, password);
                        break;
                    case 'c':
                        Console.Write("Enter Username: ");
                        username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        password = Console.ReadLine();
                        BookWorker.GetBullsEyeBook(username, password);
                        break;
                    case 'd':
                        Console.Write("Enter Username: ");
                        username = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        password = Console.ReadLine();
                        BookWorker.GetAllBooks(username, password);
                        break;
                }

                Console.Clear();
                Console.WriteLine("*** Consumer: WCF ***");
                Console.WriteLine();
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
