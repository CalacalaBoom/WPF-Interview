using System.Collections.Concurrent;
using System.Threading.Channels;

namespace One
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 共享变量
            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        ShareValue.UpdateValue();
            //        await Task.Delay(1000);
            //        Console.WriteLine($"Task 1 run:{ShareValue._shareValue}");
            //    }
            //});

            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        ShareValue.UpdateValue();
            //        await Task.Delay(2000);
            //        Console.WriteLine($"Task 2 run:{ShareValue._shareValue}");
            //    }
            //});

            //Console.ReadLine();
            #endregion

            #region BlockingCollection<T>
            //BlockingCollection<int> queue = new BlockingCollection<int>();

            //Task.Run(async () =>
            //{
            //    int i = 0;
            //    while (true)
            //    {
            //        queue.Add(i);
            //        i++;
            //        Console.WriteLine($"Task 1 生产 {i}");
            //        await Task.Delay(500);
            //    }
            //});

            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        var value = queue.Take();

            //        Console.WriteLine($"Task 2 消费 ：{value}");


            //        string values = "队列还剩：";
            //        foreach ( var item in queue)
            //        {
            //            values += " " + item;
            //        }
            //        Console.WriteLine(values);

            //        await Task.Delay(new Random().Next(2000));
            //    }
            //});

            #endregion

            #region Channel<T>

            //Channel<int> channel = Channel.CreateBounded<int>(new BoundedChannelOptions(2)
            //{
            //    FullMode = BoundedChannelFullMode.Wait
            //});

            //Task.Run(async () =>
            //{
            //    int i = 0;
            //    while (true)
            //    {
            //        await channel.Writer.WriteAsync(i);
            //        i++;
            //        Console.WriteLine($"Task 1 生产 : {i}");
            //        await Task.Delay(500);
            //    }
            //});

            //Task.Run(async () =>
            //{
            //    while (true)
            //    {
            //        while (await channel.Reader.WaitToReadAsync())
            //        {
            //            channel.Reader.TryRead(out int value);
            //            Console.WriteLine($"Task 2 消费 ：{value}");
            //        }

            //        await Task.Delay(new Random().Next(2000));
            //    }
            //});

            #endregion

            #region 事件

            //Publisher publisher = new Publisher();
            //Subscriber subscriber = new Subscriber();

            //Task.Run(async () => 
            //{
            //    int i = 0;
            //    while (true) 
            //    {
            //        Console.WriteLine($"Task 1 说 : {i}");
            //        publisher.SendMessage(i.ToString());
            //        i++;
            //        await Task.Delay(1000);
            //    }
            //});

            //Task.Run(() => 
            //{
            //    subscriber.Subscribe(publisher);
            //});

            #endregion

            Console.ReadLine();
        }
    }
}
