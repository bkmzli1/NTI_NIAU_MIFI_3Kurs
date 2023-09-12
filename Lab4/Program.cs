using System;
using Lab4;

class Program
{
    static void Main()
    {
        //Creating two collections of StudentCollection
        StudentCollection studentCollection1 = new StudentCollection();
        StudentCollection studentCollection2= new StudentCollection();

        //Creating two Journal
        Journal journal1 = new Journal();
        Journal journal2 = new Journal();

        //Subscribing Journal1 to Collection1's events
        studentCollection1.StudentsCountChanged += journal1.StudentsCountChangedHandler;
        studentCollection1.StudentReferenceChanged += journal1.StudentReferenceChangedHandler;

        //Subscribing Journal2 to StudentReferenceChanged events from both collections
        studentCollection1.StudentReferenceChanged += journal2.StudentReferenceChangedHandler;
        studentCollection2.StudentReferenceChanged += journal2.StudentReferenceChangedHandler;

        // Adding students to the collections
        studentCollection1.AddStudents(new Student { Name = "John", Surname = "Doe" });
        studentCollection2.AddStudents(new Student { Name = "Jane", Surname = "Doe" });

        // Removing students from the collections (expect false as there is only one student)
        Console.WriteLine(studentCollection1.Remove(1)); 
        Console.WriteLine(studentCollection2.Remove(1)); 

        // Change Student properties
        studentCollection1[0] = new Student { Name = "James", Surname = "Bond" };
        studentCollection2[0] = new Student { Name = "Emma", Surname = "Watson" };

        //Output Journals
        Console.WriteLine("\nJournal 1:\n" + journal1);
        Console.WriteLine("\nJournal 2:\n" + journal2);

        Console.ReadKey(); 
    }
}