using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshTest
{
    class Exercise2
    {
        public static void threeDivision()
        {
            var count = 0;
            for (var i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                    count++;
            }
            Console.WriteLine();
            Console.WriteLine($"There are {count} numbers divisible by 3 between 1 and 100.");
        }

        public static void intermediateAddition()
        {
            var numbers = new List<int>();

            while (true)
            {
                Console.WriteLine("Enter a number");
                var n = Console.ReadLine();

                if (n == "ok")
                {
                    break;
                }

                int convertedNum = Convert.ToInt32(n);
                numbers.Add(convertedNum);

                foreach (int i in numbers)
                    Console.Write($"{i} + ");
                Console.WriteLine();
            }
            int sum = numbers.AsQueryable().Sum();
            Console.WriteLine(sum);
        }

        public static void factorialOperation()
        {
            var factorialList = new List<int>();
            Console.WriteLine("Please enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int factorial = num;
            while (factorial > 0)
            {
                factorialList.Add(factorial);
                factorial = factorial - 1;
            }
            int product = 1;
            foreach (int i in factorialList)
            {
                //product = i * (i-1);
                product = product * i;
            }
            Console.WriteLine($"{num} != {product}");
        }

        public static void randomNumberGame()
        {
            Random answer = new Random();
            int number = answer.Next(0, 10);
            //Console.WriteLine(number);
            int guessCount = 0;

            while (guessCount < 4)
            {
                Console.WriteLine("Guess the correct number: ");
                var guess = Convert.ToInt32(Console.ReadLine());
                guessCount++;
                if (guess == number)
                {
                    Console.WriteLine($"You've won!");
                }
            }

            Console.WriteLine($"You've lost. Correct answer {number}");
        }

        public static void maxValue()
        {
            Console.WriteLine("Please enter a series of numbers seperated by a comma: ");
            string input = Console.ReadLine();
            string[] inputArray = input.Split(',');

            List<int> numbers = new List<int>();
            int num;

            foreach (var n in inputArray)
                if (Int32.TryParse(n, out num))
                    numbers.Add(num);
            numbers.Sort();

            foreach (var n in numbers)
                Console.Write($"{n} ");
            Console.WriteLine();
            Console.WriteLine($"The max value from the list of numbers entered is: {numbers.Max()}");
        }
    }
}
