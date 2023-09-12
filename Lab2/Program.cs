using System.Diagnostics;
using Lab2;


public class Program
{
    public static void Main()
    {
        //numb1();
        //var1();
        var2();
        // дополнительно 
        Student student = new Student();
        student.AddExams(new Exam("Math", 5, new DateTime(2022, 1, 1)));
        student.ExamList.Add(new Exam("Biology", 4, new DateTime(2022, 1, 1)));
        student.TestList.Add(new Test("Math", true));
        student.TestList.Add(new Test("Biology", true));

        // Вывод списка предметов, которые есть и в списке экзаменов, и в списке зачетов
        Console.WriteLine("Список предметов, которые есть и в списке экзаменов, и в списке зачетов:");
        foreach (string subject in student)
        {
            Console.WriteLine(subject);
        }

        // Вывод списка всех сданных зачетов и сданных экзаменов
        Console.WriteLine("\nСписок всех сданных зачетов и сданных экзаменов:");
        foreach (var item in student.GetPassedExamsAndTests())
        {
            Console.WriteLine(item.ToString());
        }

        // Вывод списка сданных зачетов, для которых сдан и экзамен
        Console.WriteLine("\nСписок сданных зачетов, для которых сдан и экзамен:");
        foreach (var item in student.GetPassedExamsAndTestsLinked())
        {
            Console.WriteLine(item.ToString());
        }
    }

    private static void var2()
    {
        // Создание двух объектов типа Person с совпадающими данными
        Person person1 = new Person("John", "Doe", DateTime.Now);
        Person person2 = new Person("John", "Doe", DateTime.Now);

        // Проверка, что ссылки на объекты не равны
        Console.WriteLine(person1 == person2); // Выводит: False

        // Проверка, что объекты равны
        Console.WriteLine(person1.Equals(person2)); // Выводит: True

        // Вывод хэшкодов объектов
        Console.WriteLine(person1.GetHashCode());
        Console.WriteLine(person2.GetHashCode());

        // Создание объекта типа Student
        Student student1 = new Student(person1, Education.Specialist, 123);

        // Добавление элементов в список экзаменов и зачетов
        student1.AddExams(new Exam("Exam1", 5, DateTime.Now), new Exam("Exam2", 4, DateTime.Now));

        // Вывод данных объекта Student
        Console.WriteLine(student1);

        // Вывод значения свойства типа Person для объекта типа Student
        Console.WriteLine(student1.PersonData);

        // Создание полной копии объекта Student
        Student studentCopy = (Student)student1.DeepCopy();

        // Изменение данных в исходном объекте Student
        student1.PersonData = new Person("Jane", "Doe", DateTime.Now);
        student1.AddExams(new Exam("Exam3",  3,DateTime.Now));

        // Вывод копии и исходного объекта
        Console.WriteLine("Оригинальный студент:");
        Console.WriteLine(student1);
        Console.WriteLine("Копия студента:");
        Console.WriteLine(studentCopy);
        try
        {
            // Присвоение свойству с номером группы некорректное значение
            student1.GroupNumber = 700;
        }
        catch (ArgumentOutOfRangeException e)
        {
            // Вывод сообщения, переданного через объект-исключение
            Console.WriteLine(e.Message);
        }

        // Использование оператора foreach для итератора,
        // для вывода списка всех зачетов и экзаменов
        Console.WriteLine("Список всех зачетов и экзаменов:");
        foreach (object obj in student1.ExamsAndTests)
        {
            Console.WriteLine(obj);
        }

        // Использование оператора foreach для итератора с параметром,
        // для вывода списка всех экзаменов с оценкой выше 3
        Console.WriteLine("Список всех экзаменов с оценкой выше 3:");
        foreach (Exam exam in student1.GetExamsMoreThan(3))
        {
            Console.WriteLine(exam);
        }
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
}