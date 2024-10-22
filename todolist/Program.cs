namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoList list = new ToDoList();
            bool done = false;

            System.Console.WriteLine("Here is the rule set for the todo list:");
            System.Console.WriteLine("Type 'done' to finish the list");
            System.Console.WriteLine("Type 'print' to print the list");
            System.Console.WriteLine("Type 'remove' to remove an item from the list");

            while (!done)
            {
                System.Console.Write("Enter an item: ");
                string item = System.Console.ReadLine();

                if (item == "done")
                {
                    done = true;
                }
                else if (item == "print")
                {
                    list.Print();
                }
                else if (item == "remove")
                {
                    Console.Clear();
                    list.Print();
                    System.Console.Write("Enter the index of the item to remove: ");
                    int index = int.Parse(System.Console.ReadLine());
                    Console.Clear();
                    list.Remove(index);
                    list.Print();
                }
                else
                {
                    Console.Clear();
                    list.Add(item);
                    list.Print();
                }
            }
        }
    }

    class ToDoList
    {
        private string[] items = new string[10];
        private int count = 0;

        public void Add(string item)
        {
            items[count] = item;
            count++;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                System.Console.WriteLine(i + " : " + items[i]);
            }
        }

        public void Remove(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
        }
    }
}