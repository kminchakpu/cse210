using System;
using System.Collections.Generic;
using System.IO;

/*
 * CREATIVITY & EXCEEDING REQUIREMENTS:
 * 1. Stretch Challenge - Unique Word Filtering: The HideRandomWords method filters out 
 *    already hidden words so that it only picks from remaining visible words.
 * 2. Exceeding Requirements - Scripture Library: The program maintains a library of 
 *    scriptures instead of using a single hardcoded one.
 * 3. Exceeding Requirements - File Input Loading: The program dynamically reads and parses 
 *    scripture options from an external 'scriptures.txt' file. If the file is 
 *    missing, it gracefully uses a fallback local library array so the program never crashes.
 * 4. Exceeding Requirements - Random Scripture Picker: The program selects a random passage 
 *    from the loaded file collection to display to the user upon launch.
 */

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = new List<Scripture>();
        string fileName = "scriptures.txt";

        // Try to load scriptures from the text file
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length == 5)
                {
                    string book = parts[0];
                    int chapter = int.Parse(parts[1]);
                    int startVerse = int.Parse(parts[2]);
                    int endVerse = int.Parse(parts[3]);
                    string text = parts[4];

                    Reference reference = new Reference(book, chapter, startVerse, endVerse);
                    library.Add(new Scripture(reference, text));
                }
            }
        }

        // Fallback library if the text file is missing or empty
        if (library.Count == 0)
        {
            library.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
            library.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        }

        // Pick a scripture at random from my library
        Random random = new Random();
        Scripture scripture = library[random.Next(0, library.Count)];

        // Main program loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}