using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoshTest
{
    class Exercise3
    {
        public static void postLikes()
        {
            List<string> friendList = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter friend names: ");
                string friend = Console.ReadLine();
                bool finished = string.IsNullOrWhiteSpace(friend);
                if (finished == true)
                    break;
                friendList.Add(friend);
            }

            if (friendList.Count == 0)
                Console.WriteLine("No one likes your post.");
            else if (friendList.Count == 1)
                Console.WriteLine($"{friendList[0]} likes your post");
            else if (friendList.Count == 2)
                Console.WriteLine($"{friendList[0]} and {friendList[1]} like your post");
            else
                Console.WriteLine($"{friendList[0]}, {friendList[1]} and {friendList.Count - 2} others" +
                    $" liked your post.");
        }

        public static void nameReversal()
        {
            char[] name = new char[35];
            //List<char> nameList = new List<char>();
            Console.WriteLine("Enter your name: ");
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
                name[i] = input[i];
            char[] reverseName = new char[35];

            reverseName = name.Reverse().ToArray();

            foreach (var n in reverseName)
            {
                if (n != 0)
                    Console.Write(n);
            }
        }

        public static void uniqueNumberSort()
        {
            List<int> numbers = new List<int>();
            //List<int> uniqueNumbers = new List<int>();

            //int numberCount = 0;

            while (numbers.Count != 5)
            {

                Console.Write("Please enter a number:");
                int input = Convert.ToInt32(Console.ReadLine());
                //bool isUnique = numbers.Distinct().Count() == numbers.Count();
                if (numbers.Contains(input))
                    Console.WriteLine("Number was already entered, please enter another number.");

                else
                    numbers.Add(input);

                foreach (int n in numbers)
                    Console.WriteLine($"{n},");

            }
            numbers.Sort();

            foreach (int n in numbers)
                Console.WriteLine($"{n},");
        }

        public static void uniqueNumbers()
        {
            List<int> numbers = new List<int>();


            while (true)
            {
                Console.WriteLine("Enter a number or type Quit to exit");
                string input = Console.ReadLine();
                if (input == "quit" || input == "Quit" || input == "exit")
                {
                    break;
                }
                else
                {
                    int number = Convert.ToInt32(input);
                    numbers.Add(number);
                }
            }
            List<int> uniqueNumbers = new List<int>();
            var result = numbers.Distinct();

            foreach(int n in result)
                Console.WriteLine(n);
        }
        public static void minNumbers()
        {
            List<int> numbers = new List<int>();

            while (true)
            {
                Console.WriteLine("Please enter 5 numbers, each seperated by a comma: ");
                string input = Console.ReadLine();
                List<string> stringList = new List<string>(input.Split(','));
                int num;


                foreach (var n in stringList)
                    if (Int32.TryParse(n, out num))
                        numbers.Add(num);
                if (numbers.Count() == 0 || numbers.Count() < 5)
                    Console.WriteLine("Invalid list. Try again");
                else
                    break;
            }
            numbers.Sort();
            Console.WriteLine($"Smallest numbers in the list are: {numbers[0]}, {numbers[1]}, {numbers[2]}.");
        }
    }
}
