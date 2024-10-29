namespace multidimential
{
    class Program
    {
        static void Main()
        {
            string[,] parkinglot = {
                                        {"Mustang", "f-150", "explorer"},
                                        {"Corvette", "Prius", "Yaris"},
                                        {"Bugatti", "Fiat", "Maserati"}
                                    };

            parkinglot[0, 0] = "HELLCAT";
            parkinglot[1, 2] = "CAMERO";
            parkinglot[2, 1] = "CHALLENGER";

            PrintParkingLot(parkinglot);
        }

        static void PrintParkingLot(string[,] parkinglot)
        {
            int rows = parkinglot.GetLength(0);
            int cols = parkinglot.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(parkinglot[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
