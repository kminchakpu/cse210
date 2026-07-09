using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was a major breakthrough or challenge I overcame today?",
        "What is one thing I am incredibly grateful for right now?",
        "What is something new you learned about yourself or the world today?",
        "If your day was a movie title, what would it be and why?",
        "Describe a moment today when you felt completely at peace.",
        "What was the most challenging conversation you had today, and how did you handle it?",
        "Who is someone you appreciate right now, and what did they do to earn that appreciation?",
        "If you could send a message to yourself at the start of this day, what advice would you give?",
        "What acts of kindness—either given, received, or witnessed—did you experience today?",
        "What project or task took up most of your focus today, and are you satisfied with the progress?",
        "What is a specific goal or milestone you want to prioritize tomorrow?",
        "Describe the physical environment or weather today and how it influenced your mood."
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}