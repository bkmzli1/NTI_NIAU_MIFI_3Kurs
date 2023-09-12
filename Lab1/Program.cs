using System;
using System.Diagnostics;
using Lab1;

public class Program
{
    public static void Main()
    {
        //numb1();
        var1();
    }

    private static void var1()
    {
        Student student = new Student(); // Создаем один объект типа Student

        Console.WriteLine(student
            .ToShortString()); // Преобразовываем данные в текстовый вид с помощью метода ToShortString() и выводим данные
        Console.WriteLine("\n");

        // Выводим значения индексатора для значений индекса Education.Specialist, Education.Bachelor, Education.SecondEducation.
        Console.WriteLine("Is Specialist: " + student[Education.Specialist]);
        Console.WriteLine("Is Bachelor: " + student[Education.Bachelor]);
        Console.WriteLine("Is SecondEducation: " + student[Education.SecondEducation]);
        Console.WriteLine("\n");

        // Присваиваем значения всем определенным в типе Student свойствам
        student.PersonData = new Person("John", "Doe", new DateTime(1999, 12, 31));
        student.EducationForm = Education.Bachelor;
        student.GroupNumber = 123;

        // Преобразуем данные в текстовый вид с помощью метода ToString() и выводим данные
        Console.WriteLine(student.ToString());
        Console.WriteLine("\n");

        // Добавляем элементы в список экзаменов и выводим данные объекта Student, используя метод ToString()
        student.AddExams(new Exam("Math", 5, DateTime.Now), new Exam("Physics", 4, DateTime.Now));
        Console.WriteLine(student.ToString());
        Console.WriteLine("\n");


        int count = 1000000;

        var exams = new Exam[count];
        var exams2D = new Exam[count, 1];
        var examsJagged = new Exam[count][];

        for (int i = 0; i < count; i++)
        {
            exams[i] = new Exam("Math", 5, DateTime.Now);
            exams2D[i, 0] = new Exam("Math", 5, DateTime.Now);
            examsJagged[i] = new Exam[] { new Exam("Math", 5, DateTime.Now) };
        }

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        foreach (var exam in exams)
        {
            var temp = exam.Grade;
        }

        stopwatch.Stop();
        Console.WriteLine($"One-dimensional array elapsed time: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Reset();


        stopwatch.Start();
        for (int i = 0; i < count; i++)
        {
            var temp = exams2D[i, 0].Grade;
        }

        stopwatch.Stop();
        Console.WriteLine($"Two-dimensional array elapsed time: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Reset();


        stopwatch.Start();
        for (int i = 0; i < count; i++)
        {
            var temp = examsJagged[i][0].Grade;
        }

        stopwatch.Stop();
        Console.WriteLine($"Jagged array elapsed time: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Reset();

        Console.ReadKey();
    }


    private static void numb1()
    {
        string? str = Console.ReadLine();
        string[] numbers = str.Split();

        int nrow = Convert.ToInt32(numbers[0]);
        int ncolumn = Convert.ToInt32(numbers[1]);

        Person[] oneDimensionalArray = new Person[nrow * ncolumn];
        Person[,] twoDimensionalArray = new Person[nrow, ncolumn];
        Person[][] jaggedArray = new Person[nrow][];

        for (int i = 0; i < nrow * ncolumn; i++)
        {
            oneDimensionalArray[i] = new Person();
        }

        for (int i = 0; i < nrow; i++)
        {
            for (int j = 0; j < ncolumn; j++)
            {
                twoDimensionalArray[i, j] = new Person();
            }
        }

        for (int i = 0; i < nrow; i++)
        {
            jaggedArray[i] = new Person[ncolumn];
            for (int j = 0; j < ncolumn; j++)
            {
                jaggedArray[i][j] = new Person();
            }
        }

        int time = Environment.TickCount;
        foreach (Person p in oneDimensionalArray)
        {
            p.Name = "test";
        }

        Console.WriteLine("One-dimensional array time: " + (Environment.TickCount - time));

        time = Environment.TickCount;
        for (int i = 0; i < nrow; i++)
        {
            for (int j = 0; j < ncolumn; j++)
            {
                twoDimensionalArray[i, j].Name = "test";
            }
        }

        Console.WriteLine("Two-dimensional array time: " + (Environment.TickCount - time));

        time = Environment.TickCount;
        for (int i = 0; i < nrow; i++)
        {
            for (int j = 0; j < ncolumn; j++)
            {
                jaggedArray[i][j].Name = "test";
            }
        }

        Console.WriteLine("Jagged array time: " + (Environment.TickCount - time));
    }
}