using System;

namespace ArrayMaxValue
{
    public class MaxValue
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int getMaxValaue(int[] values)
        {
            int max = Int32.MinValue;
            foreach (int value in values)
                if (value > max)
                    max = value;
            return max;
        }
    }
}
