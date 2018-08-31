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
            Console.WriteLine($"Максимальное значение суммы числел, взятых по одному из каждой тройки: {result}");
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
