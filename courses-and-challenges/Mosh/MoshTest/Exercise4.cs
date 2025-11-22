using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MoshTest
{
    class Exercise4
    {
        public static void consecutiveNumbers()
        {
            Console.WriteLine("Enter a few numbers seperated by a hyphen(-): ");

            var input = Console.ReadLine();
            var numberLine = input.Split('-');
            int firstNumber = Convert.ToInt32(numberLine[0]);

            bool consecutive = true;

            for (int i = 0; i < numberLine.Length; i++)
                if (Convert.ToInt32(numberLine[i]) - i != firstNumber && Convert.ToInt32(numberLine[i]) + i != firstNumber)
                {
                    consecutive = false;
                    break;
                }
            if (consecutive)
                Console.WriteLine("Consecutive");
            else
                Console.WriteLine("Not Consecutive");
        }

        public static void duplicateFinder()
        {
            Console.WriteLine("Please enter a few numbers seperated by a hyphon: ");
            var input = Console.ReadLine();
            var numbers = input.Split('-');
            bool isUnique = true;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        break;
                    }
                    else if (Convert.ToInt32(numbers[i]) == Convert.ToInt32(numbers[j]))
                    {
                        isUnique = false;
                    }
                }
            }
            if (isUnique)
                Console.WriteLine("No duplicates");
            else
                Console.WriteLine("Duplicates");
        }

        public static void timeValidate()
        {
            Console.WriteLine("Enter a time (00:00 - 23:59): ");
            var input = Console.ReadLine();
            DateTime timeValue;
            //var start = "00:00";
            //var end = "23:59";
            bool valid = DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeValue);
            if (valid == false || string.IsNullOrWhiteSpace(input))
                Console.WriteLine("invalid");

            else
                Console.WriteLine("Valid");
        }

        public static void pascalCase()
        {
            Console.WriteLine("Enter a few words separated by a space: ");
            string phrase = Console.ReadLine();
            string[] words = phrase.Split(' ');

            foreach (var word in words)
                Console.Write($"{char.ToUpper(word[0]) + word.Substring(1)}");
        }

        public static void vowelCount()
        {
            int vowelCounter = 0;
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            Console.WriteLine("Enter a word: ");
            string input = Console.ReadLine().ToLower();

            for (int i = 0; i < input.Length; i++)
            {
                if (vowels.Contains(input[i]))
                {
                    vowelCounter++;
                }
            }
            Console.WriteLine($"The total amount of vowels in this word is {vowelCounter}");

        }
    }
}
