namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product harddisk = new Product(50);
            harddisk.ProductName = "Hard Disk";

            Product mobilphone = new Product(50);
            mobilphone.ProductName = "Mobile Phone";
            mobilphone.StockControlEvent += Mobilphone_StockControlEvent;

            for (int i = 0; i < 10; i++)
            {
                harddisk.Sell(10);
                mobilphone.Sell(10);
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        private static void Mobilphone_StockControlEvent()
        {
            Console.WriteLine("Mobil Phone about to finish!!!");
        }
    }
}