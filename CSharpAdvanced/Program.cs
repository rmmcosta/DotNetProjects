using System;
using System.Collections.Generic;

namespace CSharpAdvanced
{
    class MyCollection<T>
    {
        private T[] myArray;

        public MyCollection(int size)
        {
            this.myArray = new T[size];
        }
        public T this[int index]
        {
            set
            {
                myArray[index] = value;
            }
            get
            {
                return myArray[index];
            }
        }

        public int size()
        {
            return myArray.Length;
        }
    }

    class Car
    {
        private string color, model;

        public Car(string color, string model)
        {
            this.color = color;
            this.model = model;
        }

        public string Color { get => color; }
        public string Model { get => model; }

        public override string ToString()
        {
            return $"Model: {model} with Color: {color}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyCollection<int> ints = new MyCollection<int>(5);
            for (int i = 0; i < ints.size(); i++)
            {
                ints[i] = i * 10;
            }
            for (int i = 0; i < ints.size(); i++)
            {
                Console.WriteLine(ints[i]);
            }
            MyCollection<string> strings = new MyCollection<string>(5);
            for (int i = 0; i < strings.size(); i++)
            {
                strings[i] = "coiso " + i;
            }
            for (int i = 0; i < strings.size(); i++)
            {
                Console.WriteLine(strings[i]);
            }
            MyCollection<Car> cars = new MyCollection<Car>(5);
            for (int i = 0; i < cars.size(); i++)
            {
                cars[i] = new Car("color " + i, "model " + i);
            }
            for (int i = 0; i < cars.size(); i++)
            {
                Console.WriteLine(cars[i]);
            }
        }
    }
}
