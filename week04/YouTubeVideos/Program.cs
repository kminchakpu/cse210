using System;
using System.Collections.Generic;

// --- COMMENT CLASS ---
public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public string GetCommenterName() => _commenterName;
    public string GetCommentText() => _commentText;
}

// --- VIDEO CLASS ---
public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine($"Total Comments: {GetCommentCount()}");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Comments:");
        
        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment.GetCommenterName()}: \"{comment.GetCommentText()}\"");
        }
        Console.WriteLine("==================================================\n");
    }
}

// --- MAIN PROGRAM ENTRY ---
class Program
{
    static void Main(string[] args)
    {
        List<Video> videoList = new List<Video>();

        // Video 1
        Video video1 = new Video("C# Basics in 10 Minutes", "CodeWizard", 600);
        video1.AddComment(new Comment("Fatimah", "This was incredibly helpful, thank you!"));
        video1.AddComment(new Comment("Kadon", "Clear and concise explanation. Subscribed."));
        video1.AddComment(new Comment("Kponi", "Can you make a video on Object-Oriented principles next?"));
        videoList.Add(video1);

        // Video 2
        Video video2 = new Video("How to Clean a Mechanical Keyboard", "TechFix", 420);
        video2.AddComment(new Comment("Okwonkwo", "Tried this and my spacebar works perfectly again!"));
        video2.AddComment(new Comment("Emma", "What kind of alcohol should I use to clean the switches?"));
        video2.AddComment(new Comment("Frank", "Great production quality on this guide."));
        videoList.Add(video2);

        // Video 3
        Video video3 = new Video("Exploring Hidden Waterfalls", "Wanderlust Chronicles", 1250);
        video3.AddComment(new Comment("Grace", "Wow, that third location looks absolutely surreal."));
        video3.AddComment(new Comment("Haruna", "Adding this hidden trail to my bucket list immediately!"));
        video3.AddComment(new Comment("Kehinde", "What camera settings did you use for the long exposure waterfall shots?"));
        videoList.Add(video3);

        // Iterate and display details
        Console.WriteLine("--- YOUTUBE TRACKING REPORT ---\n");
        foreach (Video video in videoList)
        {
            video.DisplayVideoDetails();
        }
    }
}