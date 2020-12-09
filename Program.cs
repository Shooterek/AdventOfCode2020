using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = new Day9("./Input/day9.txt");
            var result = day.FirstTask();
            Console.WriteLine(result);

            var result2 = day.SecondTask();
            Console.WriteLine(result2);
        }
    }
}
