using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassDel
{
    public sealed class OneDimensionalArray<T> : HeirArray<T>, IPrinter where T : IComparable<T>
    {
        private T[] arr; //массив
        int index; // реальный размер массива
        const int default_capacity = 10;//емкость по умолчанию

        public OneDimensionalArray(int size = default_capacity) : base(size)
        {
        }

        protected override void Input(int size) // создание массива
        {
            if (size < 0)
            {
                Console.WriteLine("Размер массива не может быть отрицательным, устанавливаем размер по уиолчанию");
                size = default_capacity;
            }
            arr = new T[size];
            index = 0;
        }

        public void Add(T obj) // добавление элемента в массив
        {
            if (index >= arr.Length)
            {
                Console.WriteLine("Массив заполнен, увеличиваем емкость");
                Array.Resize(ref arr, index*2 + 1);
            }
            arr[index++] = obj;
        }

        public override void Print() // вывод массива в строку
        {
            if (index == 0)
            {
                Console.WriteLine("Массив пустой");
                return;
            }
            for (int i = 0; i < index; i++)
            {
                Console.Write($"{arr[i]}\t");
            } 
            Console.WriteLine();
        }

        public void Remove(int num) // удаление элемента из массива
        {
            if (num >= index || num < 0)
            {
                Console.WriteLine("Индекс элемента вне размеров массива, удаление невозможно");
                return;
            }
            for (int i = num; i < index - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            index--;
        }

        public void Reverse() // переворот массива
        {
            T temp;
            for (int i = 0; i < index / 2; i++)
            {
                temp = arr[i];
                arr[i] = arr[index - 1 - i];
                arr[index - 1 - i] = temp;
            }
        }

        public void Sort() // сортировка массива
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

        public T Min() // получение минимального элемента массива
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

        public T Max() // получение максимального элемента массива
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

        public void ForEachAction(Action<T> action) // выполнение метода для всех элементов 
        {
            for (int i = 0; i < index; i++)
            {
                action(arr[i]);
            }
        }

        public int CountCondition(Func<T, bool> condition) // подсчет кол-ва элементов в массиве, удовлетворяющих переданному условию
        {
            int count = 0;
            for (int i = 0; i < index; ++i)
            {
                if (condition(arr[i]))
                {
                    count++;
                }
            }
            return count;
        }

        public int Count()  // подсчет количества элементов в массиве
        {
            return index;
        }

        public bool AtLeastForOne(Func<T, bool> condition) // проверка переданного условия хотя бы для одного элемента массива
        {
            bool fl = false;
            this.ForEachAction((x) =>
            {
                if (condition(x))
                {
                    fl = true;
                }
            });
            return fl;
        }

        public bool ForEveryone(Func<T, bool> condition) // проверка переданного условия для всех элементов массива
        {
            int count = 0;
            this.ForEachAction((x) =>
            {
                if (condition(x))
                {
                    count++;
                }
            });
            if (count == index)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Find(T item) // проверка наличия элемента в массиве
        {
            bool fl = false;
            for (int i = 0; i < index; i++)
            {
                int compare = item.CompareTo(arr[i]);
                if (compare == 0)
                {
                    fl = true;
                    break;
                }
            }
            return fl;
        }

        public T FirstSatisfyCondition(Func<T, bool> condition) // получение первого элемента в массиве, удовлетворяющего условию
        {
            for (int i = 0; i < index; ++i)
            {
                if (condition(arr[i]))
                {
                    return arr[i];
                }
            }
            Console.WriteLine("Элемент не найден, значение по умолчанию");
            return default(T);
        }

        public T[] ArrayWithCondition(Func<T, bool> condition) // получение элементов массива, удовлетворяющих переданному условию
        {
            T[] arr_cond = new T[index];
            int count = 0;
            for (int i = 0; i < arr_cond.Length; i++)
            {
                if (condition(arr[i]))
                {
                    arr_cond[count++] = arr[i];
                }
            }
            if (count == 0) 
            {
                Console.WriteLine("Элементы массива, удовлетворяющие условию не найдены");
            }
            Array.Resize(ref arr_cond, count);
            return arr_cond;
        }

        public T[] AllElements() //получение элементов массива выбранного типа
        {
            T[] arr_ = new T[index];
            for (int i = 0; i < arr_.Length; i++)
            {
                arr_[i] = arr[i];
            }
            return arr_;
        }

        public T[] ArrayWithPosNum(int position, int num) // получить заданное количество элементов массива с указанного индекса
        {
            T[] arr_cond = new T[index];
            int count = 0;
            try
            {
                if (position < 0 || num < 0)
                {
                    throw new Exception("Недопустимые отрицательные значения");
                }
                if ((position + num) > index)
                {
                    throw new Exception("Выход за границы массива");
                }
                for (int i = position; i < position + num; i++)
                {
                    arr_cond[count++] = arr[i];
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
            Array.Resize(ref arr_cond, count);
            return arr_cond;
        }

        public void UsingForeach() // итерирование с помощью цикла foreach
        {
            T[] arr_ = new T[index];
            Array.Copy(arr,arr_,index);
            foreach(T item in arr_)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
        }

        public string[] ProjectionToString() // проекция элементов массива в тип string
        {
            string[] arr_str = new string[index];
            for (int i = 0; i < index; i++)
            {
                arr_str[i] = Convert.ToString(arr[i]);
            }
            return arr_str;
        }

        public int[] ProjectionToInt() // проекция элементов массива в тип int
        {
            try
            {
                int[] arr_int = new int[index];
                for (int i = 0; i < index; i++)
                {
                    arr_int[i] = Convert.ToInt32(arr[i]);
                }
                return arr_int;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                Console.WriteLine("Проекция элементов массива в тип int невозможна");
                int[] arr_int = new int[0];
                return arr_int;
            }
        }

        public TResult MinProjection<TResult>(Func<T, TResult> projection) // получение минимального элемента массива по его проекции
        {
            Comparer<TResult> comparer = Comparer<TResult>.Default;
            TResult min = projection(arr[0]);
            Console.WriteLine("Проекция элементов");
            Console.Write($"{min:f3}\t");
            for (int i = 1; i < index; i++)
            {
                var curr_el = projection(arr[i]);
                Console.Write($"{curr_el:f3}\t");
                if (comparer.Compare(min,curr_el) > 0)
                {
                    min = curr_el;
                }
            }
            Console.WriteLine();
            return min;
        }

        public TResult MaxProjection<TResult>(Func<T, TResult> projection) // получение максимального элемента массива по его проекции
        {
            Comparer<TResult> comparer = Comparer<TResult>.Default;
            TResult max = projection(arr[0]);
            Console.WriteLine("Проекция элементов");
            Console.Write($"{max:f3}\t");
            for (int i = 1; i < index; i++)
            {
                var curr_el = projection(arr[i]);
                Console.Write($"{curr_el:f3}\t");
                if (comparer.Compare(max, curr_el) < 0)
                {
                    max = curr_el;
                }
            }
            Console.WriteLine();
            return max;
        }

    }
    public delegate void Action<T>(T action);
}
