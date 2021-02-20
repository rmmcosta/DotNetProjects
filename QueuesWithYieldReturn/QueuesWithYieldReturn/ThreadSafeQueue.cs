using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueuesWithYieldReturn
{
    public class ThreadSafeQueue<T>
    {
        private Queue<T> queue = new Queue<T>();
        public int Count
        {
            get
            {
                lock (queue)
                {
                    return queue.Count;
                }
            }
        }
        public void Enqueue(T value)
        {
            lock (queue)
            {
                queue.Enqueue(value);
            }
        }
        public T Dequeue()
        {
            lock (queue)
            {
                return queue.Dequeue();
            }
        }
        public T Peek()
        {
            lock (queue)
            {
                return queue.Peek();
            }
        }
    }
}
