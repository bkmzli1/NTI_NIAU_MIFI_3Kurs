namespace Lab1;

using System;

public class Person
{
    private string name;
    private string surname;
    private DateTime birthdate;

    public Person(string name, string surname, DateTime birthdate)
    {
        this.name = name;
        this.surname = surname;
        this.birthdate = birthdate;
    }

    public Person() : this("Default", "Default", DateTime.MinValue) { }

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
        get { return birthdate; }
        set { birthdate = value; }
    }

    public int BirthYear
    {
        get { return birthdate.Year; }
        set { birthdate = new DateTime(value, birthdate.Month, birthdate.Day); }
    }

    public override string ToString()
    {
        return $"{Name} {Surname} {BirthDate.ToShortDateString()}";
    }

    public virtual string ToShortString()
    {
        return $"{Name} {Surname}";
    }
}