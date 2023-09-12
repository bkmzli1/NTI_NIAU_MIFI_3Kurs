using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5;

[Serializable] // Обязательно должны заметить класс как сериализуемый
public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Exam> Exams { get; set; } = new List<Exam>(); // список экзаменов
    
    //...
        
    // добавление нового экзамена, данные для которого вводятся с консоли
    public bool AddFromConsole()
    {
        try
        {
            Console.WriteLine("Enter Exam data in the format: <subject>;<score>;<date(yyyy-mm-dd)>");
            string inputData = Console.ReadLine();
            string[] splitData = inputData.Split(';');

            // если данные корректны, добавляем новый экзамен в список
            if (splitData.Length == 3)
            {
                string subject = splitData[0];
                int score = int.Parse(splitData[1]);
                DateTime date = DateTime.Parse(splitData[2]);

                Exams.Add(new Exam { Subject = subject, Score = score, Date = date });
                return true;
            }
            else
            {
                Console.WriteLine("Data is incorrect, please try again using the specified format.");
                return false;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("An error has occurred while adding exam. Please check the input data.");
            return false;
        }
    }
    

    // DeepCopy() для создания полной копии объекта
    public Student DeepCopy()
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new MemoryStream())
        {
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            return (Student)formatter.Deserialize(stream);
        }
    }

    // Save(string filename) для сохранения данных объекта в файле
    public bool Save(string filename)
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, this);
            stream.Close();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // Load(string filename) для инициализации объекта данными из файла
    public bool Load(string filename)
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);

            Student objnew = (Student)formatter.Deserialize(stream);
            this.Name = objnew.Name;
            this.Age = objnew.Age;

            stream.Close();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    

    // static bool Save(string filename, T obj) для сохранения объекта в файле
    public static bool Save(string filename, Student obj)
    {
        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, obj);
            stream.Close();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // static bool Load(string filename, T obj) для восстановления объекта из файла
    public static bool Load(string filename, out Student obj)
    {
        try
        {
            FileInfo fileInfo = new FileInfo(filename);
            if (fileInfo.Length == 0)
            {
                obj = null;
                Console.WriteLine("File is empty - couldn't initialize object from file.");
                return false;
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            obj = (Student)formatter.Deserialize(stream);
            stream.Close();
            return true;
        }
        catch (Exception)
        {
            obj = null; // Должны присвоить значение для out параметра
            return false;
        }
    }
}