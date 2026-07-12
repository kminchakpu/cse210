using System;

/*
 * CREATIVITY & EXCEEDING REQUIREMENTS:
 * 1. Implemented the Stretch Challenge: The HideRandomWords method explicitly filters out 
 *    already hidden words. It randomly selects only from the remaining visible words.
 *    This prevents the program from redundantly picking words that are already hidden.
 * 2. Optimized Game Loop: The application ensures the final state (all words hidden) 
 *    is rendered clearly before gracefully terminating.
 */

class Program
{
    static void Main(string[] args)
    {
        // Program interacts only with the essential abstractions: Reference and Scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        
        Scripture scripture = new Scripture(reference, text);

        // High-level orchestration loop
        while (true)
        {
            Console.Clear();
            
            // Display the scripture reference and text
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Check if all words are hidden to end the program
            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            // Prompt user
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            // High-level request: 'Hide words'. 
            scripture.HideRandomWords(3);
        }
    }
}