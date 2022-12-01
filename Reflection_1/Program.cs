using System.Reflection;

namespace Reflection_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //foreach (var item in assembly.GetTypes())
            //{
            //    Console.WriteLine($"{item.Namespace}.{item.Name}");
            //    foreach (var property in item.GetProperties())
            //    {
            //        Console.WriteLine($"{property.PropertyType}.{property.Name}");
            //    }
            //    Console.WriteLine("---");
            //}



            User user = new User();
            var type = user.GetType();
            foreach (var property in type.GetProperties())
            {
                Console.WriteLine($"{property.PropertyType}.{property.Name}");
            }

            Console.ReadLine();
        }
    }

    class Product
    {
        public string Name { get; set; }
    }

    class User
    {
        public string FullName { get; set; }
        public int Password { get; set; }
    }
}