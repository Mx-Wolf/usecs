using System;
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
                result += MaxOfTriplet();
            }
            Console.WriteLine($"Максимальное значение суммы чисел, взятых по одному из каждой тройки: {result}");
            Console.WriteLine($"Результат делится на три: {(result%3==0?"Да":"Нет")}");
        }

        private static int MaxOfTriplet()
        {
            var line = ReadNextNonEmptyLine();
            return line.Split(' ').Select(int.Parse).Max();
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
