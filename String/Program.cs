using System;

class Program
{
    static string ReverseWords(string input)
    {
        string[] words = input.Split();  // Split the string into an array of words
        Array.Reverse(words);  // Reverse the order of the words
        string reversedString = string.Join(" ", words);  // Join the reversed words back into a string
        return reversedString;
    }

    static void Main()
    {
        string inputString = "Hello World!";
        string reversedString = ReverseWords(inputString);
        Console.WriteLine(reversedString);
    }
}