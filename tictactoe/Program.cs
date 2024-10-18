using System;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
        Console.ReadKey();
    }
}

class Game
{
    private Board board;
    private Player player1;
    private Player player2;
    private Player currentPlayer;

    public Game()
    {
        board = new Board();
        player1 = new Player('X');
        player2 = new Player('O');
        currentPlayer = player1;
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            board.Display();
            Console.WriteLine($"Player {currentPlayer.Symbol}'s turn.");
            currentPlayer.MakeMove(board);

            if (board.CheckWin(currentPlayer.Symbol))
            {
                Console.Clear();
                board.Display();
                Console.WriteLine($"Player {currentPlayer.Symbol} wins!");
                break;
            }

            if (board.CheckDraw())
            {
                Console.Clear();
                board.Display();
                Console.WriteLine("It's a draw!");
                break;
            }

            currentPlayer = (currentPlayer == player1) ? player2 : player1;
        }
    }
}

class Board
{
    private char[] grid;

    public Board()
    {
        grid = new char[9];
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = (i + 1).ToString()[0];
        }
    }

    public void Display()
    {
        for (int i = 0; i < grid.Length; i++)
        {
            Console.Write(grid[i]);
            if ((i + 1) % 3 == 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write(" | ");
            }
        }
    }

    public bool Update(int position, char symbol)
    {
        if (grid[position - 1] != 'X' && grid[position - 1] != 'O')
        {
            grid[position - 1] = symbol;
            return true;
        }
        return false;
    }

    public bool CheckWin(char symbol)
    {
        int[,] winPositions = new int[,]
        {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Rows
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Columns
            {0, 4, 8}, {2, 4, 6}             // Diagonals
        };

        for (int i = 0; i < winPositions.GetLength(0); i++)
        {
            if (grid[winPositions[i, 0]] == symbol &&
                grid[winPositions[i, 1]] == symbol &&
                grid[winPositions[i, 2]] == symbol)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckDraw()
    {
        foreach (char cell in grid)
        {
            if (cell != 'X' && cell != 'O')
            {
                return false;
            }
        }
        return true;
    }
}

class Player
{
    public char Symbol { get; private set; }

    public Player(char symbol)
    {
        Symbol = symbol;
    }

    public void MakeMove(Board board)
    {
        int position;
        while (true)
        {
            Console.Write("Enter position (1-9): ");
            if (int.TryParse(Console.ReadLine(), out position) && position >= 1 && position <= 9)
            {
                if (board.Update(position, Symbol))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Position already taken. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }
}