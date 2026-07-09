using System;
using System.IO;

// ===================================================================================
// EXCEEDING REQUIREMENTS DESCRIPTION:
// To exceed the core 93% requirements, this program implements an expanded data capture
// system for journal entries. Alongside the standard date, prompt, and entry text, it
// prompts the user for a "Mood/Energy Rating" on a scale of 1-5. This extra structural 
// metric is successfully integrated into the Entry class tracking, safely serialized to 
// storage using a specialized string delimiter (~|~), and populated dynamically upon load.
//
// ADDITIONAL CREATIVITY: The program now automatically checks for and loads a default 
// "journal.txt" file immediately upon startup so the user's data persists seamlessly
// between program runs without needing manual loading steps.
// ===================================================================================

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;
        
        // Define a default file to persist data automatically
        string defaultFile = "journal.txt";

        Console.WriteLine("Welcome to the Journal Program!");
        
        // AUTOMATIC LOAD: Check if the file exists and load it immediately at startup
        if (File.Exists(defaultFile))
        {
            Console.WriteLine($"Loading your saved entries from '{defaultFile}'...");
            theJournal.LoadFromFile(defaultFile);
        }
        else
        {
            Console.WriteLine("No previous journal file found. Starting a fresh journal.");
        }

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load (From custom file)");
            Console.WriteLine("4. Save (To custom file)");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                
                // Greater-than prompt indicator for user response
                Console.Write("> "); 
                string response = Console.ReadLine();

                Console.Write("Rate your overall mood/energy today (1-5): ");
                string mood = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;
                newEntry._moodRating = mood;

                theJournal.AddEntry(newEntry);
                
                // Auto-save to the default file so changes aren't lost if you forget to save
                theJournal.SaveToFile(defaultFile);
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n--- Journal Entries ---");
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose a number from 1 to 5.");
            }
        }
    }
}