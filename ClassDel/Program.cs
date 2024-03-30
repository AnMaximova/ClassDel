﻿using System;
using System.Collections;
using ClassDel;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        // Все методы кроме получения максимального и минимального элемента массива по его проекции реализованы и проверены.
        // В Main - только то, что в задании 4-1.
        OneDimensionalArray<string> test_str = new OneDimensionalArray<string>(7);
        test_str.Add("one");
        test_str.Add("two");
        test_str.Add("three");
        test_str.Add("four");
        test_str.Add("five");
        test_str.Add("six");
        test_str.Add("seven");
        test_str.Add("eight");
        test_str.Print();
        test_str.Sort();
        test_str.Print();
        Console.WriteLine($"Минимальный элемент массива равен: {test_str.Min()}");
        Console.WriteLine($"Максимальный элемент массива равен: {test_str.Max()}");
        OneDimensionalArray<int> test_int = new OneDimensionalArray<int>(10);
        for(int i =  0; i < 10; i++)
        {
            Random rnd = new Random();
            test_int.Add(rnd.Next(-10,11));
        }
        test_int.Print();
        test_int.Sort();
        test_int.Print();
        Console.WriteLine($"Минимальный элемент массива равен: {test_int.Min()}");
        Console.WriteLine($"Максимальный элемент массива равен: {test_int.Max()}");
    }
}