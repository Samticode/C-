namespace Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 10001);
            int guess = 0;
            int attempts = 0;

            System.Console.WriteLine("Guess the number between 1 and 10000");

            while (guess != randomNumber)
            {
                System.Console.Write("Enter your guess: ");
                guess = int.Parse(System.Console.ReadLine());
                attempts++;

                if (guess > randomNumber)
                {
                    System.Console.WriteLine("Too high!");
                }
                else if (guess < randomNumber)
                {
                    System.Console.WriteLine("Too low!");
                }
                else
                {
                    System.Console.WriteLine("You guessed the number!");
                    System.Console.WriteLine("It took you " + attempts + " attempts");
                }
            }
        }
    }
}