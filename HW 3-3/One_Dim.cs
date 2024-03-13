using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_3
{
    sealed class One_Dim : Array_Base
    {
        private int[] _array;
        public One_Dim(int length, bool user_Input = false)
        {
            Initialize(length, user_Input);
        }
        public override void Initialize(int length, bool user_Input = false)
        {
            _array = new int[length];
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
            Console.WriteLine("Enter values for the array:");
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write($"Enter value for index {i}: ");
                if (!int.TryParse(Console.ReadLine(), out _array[i]))
                {
                    Console.WriteLine("Invalid input. Please enter an integer value.");
                    i--;
                }
            }
        }

        public override void Fill_Array_With_Random_Values()
        {
            Random random = new Random();
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = random.Next(-200, 201);
            }
        }
        public override void Print()
        {
            Console.WriteLine("Array elements:");
            foreach (var element in _array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
        public override double Calculate_Average()
        {
            double sum = 0;
            foreach (var element in _array)
            {
                sum += element;
            }
            return sum / _array.Length;
        }
        public void Remove_Elements_More_Than_Abs_100(int length)
        {
            Console.WriteLine("Array after removing elements with abs more than 100");
            List<int> Array_Less_than_100 = new List<int>();
            foreach (int element in _array)
            {
                if (Math.Abs(element) <= 100)
                {
                    Array_Less_than_100.Add(element);
                }
            }
            _array = Array_Less_than_100.ToArray();
            Print();
        }
        public void Remove_Duplicate_Elements()
        {
            Console.WriteLine("Array after removing duplicated elements");
            List<int> No_Duplicates = new List<int>();
            Array.Sort(_array);

            for (int i = 0; i < _array.Length; i++)
            {
                if (i - 1 > -1 | i + 1 < _array.Length)
                {
                    if (_array[i] != _array[i + 1] & _array[i] != _array[i - 1])
                    {
                        No_Duplicates.Add(_array[i]);
                    }
                }
            }
            _array = No_Duplicates.ToArray();
            Print();
        }
    }
}
