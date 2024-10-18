using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多线程同步
{
    public class Synchronization
    {
        private readonly object _lockObject = new object();
        private readonly Semaphore semaphore = new Semaphore(3, 3);

        int i = 0;
        public void ThreadSafeMethod()
        {
            lock (_lockObject)
            {
                i++;
                Console.WriteLine(i);
            }
        }

        public void ThreadSafeMethod1()
        {
            Monitor.Enter(_lockObject);
            try
            {
                i++;
                Console.WriteLine(i);
            }
            finally { Monitor.Exit(_lockObject); }
        }

        public async void ThreadSafeMethod2(int id)
        {
            semaphore.WaitOne();
            try
            {
                Console.WriteLine($"{id}访问");
                await Task.Delay(2000);
            }
            finally { semaphore.Release(); }
        }

        ReaderWriterLockSlim readerWriter = new ReaderWriterLockSlim();
        int temp = 0;
        public void ReadMethod()
        {
            readerWriter.EnterReadLock();
            try
            {
                Console.WriteLine(temp);
            }
            finally { readerWriter.ExitReadLock(); }
        }

        public void WriteMethod()
        {
            readerWriter.EnterWriteLock();
            try
            {
                temp=new Random().Next();
            }
            finally { readerWriter.ExitWriteLock(); }
        }
    }
}
