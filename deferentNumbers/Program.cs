using System;

class Program
{
    static int LargestDifference(int[] numbers)
    {
        int min = numbers[0];
        int maxDiff = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            int diff = numbers[i] - min;
            if (diff > maxDiff)
                maxDiff = diff;

            if (numbers[i] < min)
                min = numbers[i];
        }

        return maxDiff;
    }

    static void Main()
    {
        int[] numbers = { 2, 6, 3, 1, 9, 8 };
        int largestDiff = LargestDifference(numbers);
        Console.WriteLine(largestDiff);
    }
}