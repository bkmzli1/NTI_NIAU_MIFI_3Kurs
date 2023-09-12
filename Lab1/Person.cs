using System;

public class Person
{
    private string name;  //закрытое поле типа string, в котором хранится имя;
    private string surname;  //закрытое поле типа string, в котором хранится фамилия;
    private DateTime birthDate;  //закрытое поле типа System.DateTime для даты рождения;

    //конструктор c тремя параметрами типа string, string, DateTime для инициализации всех полей класса;
    public Person(string name, string surname, DateTime birthDate)
    {
        this.name = name;
        this.surname = surname;
        this.birthDate = birthDate;
    }

    //конструктор без параметров, инициализирующий все поля класса некоторыми значениями по умолчанию.
    public Person() : this("John", "Doe", DateTime.Now) { }

    // свойства c методами get и set
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public int BirthYear
    {
        get { return birthDate.Year; }
        set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
    }

    //перегруженная(override) версию виртуального метода string ToString() для формирования строки со значениями всех полей класса;
    public override string ToString()
    {
        return $"Name: {Name}, Surname: {Surname}, Birth date: {BirthDate}";
    }

    //виртуальный метод string ToShortString(), который возвращает строку, содержащую только имя и фамилию.
    public virtual string ToShortString()
    {
        return $"Name: {Name}, Surname: {Surname}";
    }
}