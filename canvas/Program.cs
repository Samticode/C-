using System;

class Program
{
    static void Main(string[] args)
    {
        int x = Console.WindowWidth - 1;
        int y = Console.WindowHeight - 4;

        Canvas canvas = new Canvas(x, y);
        bool running = true;

        while (running)
        {
            Console.Clear();
            canvas.Display();
            Console.WriteLine(new string('-', x));
            Console.WriteLine("Commands: point x y | line x1 y1 x2 y2 | rect x y width height | clear | exit");
            Console.Write("Enter command: ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            switch (parts[0].ToLower())
            {
                case "point":
                    if (parts.Length == 3 && int.TryParse(parts[1], out int px) && int.TryParse(parts[2], out int py))
                    {
                        canvas.DrawPoint(px, py);
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Usage: point x y");
                    }
                    break;

                case "line":
                    if (parts.Length == 5 && int.TryParse(parts[1], out int x1) && int.TryParse(parts[2], out int y1) &&
                        int.TryParse(parts[3], out int x2) && int.TryParse(parts[4], out int y2))
                    {
                        canvas.DrawLine(x1, y1, x2, y2);
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Usage: line x1 y1 x2 y2");
                    }
                    break;

                case "rect":
                    if (parts.Length == 5 && int.TryParse(parts[1], out int rx) && int.TryParse(parts[2], out int ry) &&
                        int.TryParse(parts[3], out int rwidth) && int.TryParse(parts[4], out int rheight))
                    {
                        canvas.DrawRectangle(rx, ry, rwidth, rheight);
                    }
                    else
                    {
                        Console.WriteLine("Invalid command. Usage: rect x y width height");
                    }
                    break;

                case "clear":
                    canvas.Clear();
                    break;

                case "exit":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}

class Canvas
{
    private char[,] _canvas;
    private int _width;
    private int _height;

    public Canvas(int width, int height)
    {
        _width = width;
        _height = height;
        _canvas = new char[height, width];

        Clear();
    }

    public void DrawPoint(int x, int y)
    {
        if (x >= 0 && x < _width && y >= 0 && y < _height)
        {
            _canvas[y, x] = '*';
        }
    }

    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2) // Vertical line
        {
            for (int y = y1; y <= y2; y++)
            {
                DrawPoint(x1, y);
            }
        }
        else if (y1 == y2) // Horizontal line
        {
            for (int x = x1; x <= x2; x++)
            {
                DrawPoint(x, y1);
            }
        }
    }

    public void DrawRectangle(int x, int y, int width, int height)
    {
        for (int i = 0; i < width; i++)
        {
            DrawPoint(x + i, y);
            DrawPoint(x + i, y + height - 1);
        }

        for (int i = 0; i < height; i++)
        {
            DrawPoint(x, y + i);
            DrawPoint(x + width - 1, y + i);
        }
    }

    public void Clear()
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _canvas[y, x] = ' ';
            }
        }
    }

    public void Display()
    {
        // Print the width count
        Console.Write("   "); // Offset for height count
        for (int x = 0; x < _width; x++)
        {
            Console.Write(x % 10); // Print the last digit of the column number
        }
        Console.WriteLine();

        for (int y = 0; y < _height; y++)
        {
            // Print the height count
            Console.Write(y.ToString("D2") + " "); // Print the row number with 2 digits

            for (int x = 0; x < _width; x++)
            {
                Console.Write(_canvas[y, x]);
            }
            Console.WriteLine();
        }
    }
}