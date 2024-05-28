using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArrayExample
{
    public class MyArray
    {
        public int[] Array { get; }

        public MyArray(int size)
        {
           Array = Enumerable.Range(0, size).ToArray();
        }

        public bool Replace(int position, int newValue)
        {
            if(position < 0)
            {
                throw new ArgumentException("Position must not be less than zero");
            }

            if(position >= Array.Length) 
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position must be valid");
            }

            Array[position] = newValue;
            return true;
        }

        public int FindMax()
        {
            if (Array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty");
            }

            return Array.Max();
        }
    }
}
