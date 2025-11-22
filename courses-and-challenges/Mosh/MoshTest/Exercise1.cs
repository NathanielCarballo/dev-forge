using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoshTest
{
    class Exercise1
    {
        public static void numberValidator()
        {
            Console.WriteLine("Please enter a number between 1-10");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num >= 10)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");

        }

        public static void simpleAddition()
        {
            Console.Write("Enter first number for addition: ");
            int firstNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number for addition: ");
            int secondNum = Convert.ToInt32(Console.ReadLine());

            int max = (firstNum > secondNum) ? firstNum : secondNum;
            Console.WriteLine("Max is " + max);
        }

        public static void imageOrientation()
        {
            Console.Write("Enter the height of the image: ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the width of the image: ");
            int width = Convert.ToInt32(Console.ReadLine());

            if (width > height)
                Console.WriteLine("The orientation of this image is landscape.");
            else
                Console.WriteLine("The orientation of this image is portrait.");
        }

        public static void speedRadar()
        {
            Console.Write("Please enter a number for the speed limit: ");
            var speedLimit = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the speed of the car: ");
            var carSpeed = Convert.ToInt32(Console.ReadLine());

            int speedDifference = carSpeed - speedLimit;
            int demerit = speedDifference / 5;

            if (carSpeed <= speedLimit)
                Console.WriteLine("Speed traveled is ok");
            else if (demerit >= 12)
                Console.WriteLine($"{demerit} points incurred. License Suspended");
            else
                Console.WriteLine($"{demerit} points incurred.");
        }

        public static void randomNumGen()
        {
            Random rnd = new Random();
            int decision = rnd.Next(1,7);
            List<int> tues = new List<int>();
            List<int> thurs = new List<int>();

            while (true)
            {
                int randomNumber = rnd.Next(1, 7);
                decision = randomNumber;

                if (tues.Count < 3 && tues.Contains(decision) == false)
                    tues.Add(decision);
                else if (thurs.Count < 3 && tues.Contains(decision) == false && thurs.Contains(decision) == false)
                    thurs.Add(decision);
                else if (thurs.Count == 3 && tues.Count == 3)
                    break;
            }

            foreach(int tu in tues)
            Console.WriteLine($"the numbers for tuesday are {tu}");
            foreach(int th in thurs)
            Console.WriteLine($"the numbers for thursday are {th}");
        }
    }
}
