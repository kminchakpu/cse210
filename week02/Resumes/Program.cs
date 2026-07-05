using System;

class Program
{
    static void Main(string[] args)
    {
        
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2022;
        job1._endYear = 2026;

        
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2026;
        job2._endYear = 2028;

   
        Resume myResume = new Resume();
        myResume._name = "Kevin Cross Minchakpu";

        
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

       
        myResume.Display();
    }
}