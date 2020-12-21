using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        public static List<long> ReadFileByLine()
        {
            var numbers = new List<long>();
            try
            {
                using (var file = new StreamReader("input.txt"))
                {
                    long number;
                    string line;
                    while((line = file.ReadLine()) != null)  
                    {
                        bool isParsable = Int64.TryParse(line, out number);
                        if (isParsable)
                        {
                            numbers.Add(number);
                        }
                    } 
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to read file " + e);
            }


            return numbers; 
        }

        public static (long number1, long number2) ComputeSumsUptoNumber(List<long> numbers)
        {
            long complementNumber = 0;
            foreach (var number in numbers)
            {
                complementNumber = numbers.Find(complementNumber => complementNumber + number == 2020);
                if (complementNumber != 0)
                {
                    return (number, complementNumber);
                } 
            }

            return (0, 0);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Advent Day1 Part 1");
            var numbers = ReadFileByLine();
            Console.WriteLine("File with {0} lines read", numbers.Count);
            (long number1, long number2) = ComputeSumsUptoNumber(numbers);
            Console.WriteLine("Numbers : {0} and {1}", number1, number2);
            Console.WriteLine(number1 * number2);
        }
    }
}
