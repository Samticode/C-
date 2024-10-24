using System;

namespace BinarySearchWithGuessingGame
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.PlayGuessingGame();
        }
    }

    class Program
    {
        public void PlayGuessingGame()
        {
            Console.WriteLine("Think of a number between 1 and 100, and I will try to guess it.");
            Console.WriteLine("Press any key when you are ready...");
            Console.ReadKey();

            int left = 1;
            int right = 100;
            int attempts = 0;
            bool found = false;

            while (left <= right && !found)
            {
                int middle = left + (right - left) / 2;
                attempts++;

                Console.WriteLine($"Is your number {middle}? (Enter 'h' if higher, 'l' if lower, 'c' if correct)");
                string response = Console.ReadLine();

                if (response == "c")
                {
                    found = true;
                    Console.WriteLine($"I guessed your number in {attempts} attempts!");
                }
                else if (response == "h")
                {
                    left = middle + 1;
                }
                else if (response == "l")
                {
                    right = middle - 1;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'h', 'l', or 'c'.");
                }
            }

            if (!found)
            {
                Console.WriteLine("Something went wrong. I couldn't guess your number.");
            }
        }
    }
}