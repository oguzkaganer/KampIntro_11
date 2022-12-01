using System.ComponentModel;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ActionDemo();

            Func<int, int, int> add = Topla;

            Console.WriteLine(add(3,5));

            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(0, 100);
            };

            Func<int> getRandomNumber2=()=>new Random().Next(0,100);

            Console.WriteLine(getRandomNumber());
            //Thread.Sleep(1000);
            Console.WriteLine(getRandomNumber2());

            Console.ReadLine();
        }

        static int Topla(int sayi1,int sayi2)
        {
            return sayi1 + sayi2;
        }

        private static void ActionDemo()
        {
            HandleException(() =>
            {
                Find();
                Find2();
            });
        }

        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void Find()
        {
            List<string> students = new List<string> { "Oğuz", "Harun", "Kerem" };

            if (!students.Contains("Ahmet"))
            {
                Console.WriteLine("Record Not Found!");
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }

        private static void Find2()
        {
            List<string> students = new List<string> { "Oğuz", "Harun", "Kerem" };

            if (!students.Contains("Oğuz"))
            {
                Console.WriteLine("Record Not Found!");
            }
            else
            {
                Console.WriteLine("Record Found!");
            }
        }
    }
}