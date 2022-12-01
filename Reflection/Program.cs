using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2, 3);
            //var sonuc1 = dortIslem.Topla2();
            //var sonuc2 = dortIslem.Topla(3, 4);
            //Console.WriteLine(sonuc1);
            //Console.WriteLine(sonuc2);

            var tip = typeof(DortIslem);

            //DortIslem? dortIslem = Activator.CreateInstance(tip,6,7) as DortIslem;
            //Console.WriteLine(dortIslem?.Topla(4, 5));
            //Console.WriteLine(dortIslem?.Topla2());

            var instance = Activator.CreateInstance(tip, 6, 7);

            MethodInfo? methodInfo = instance?.GetType().GetMethod("Topla2");
            Console.WriteLine(methodInfo?.Invoke(instance, null));

            Console.WriteLine("--------------");

            var metodlar = tip.GetMethods();

            foreach (var info in metodlar)
            {
                Console.WriteLine("Method adı : {0}",info.Name);
                foreach (var parameterInfo in info.GetParameters())
                {
                    Console.WriteLine(" - Parametre : {0}",parameterInfo.Name);
                }

                foreach (var attribute in info.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Name : {0}",attribute.GetType().Name);
                }
            }

            
            

            Console.ReadLine();
        }
    }

    public class DortIslem
    {
        readonly int _sayi1;
        readonly int _sayi2;

        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public DortIslem()
        {

        }

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }

        [MethodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
    }

    public class MethodNameAttribute : Attribute
    {
        public MethodNameAttribute(string name)
        {

        }

    }
}