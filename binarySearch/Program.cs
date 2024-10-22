namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args) 
        {
            int[] arrayOfNumbersToBeSorted = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int numberToBeSearched = 3;

            int result = BinarySearch(arrayOfNumbersToBeSorted, numberToBeSearched);
            if (result == -1)
            {
                Console.WriteLine("Element not present");
            }
            else
            {
                Console.WriteLine("Element found at index " + result);
            }
        }

        static int BinarySearch(int[] arrayOfNumbersToBeSorted, int numberToBeSearched)
        {
            int left = 0;
            int right = arrayOfNumbersToBeSorted.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arrayOfNumbersToBeSorted[mid] == numberToBeSearched)
                {
                    return mid;
                }

                if (arrayOfNumbersToBeSorted[mid] < numberToBeSearched)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}
