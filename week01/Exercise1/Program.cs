using System;

// JamesBondIntroduction

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Print a blank line for spacing 
        Console.WriteLine();

        // Display the formatted output 
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
