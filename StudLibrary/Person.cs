namespace StudLibrary;

class Person
{
    protected string name;
    protected string surname;
    protected DateTime birthdate;

    public Person(string Name, string Surname, DateTime Birthdate)
    {
        this.name = Name;
        this.surname = Surname;
        this.birthdate = Birthdate;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Person)
        {
            var other = obj as Person;
            return this.name == other.name && this.surname == other.surname && this.birthdate == other.birthdate;
        }

        return false;
    }

    public static bool operator ==(Person left, Person right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Person left, Person right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return name.GetHashCode() + surname.GetHashCode() + birthdate.GetHashCode();
    }
}