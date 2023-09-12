using Lab5;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Создаем объект типа Student и добавляем тест
            Student std = new Student { Name = "Tom", Age = 21 };
            std.AddFromConsole();
            // Создаем полную копию объекта и выводим оба объекта
            Student copyStd = std.DeepCopy();
            Console.WriteLine("Original Student:");
            PrintStudent(std);
            Console.WriteLine("Copied Student:");
            PrintStudent(copyStd);
           
            // Получение имени файла от пользователя
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();

            // Проверка на существование файла
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found. Creating new...");
                File.Create(filename).Close(); // создание и закрытие файла
            }

            // Загрузка данных из файла
            if (Student.Load(filename, out Student loadedStudent))
            {
                std = loadedStudent;
            }
            Console.WriteLine("Student after loading from file:");
            PrintStudent(std);

            // Добавление нового экзамена и сохранение данных в файл
            std.AddFromConsole();
            Student.Save(filename, std);
            Console.WriteLine("Student after adding exam and saving to file:");
            PrintStudent(std);

            // Загрузка данных из файла, добавление нового экзамена и сохранение данных в файл
            if (Student.Load(filename, out loadedStudent))
            {
                std = loadedStudent;
            }
            std.AddFromConsole();
            Student.Save(filename, std);

            Console.WriteLine("Final Student:");
            PrintStudent(std);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occurred: {ex.Message}");
        }
    }

    static void PrintStudent(Student student)
    {
        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
        Console.WriteLine("Exams:");
        foreach (var exam in student.Exams)
        {
            Console.WriteLine($"    - Subject: {exam.Subject}, Score: {exam.Score}, Date: {exam.Date:yyyy-MM-dd}");
        }
    }
}