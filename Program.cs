using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = new Day1("./Input/day1.txt");
            var result = day.FirstTask();

            
            var result2 = day.SecondTask();
            Console.WriteLine(result);
            Console.WriteLine(result2);
        }
    }
}
