namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;
            int result;

            string operation;

            System.Console.WriteLine("Hello, welcome to the calculator program");

            System.Console.WriteLine("Enter the first number");
            num1 = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Enter the second number");
            num2 = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Enter the operation you want to perform, s for sub, m for mul, d for div, a for add");
            operation = Console.ReadLine();

            if (operation == "s")
            {
                result = num1 - num2;
                System.Console.WriteLine("The result is " + result);
            }
            else if (operation == "m")
            {
                result = num1 * num2;
                System.Console.WriteLine("The result is " + result);
            }
            else if (operation == "d")
            {
                result = num1 / num2;
                System.Console.WriteLine("The result is " + result);
            }
            else if (operation == "a")
            {
                result = num1 + num2;
                System.Console.WriteLine("The result is " + result);
            }
            else
            {
                System.Console.WriteLine("Invalid operation");
            }

            System.Console.ReadKey();
        }
    }
}