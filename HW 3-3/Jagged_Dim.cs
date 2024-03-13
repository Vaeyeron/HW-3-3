using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_3
{
    sealed class Jagged_Dim : Array_Base
    {
        private int[][] _jagged_Array;
        public Jagged_Dim(int length, bool user_Input = false)
        {
            Initialize(length, user_Input);
        }

        public override void Initialize(int length, bool user_Input = false)
        {
            _jagged_Array = new int[length][];
            if (user_Input)
            {
                Fill_Array_With_User_Values();
            }
            else
            {
                Fill_Array_With_Random_Values();
            }
        }
        public override void Fill_Array_With_User_Values()
        {
            Console.WriteLine("Enter values for the jagged array:");
            for (int i = 0; i < _jagged_Array.Length; i++)
            {
                Console.Write($"Enter the number of elements in array {i}: ");
                int length;
                if (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    i--;
                    continue;
                }
                _jagged_Array[i] = new int[length];
                for (int j = 0; j < length; j++)
                {
                    Console.Write($"Enter value for index {j}: ");
                    if (!int.TryParse(Console.ReadLine(), out _jagged_Array[i][j]))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer value.");
                        j--;
                    }
                }
            }
        }

        public override void Fill_Array_With_Random_Values()
        {
            Random random = new Random();
            for (int i = 0; i < _jagged_Array.Length; i++)
            {
                _jagged_Array[i] = new int[random.Next(1, 6)];
                for (int j = 0; j < _jagged_Array[i].Length; j++)
                {
                    _jagged_Array[i][j] = random.Next(-100, 101);
                }
            }
        }

        public override void Print()
        {
            Console.WriteLine("Jagged Array:");
            for (int i = 0; i < _jagged_Array.Length; i++)
            {
                Console.Write("Array " + i + ": ");
                for (int j = 0; j < _jagged_Array[i].Length; j++)
                {
                    Console.Write(_jagged_Array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public override double Calculate_Average()
        {
            double sum = 0;
            int count = 0;
            foreach (int[] array in _jagged_Array)
            {
                foreach (int element in array)
                {
                    sum += element;
                }
                count += array.Length;
            }
            return count == 0 ? 0 : sum / count;
        }

        public void Calculate_Nested_Averages()
        {
            Console.WriteLine("Average values in nested arrays:");
            for (int i = 0; i < _jagged_Array.Length; i++)
            {
                double sum = 0;
                foreach (var element in _jagged_Array[i])
                {
                    sum += element;
                }
                double average = _jagged_Array[i].Length == 0 ? 0 : sum / _jagged_Array[i].Length;
                Console.WriteLine($"Array {i}: {average}");
            }
        }
        public void Modify_Even_Elements()
        {
            for (int i = 0; i < _jagged_Array.Length; i++)
            {
                for (int j = 0; j < _jagged_Array[i].Length; j++)
                {
                    if (_jagged_Array[i][j] % 2 == 0)
                    {
                        _jagged_Array[i][j] = i * j;
                    }
                }
            }
        }
    }
}
