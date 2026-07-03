using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for grade percentage
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        string letter = "";
        string sign = "";

         //  Determine the letter grade 
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

         // Determine the sign (+ or -)
        // Using the remainder operator (%) to get the last digit
        int lastDigit = gradePercentage % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = ""; 
        }

        // This Handle A+, F+, and F-
        if (letter == "A" && sign == "+")
        {
            sign = ""; 
        }
        else if (letter == "F")
        {
            sign = ""; 
        }

        // Print statement for the full grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep working hard and you'll get it next time.");
        }
    }
}