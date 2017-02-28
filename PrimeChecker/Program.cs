using System;
using System.Text.RegularExpressions;

namespace PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var classAccess = new Program();
            string choice = "y";
            do
            {
                Console.WriteLine("Enter the number(s) to check for prime:");
                string numberString = Console.ReadLine();
                Regex regex = new Regex(@", | |,");
                string[] numberStringArray = regex.Split(numberString);
                long[] numberArray = new long[numberStringArray.Length];
                bool result = true;
                for (int i = 0; i < numberStringArray.Length; i++)
                {
                    result = long.TryParse(numberStringArray[i], out numberArray[i]);
                    if (!result)
                    {
                        Console.WriteLine("There is a value you tried to input that was not a long integer, please try again.");
                        break;
                    }
                }
                if (result)
                {
                    for (int i = 0; i < numberArray.Length; i++)
                    {
                        if (classAccess.IsPrime(numberArray[i]))
                        {
                            Console.WriteLine("{0} is prime", numberArray[i]);
                        }
                        else
                        {
                            Console.WriteLine("{0} is not prime", numberArray[i]);
                        }
                    }
                }
                Console.Write("Do you want to try again Y/N:  ");
                choice = Console.ReadLine().ToLower();
                Console.Clear();


            } while (choice == "y");

        }

        bool IsPrime(long number)
        {
            if (number <= 1)
            {
                return false;
            }
            else if (number <= 3)
            {
                return true;
            }
            else if (number % 2 == 0 || number % 3 == 0)
            {
                return false;
            }
            long i = 5;
            while (i * i <= number)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
                i += 6;
            }
            return true;

        }


    }
}
