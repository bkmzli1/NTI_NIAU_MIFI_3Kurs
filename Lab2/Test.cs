namespace Lab2;

public class Test
{
    // Автоматическое свойство для хранения названия предмета.
    public string Subject { get; set; }

    // Автоматическое свойство для хранения информации о том, сдан зачет или нет.
    public bool IsPassed { get; set; }

    // Конструктор с параметрами для инициализации свойств класса.
    public Test(string subject, bool isPassed)
    {
        Subject = subject;
        IsPassed = isPassed;
    }

    // Конструктор без параметров, инициализирующий свойства класса значениями по умолчанию.
    public Test()
    {
        Subject = "No Subject";
        IsPassed = false;
    }

    // Переопределение метода ToString() для формирования строки со значениями всех свойств класса.
    public override string ToString()
    {
        return $"Subject: {Subject}, IsPassed: {IsPassed}";
    }
}