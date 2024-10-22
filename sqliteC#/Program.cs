using System;
using Microsoft.Data.Sqlite;

class Program
{
    public void Add(string name, int age)
    {
        string connectionString = "Data Source=db/database.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            try
            {
                connection.Open();

                string sql = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT, age INTEGER)";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                sql = "SELECT COUNT(*) FROM users WHERE name = @name AND age = @age";
                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    int userCount = Convert.ToInt32(command.ExecuteScalar());
                    if (userCount == 0)
                    {
                        sql = "INSERT INTO users (name, age) VALUES (@name, @age)";
                        using (var insertCommand = new SqliteCommand(sql, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@name", name);
                            insertCommand.Parameters.AddWithValue("@age", age);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        Console.WriteLine("User already exists");
                    }
                }

                sql = "SELECT * FROM users";
                using (var command = new SqliteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Id: " + reader["id"] + " Name: " + reader["name"] + " Age: " + reader["age"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void Show()
    {
        string connectionString = "Data Source=db/database.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            try
            {
                connection.Open();

                string sql = "SELECT * FROM users";
                using (var command = new SqliteCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Id: " + reader["id"] + " Name: " + reader["name"] + " Age: " + reader["age"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

class UserInterface
{
    public string GetName()
    {
        Console.Write("Enter name: ");
        return Console.ReadLine();
    }

    public int GetAge()
    {
        Console.Write("Enter age: ");
        return Convert.ToInt32(Console.ReadLine());
    }
}

class MainClass
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Enter a command: ");
            string command = Console.ReadLine();

            if (command == "exit")
            {
                running = false;
            }
            else if (command == "add")
            {
                UserInterface userInterface = new UserInterface();
                string name = userInterface.GetName();
                int age = userInterface.GetAge();

                Program program = new Program();
                program.Add(name, age);
            }
            else if (command == "show")
            {
                Program program = new Program();
                program.Show();
            }
        }
    }
}