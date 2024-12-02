namespace ReverseString
{
    class MainClass
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;
        
            while (keepGoing)
            {
                Program.ReverseString();
                
                System.Console.WriteLine();
                System.Console.Write("Would you like to reverse another string? (y/n): ");
                string response = System.Console.ReadLine();
                
                if (response.ToLower() != "y")
                {
                    keepGoing = false;
                }
            }
        }
    }
    
    class Program
    {
        public static void ReverseString()
        {
            System.Console.Write("Enter a string: ");
            string userInput = Console.ReadLine();
            
            char[] charArray = userInput.ToCharArray();
            // System.Array.Reverse(charArray);
            // string reversedString = new string(charArray);
            
            string reversedString = ReverseThatThang(userInput);
            
            System.Console.WriteLine();
            System.Console.WriteLine("Reversed string: ");
            System.Console.WriteLine(reversedString);
        }
        
        private static string ReverseThatThang(string input)
        {
            char[] charArray = input.ToCharArray();
            
            for (int i = 0; i < charArray.Length / 2; i++)
            {
                char temp = charArray[i];
                charArray[i] = charArray[charArray.Length - 1 - i];
                charArray[charArray.Length - 1 - i] = temp;
            }
            
            return new string(charArray);
        }
    }
}