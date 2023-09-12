namespace Lab3;

using System;



public class Person : IDateAndCopy
{
    public string name { get; set; } 
    public string surname { get; set; } 
    public DateTime birthDate { get; set; }
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
    
    public Person() : this("John", "Doe", DateTime.Now) { }
    public Person(string name, string surname, DateTime birthDate)
    {
        this.name = name;
        this.surname = surname;
        this.birthDate = birthDate;
    }

   

    //метод копирования 
    public object DeepCopy()
    {
        return this.MemberwiseClone();
    }

    public DateTime Date { get; set; }

    //переопределение метода сравнения 
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        Person person = obj as Person;
        if (person == null)
            return false;

        return (name == person.name) && (surname == person.surname) && (birthDate == person.birthDate);
    }
    
    //переопределение хэш-кода
    public override int GetHashCode()
    {
        return Tuple.Create(name, surname, birthDate).GetHashCode();
    }

    // Операторы == и !=
    public static bool operator ==(Person person1, Person person2)
    {
        if ((object)person1 == null || ((object)person2) == null)
            return Object.Equals(person1, person2);

        return person1.Equals(person2);
    }

    public static bool operator !=(Person person1, Person person2)
    {
        if ((object)person1 == null || ((object)person2) == null)
            return !Object.Equals(person1, person2);

        return !(person1.Equals(person2));
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