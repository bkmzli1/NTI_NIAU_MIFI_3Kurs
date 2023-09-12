namespace Lab1;

public class Main
{
    public static void main()
    {
        Student student = new Student(new Person("John", "Doe", new DateTime(2000, 6, 12)), Education.Bachelor, 1);
        student.AddExams(new Exam("Math", 5, new DateTime(2021, 6, 30)),
            new Exam("English", 4, new DateTime(2021, 6, 15)));

        Console.WriteLine(student.ToShortString());
        Console.WriteLine(student[Education.Bachelor]); 
        Console.WriteLine(student[Education.Specialist]); 
        Console.WriteLine(student[Education.SecondEducation]);
        Console.WriteLine(student.ToShortString());
        
        
        student.PersonData = new Person("Jane", "Doe", new DateTime(2001, 7, 22));
        student.EducationForm = Education.SecondEducation;
        student.GroupNumber = 2;
        student.AddExams(new Exam("Biology", 5, new DateTime(2021, 6, 30)),
            new Exam("Chemistry", 4, new DateTime(2021, 6, 15)));

        Console.WriteLine(student.ToString());

        var nrow = 3;
        var ncolumn = 2;

        Exam[] oneDimensionalArray = new Exam[nrow * ncolumn];
        Exam[,] rectangularArray = new Exam[nrow, ncolumn];
        Exam[][] jaggedArray = new Exam[nrow][];

        var timeBeforeOneDimensionalArray = Environment.TickCount;
        for (int i = 0; i < oneDimensionalArray.Length; i++)
        {
            oneDimensionalArray[i] = new Exam("Exam " + i, 5, DateTime.Now);
        }

        var timeAfterOneDimensionalArray = Environment.TickCount;

        var timeBeforeRectangularArray = Environment.TickCount;
        for (int i = 0; i < nrow; i++)
        {
            for (int j = 0; j < ncolumn; j++)
            {
                rectangularArray[i, j] = new Exam("Exam " + i + j, 5, DateTime.Now);
            }
        }

        var timeAfterRectangularArray = Environment.TickCount;

        var timeBeforeJaggedArray = Environment.TickCount;
        for (int i = 0; i < nrow; i++)
        {
            jaggedArray[i] = new Exam[ncolumn];
            for (int j = 0; j < ncolumn; j++)
            {
                jaggedArray[i][j] = new Exam("Exam " + i + j, 5, DateTime.Now);
            }
        }

        var timeAfterJaggedArray = Environment.TickCount;

        Console.WriteLine("Time for one-dimensional array: " +
                          (timeAfterOneDimensionalArray - timeBeforeOneDimensionalArray));
        Console.WriteLine("Time for rectangular array: " + (timeAfterRectangularArray - timeBeforeRectangularArray));
        Console.WriteLine("Time for jagged array: " + (timeAfterJaggedArray - timeBeforeJaggedArray));
    }
}