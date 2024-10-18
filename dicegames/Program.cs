namespace Dicegame
{
    class Program
    {
        static void Main(string[] args)
        {   
            int playerRandumNum;
            int enemyRandumNum;

            int playerScore = 0;
            int enemyScore = 0;

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("Press any key to roll the dice");
                playerRandumNum = random.Next(1, 7); 
                enemyRandumNum = random.Next(1, 7);
                
                System.Console.ReadKey();
                System.Console.WriteLine("You rolled: " + playerRandumNum);
                System.Console.WriteLine("...");
                System.Threading.Thread.Sleep(500);
                System.Console.WriteLine("Enemy rolled: " + enemyRandumNum);

                playerScore += playerRandumNum;
                enemyScore += enemyRandumNum;


                if (playerRandumNum > enemyRandumNum)
                {
                    System.Console.WriteLine("You win this round!");
                }
                else if (playerRandumNum < enemyRandumNum)
                {
                    System.Console.WriteLine("You lose this round!");
                }
                else
                {
                    System.Console.WriteLine("It's a draw for this round!");
                }
            }

            System.Console.WriteLine("Your score: " + playerScore);
            System.Console.WriteLine("Enemy score: " + enemyScore);

            if (playerScore > enemyScore)
            {
                System.Console.WriteLine("You win the game!");
            }
            else if (playerScore < enemyScore)
            {
                System.Console.WriteLine("You lose the game!");
            }
            else
            {
                System.Console.WriteLine("It's a draw for the game!");
            }

            System.Console.ReadKey();
        }
    }
}