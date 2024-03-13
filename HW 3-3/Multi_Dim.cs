using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_3
{
    sealed class Multi_Dim : Array_Base
    {
        private int[,] _array;
        public Multi_Dim(int rows, int columns, bool user_Input = false)
        {
            Initialize(rows, columns, user_Input);

        }

        public override void Initialize(int rows, int columns, bool user_Input = false)
        {
            _array = new int[rows, columns];
            if (user_Input == true)
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
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    Console.Write($"Enter value for index [{i},{j}]: ");
                    if (!int.TryParse(Console.ReadLine(), out _array[i, j]))
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
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    _array[i, j] = random.Next(-100, 101);
                }
            }
        }


        public override void Print()
        {
            Console.WriteLine("Array elements:");
            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    Console.Write(_array[i, j] + " ");
                }
                Console.WriteLine();
            }
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
        public void Reverse_Even_Rows()
        {
            for (int i = 1; i < _array.GetLength(0); i += 2)
            {
                for (int j = 0; j < _array.GetLength(1) / 2; j++)
                {
                    int temp = _array[i, j];
                    _array[i, j] = _array[i, _array.GetLength(1) - 1 - j];
                    _array[i, _array.GetLength(1) - 1 - j] = temp;
                }
            }
            Console.WriteLine("Reversed array:");
            Print();
        }
    }
}
