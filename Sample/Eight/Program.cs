namespace Eight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog=new Dog();

            Console.WriteLine($"Name is {dog.Name}");
            dog.Speak();
            dog.Eat();
            dog.Run();
            Console.ReadLine();
        }
    }
}
