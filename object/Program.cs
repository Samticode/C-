namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {

            Human human1 = new Human("Michael", 25);

            Car car1 = new Car("Ford", "Mustang", 2019);
            // Console.WriteLine(Car.numberOfCars);
            // Car.StartRace();

            Pizza pizza = new Pizza("Thin", "Tomato", "Mozzarella", "Pepperoni");
            Pizza cheesePizza = new Pizza("Thin", "Tomato", "Mozzarella");
            Pizza piizza = new Pizza("Thin", "Tomato");

            Bar bar = new Bar();
            Motorcycle motorcycle = new Motorcycle();
            Boat boat = new Boat();

            bar.go();

            Console.ReadKey();
        }
    }

    class Vehicle
    {
        public int speed = 0;

        public void go()
        {
            Console.WriteLine("I am going");
        }
    }
    class Bar : Vehicle
    {
        public int wheels = 4;
    }
    class Motorcycle : Vehicle
    {
        public int wheels = 2;
    }
    class Boat : Vehicle
    {
        public int wheels = 0;
    }

    class Pizza
    {
        string bread;
        string sauce;
        string cheese;
        string toppings;

        public Pizza(string bread, string sauce, string cheese, string toppings)
        {
            this.bread = bread;
            this.sauce = sauce;
            this.cheese = cheese;
            this.toppings = toppings;
        }
        public Pizza(string bread, string sauce, string cheese)
        {
            this.bread = bread;
            this.sauce = sauce;
            this.cheese = cheese;
        }
        public Pizza(string bread, string sauce)
        {
            this.bread = bread;
            this.sauce = sauce;
        }
    }

    class Car
    {
        string make;
        string model;
        int year;
        public static int numberOfCars;

        public Car(string make, string model, int year)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            numberOfCars++;
        }

        public void Drive()
        {
            Console.WriteLine($"{make} {model} am driving");
        }
        public void Stop()
        {
            Console.WriteLine($"{make} {model} am stopping");
        }
        public static void StartRace()
        {
        Console.WriteLine("Hopla");
        }
    }

    class Human
    {
        public string name;
        public int age;

        public Human(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Eat()
        {
            Console.WriteLine($"{name} am eating");
        }
        public void Sleep()
        {
            Console.WriteLine($"{name} am sleeping");
        }
    }
}
