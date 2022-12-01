namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, LastName = "ER", Age = 28 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            Console.ReadLine();
        }
    }

    [ToTable("Customers")]
    [ToTable("TblCustomers")]
    class Customer
    {
        [RequiredProperty]
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }

    class CustomerDal
    {
        [Obsolete("Don't use Add, instead use AddNew Method")]
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }

        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!",
                customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }


    // [AttributeUsage(AttributeTargets.All)]  --> Bu attribute her şey için kullanılabilir.
    // [AttributeUsage(AttributeTargets.Class)] --> Bu attribute sadece classlar için kullanılabilir.
    // [AttributeUsage(AttributeTargets.Property)] --> Bu attribute sadece propertyler için kullanılabilir.
    // [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)] --> bu şekilde iki farklı şey eklenebilir.
    // AllowMultiple = true/false --> bir şeye birden fazla kez kullanılabilmesi için.

    [AttributeUsage(AttributeTargets.Property)]
    class RequiredPropertyAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class ToTableAttribute : Attribute
    {
        private string _tableName;

        public ToTableAttribute(string tableName)
        {
            _tableName = tableName;
        }
    }

}