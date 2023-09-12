namespace Lab2;



class Main
{
    public static void main()
    {
        var person1 = new Person("John", "Doe", new DateTime(1990, 1, 1));
        var person2 = new Person("John", "Doe", new DateTime(1990, 1, 1));
        Console.WriteLine(person1 == person2);
        Student student = new Student(person1, Education.SecondEducation, 5);
        student.addExams(4, new DateTime(), "2");
        student.addExams(2, new DateTime(), "1");
        student.addExams(5, new DateTime(), "3");
        student.addExams(5, new DateTime(), "4");
        student.addTests("1", true);
        student.addTests("2", false);
        student.addTests("3", false);
        student.addTests("4", true);
        foreach (Exam exam in student.PassedExams())
        {
            Console.WriteLine(exam.Subject);
            Console.WriteLine(exam.Date);
            Console.WriteLine(exam.Mark);
        }

        foreach (Test test in student.PassedTestsAndExams())
        {
            Console.WriteLine(test.Subject);
            Console.WriteLine(test.IsPassed);
        }
    }
}