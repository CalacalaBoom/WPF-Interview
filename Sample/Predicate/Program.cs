namespace Predicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Predicate<int> isEven = n => n % 2 == 0;

            List<int> evenNumbers=list.FindAll(isEven);

            Console.WriteLine("Even Number:");
            foreach (var item in evenNumbers)
            {
                Console.Write(item+" ");
            }

            Console.ReadLine();
        }
    }
}
