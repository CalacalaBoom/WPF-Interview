namespace 特性
{
    internal class Program
    {
        static void Main(string[] args)
        {
            特性Service service = new 特性Service();
            Type type = typeof(特性Service);

            var acctributes = type.GetCustomAttributes(typeof(MyCustomAttribute),false);

            foreach (MyCustomAttribute acct in acctributes)
            {
                Console.WriteLine($"Class Attribute:{acct.Description}");
            }

            var method = type.GetMethod("SampleMethod");
            var methodAttributes = method.GetCustomAttributes(typeof(MyCustomAttribute), false);
            foreach (MyCustomAttribute attr in methodAttributes)
            {
                Console.WriteLine($"Method Attribute:{attr.Description}");
            }

            Console.ReadLine();
        }
    }
}
