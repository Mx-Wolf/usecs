using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace _2018_10_01_b
{
    internal static class Program
    {
        private static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            var n = ReadTripletCount();
            var result = 0;
            var diff = 0;
            while (0<n--)
            {
                var triplet = GetTripletOrdered();
                result += triplet[2];
                diff = Reduce(diff, triplet[2]-triplet[1], triplet[2]-triplet[0]);
            }
            Debug.WriteLine($"Максимальное значение суммы чисел, взятых по одному из каждой тройки: {result}");
            Debug.WriteLine($"Результат делится на три: {(result%3==0?"Да":"Нет")}");
            if (result % 3 == 0)
            {
                if (diff > 0)
                {
                    result -= diff;
                    Debug.WriteLine($"Максимальное значение суммы чисел, взятых по одному из каждой тройки, с условием, что результат не делится на три: {result}");
                    Console.WriteLine(result);
                }
                else
                {
                    Debug.WriteLine("Получить значение ");
                    Console.WriteLine(0);
                }
            }
            else
            {
                Console.WriteLine(result);
            }
        }

        private static int Reduce(int diff, int d2, int d1)
        {
            if (d2 % 3 != 0)
            {
                return MinOrInitalize(diff, d2);
            }

            if (d1 % 3 != 0)
            {
                return MinOrInitalize(diff, d1);
            }

            return diff;
        }

        private static int MinOrInitalize(int diff, int delta)
        {
            return diff <= 0 ? delta : Math.Min(diff, delta);
        }


        private static int[] GetTripletOrdered()
        {
            var line = ReadNextNonEmptyLine();
            return line.Split(' ').Select(int.Parse).OrderBy(a => a).ToArray();
        }

        private static int ReadTripletCount()
        {
            var line = ReadNextNonEmptyLine();
            return int.Parse(line);
        }

        private static string ReadNextNonEmptyLine()
        {
            var line = Console.ReadLine();
            return line ?? throw new InvalidOperationException();
        }
    }
}
