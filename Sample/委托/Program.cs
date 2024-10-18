
using System.Reflection;

namespace 委托
{
    internal class Program
    {
        public delegate void MathOperation(int x, int y);
        public static void 加(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public static void 减(int a, int b)
        {
            Console.WriteLine(a - b);
        }
        public static void PerformOperation(MathOperation operation,int x,int y)
        {
            operation(x, y);
        }
        static void Main(string[] args)
        {
            MathOperation mathOperation = null;
            mathOperation += 加;
            mathOperation += 减;
            mathOperation(1, 2);

            PerformOperation(加, 3, 3);

            事件 e=new 事件();
            e.ProcessCompleted += E_ProcessCompleted;
            e.StartProcess();

            Console.ReadLine();
        }

        private static void E_ProcessCompleted()
        {
            Console.WriteLine("Event Notify!");
        }
    }
}
