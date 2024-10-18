
namespace Two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Parallel.Foreach

            //List<int> values=new List<int>();
            //for (int i = 0; i < 100; i++)
            //{
            //    values.Add(i);
            //}

            ////使用foreach处理
            //var time=DateTime.Now;
            //foreach (int i in values)
            //{
            //    Thread.Sleep(10);
            //}
            //var spend=DateTime.Now-time;
            //Console.WriteLine($"Foreach用时：{spend.TotalSeconds}s");

            ////使用Parallel.Foreach
            //var time1 = DateTime.Now;
            //Parallel.ForEach(values, (i) =>
            //{
            //    Thread.Sleep(10);
            //});
            //var spend2 = DateTime.Now - time1;
            //Console.WriteLine($"Parallel.Foreach用时：{spend2.TotalSeconds}s");

            #endregion

            #region ThreadPool

            //List<int> list = new List<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(i);
            //}

            //foreach (int i in list)
            //{
            //    ThreadPool.QueueUserWorkItem(DoWork, i);
            //}

            //Console.WriteLine("全部任务加入线程池");

            #endregion


            Console.Read();
        }

        private static void DoWork(object? state)
        {
            var i = (int)state;
            Thread.Sleep(new Random().Next(10000));
            Console.WriteLine("处理完：" + i);
        }
    }
}
