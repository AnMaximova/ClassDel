using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassDel
{
    public sealed class OneDimensionalArray<T> : HeirArray<T>, IPrinter where T : IComparable<T>
    {
        private T[] arr; //массив
        int index; // реальный размер массива
        int n = 10;//емкость по умолчанию
        Access<T> access;

        public OneDimensionalArray(Access<T> item, bool input_mode = false) : base(item, input_mode)
        {
        }


        private int VerifiedInput() //ввод размера массива
        {
            int n;
            bool success;
            do
            {
                Console.Write("Введите размер массива: ");
                success = int.TryParse(Console.ReadLine(), out n);
            }
            while (!success || n <= 0);
            index = n;
            return n;
        }
        protected override void InputUser(Access<T> item)
        {
            access = item;
            arr = new T[VerifiedInput()];
            Type type_arr = typeof(T);
            Console.WriteLine($"Создаем массив типа {type_arr}");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Введите {i} элемент массива: ");
                arr[i] = access.Input_Value();
            }
        }
        protected override void InputRandom(Access<T> item)
        {
            Random rnd = new Random();
            access = item;
            arr = new T[n];
            index = n; 
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = access.Random_Value();
            }
        }

        public override void Print() // вывод массива в строку
        {
            Type type_arr = typeof(T);
            Console.WriteLine($"Выводим массив типа {type_arr}");
            for(int i = 0; i < index;i++)
            {
                string str = access.ValueToString(arr[i]);
                Console.Write(str + "\t");
            }
            Console.WriteLine();
        }

        public void Put(T obj)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine("Массив заполнен, увеличиваем емкость");
                Array.Resize(ref arr, (index*2 + 1));
            }
            arr[index++] = obj;
        }

        public void Sort() 
        {
            T temp;
            for (int i = 0; i < index; i++)
            {
                for (int j = i + 1; j < index; j++)
                {
                    int compare = arr[i].CompareTo(arr[j]);
                    if (compare > 0)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public T Min()
        {
            T min = arr[0];
            for (int i = 1; i < index; i++)
            {
                int compare = min.CompareTo(arr[i]);
                if (compare > 0) 
                {
                    min = arr[i];
                }
            }
            return min;
        }

        public T Max()
        {
            T max = arr[0];
            for (int i = 1; i < index; i++)
            {
                int compare = max.CompareTo(arr[i]);
                if (compare < 0)
                {
                    max = arr[i];
                }
            }
            return max;
        }
    }
}
