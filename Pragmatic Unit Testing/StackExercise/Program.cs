using System;
using System.Collections.Generic;

namespace StackExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface StackExercise<T>
    {
        public T Pop();

        public void Push(T t);

        public bool IsEmpty();
    }

    public class MyStack<T> : StackExercise<T>
    {
        LinkedList<T> list;

        public MyStack()
        {
            list = new LinkedList<T>();
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public T Pop()
        {
            if (list.Count == 0)
                return default(T);
            return list.Last.Value;
        }

        public void Push(T t)
        {
            list.AddLast(t);
        }
    }
}
