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
            Random randomNum = new Random();
            int ranran = randomNum.Next(50, 60);
            int selectedNum = randomNum.Next(0, ranran);
            int[] arrayyy = new int[ranran];

            for (int i = 0; i < ranran; i++)
            {
                arrayyy[i] = i;
            }


            System.Console.WriteLine($"The array goes up to  {ranran}, and the number it has to get is {selectedNum}");
            System.Console.WriteLine();
            Console.WriteLine("Press any key when you want the program to run...");
            Console.ReadKey();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();


            int left = 1;
            int right = ranran;
            int attempts = 0;
            bool found = false;



            while (left <= right && !found)
            {
                int middle = left + (right - left) / 2;
                attempts++;


                if (middle == selectedNum)
                {
                    found = true;
                    System.Console.WriteLine($"The machine guessed {middle}, which needed {attempts} attempts!");
                    System.Console.WriteLine();

                }
                else if (middle < selectedNum)
                {
                    left = middle + 1;
                    System.Console.WriteLine($"The machine guessed {middle}, which is to low");
                    System.Console.WriteLine();
                }
                else if (middle > selectedNum)
                {
                    right = middle - 1;
                    System.Console.WriteLine($"The machine guessed {middle}, which is to high");
                    System.Console.WriteLine();
                }
                else
                {
                }
            }

            if (!found)
            {
                Console.WriteLine("Something went wrong. I couldn't guess your number.");
            }
        }
    }
}