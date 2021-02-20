using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueuesWithYieldReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a thread safe queue
            var queue = new ThreadSafeQueue<ulong>();
            //starting filling the queue in another thread
            ThreadPool.QueueUserWorkItem(AddItemsToQueue, queue);
            //start processing elements from the queue as they arrive
            foreach (var each in ProcessItemsInQueue(queue))
            {
                Console.WriteLine(each);
            }

        }

        private static void AddItemsToQueue(Object state)
        {
            var queue = (ThreadSafeQueue<ulong>)state;
            var random = new Random();
            ulong count = 0;
            while (true)
            {
                queue.Enqueue(count++);
                Thread.Sleep(random.Next(100, 1000));
            }
        }

        private static IEnumerable<ulong> ProcessItemsInQueue(Object state)
        {
            var queue = (ThreadSafeQueue<ulong>)state;
            while (true)
            {
                if (queue.Count == 0)
                    Thread.Sleep(3000);
                yield return queue.Dequeue();
            }
        }
    }
}
