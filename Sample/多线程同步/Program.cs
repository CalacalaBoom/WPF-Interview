
namespace 多线程同步
{
    internal class Program
    {
        public static Synchronization synchronization { get; set; }
        static void Main(string[] args)
        {
            synchronization = new Synchronization();

            #region 跨进程同步

            //while (true)
            //{
            //    using (Mutex mutex = new Mutex(false, "MyMutex"))
            //    {
            //        Console.WriteLine("进程2:"+DateTime.Now.ToString());
            //    }

            //    Thread.Sleep(500);
            //}

            #endregion

            #region Semaphore
            //for (int i = 0; i < 100; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(DoWork, i);
            //}
            #endregion

            #region ReaderWriterLockSlim
            Task.Run(async () =>
            {
                while (true)
                {
                    synchronization.WriteMethod();
                    await Task.Delay(500);
                }
            });

            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(async s =>
                {
                    while (true)
                    {
                        synchronization.ReadMethod();
                        await Task.Delay(1000);
                    }
                }, null);
            }
            #endregion


            Console.ReadLine();
        }

        private static void DoWork(object? state)
        {
            int i = (int)state;

            synchronization.ThreadSafeMethod2(i);
        }
    }
}
