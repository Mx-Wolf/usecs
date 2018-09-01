using System;
using System.Collections.Generic;
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
            while (0<n--)
            {
                var triplet = GetTriplet().OrderBy(a=>a).ToArray();
                result += triplet[2];
            }
            Console.WriteLine($"Максимальное значение суммы чисел, взятых по одному из каждой тройки: {result}");
            Console.WriteLine($"Результат делится на три: {(result%3==0?"Да":"Нет")}");
        }

        private static IEnumerable<int> GetTriplet()
        {
            var line = ReadNextNonEmptyLine();
            var triplet = line.Split(' ').Select(int.Parse);
            return triplet;
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
