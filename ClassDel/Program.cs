using System;
using ClassDel;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Ввод одномерного массива целых");
        Access<int> item1 = new ProcessingInt();
        OneDimensionalArray<int> test1 = new OneDimensionalArray<int>(item1);
        test1.Print();
        test1.Put(75);
        test1.Put(-75);
        test1.Print();
        test1.Sort();
        test1.Print();
        Console.WriteLine($"Минимальный элемент массива равен: {test1.Min()}");
        Console.WriteLine($"Максимальный элемент массива равен: {test1.Max()}");
        Console.WriteLine("Ввод одномерного массива строк ");
        Access<string> item2 = new ProcessingString();
        OneDimensionalArray<string> test2 = new OneDimensionalArray<string>(item2,true);
        test2.Print();
        test2.Put("75");
        test2.Put("-75");
        test2.Print();
        test2.Sort();
        test2.Print();
        Console.WriteLine($"Минимальный элемент массива равен: {test2.Min()}");
        Console.WriteLine($"Максимальный элемент массива равен: {test2.Max()}");
        
    }
}