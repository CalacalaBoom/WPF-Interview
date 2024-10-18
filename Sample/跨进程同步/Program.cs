namespace 跨进程同步
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                using (Mutex mutex = new Mutex(false, "MyMutex"))
                {
                    Console.WriteLine("进程2:" + DateTime.Now.ToString());
                }

                Thread.Sleep(1000);
            }

        }
    }
}
