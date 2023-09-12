namespace Lab3;

public class Paper
{

    public string _Publication { get; set; }
    public Person _Author { get; set; }
    public DateTime _TimeOfPublication { get; set; }

    public Paper(string Publication, Person Author, DateTime PublicationDate)
    {
        _Publication = Publication;
        _Author = Author;
        _TimeOfPublication = PublicationDate;
    }
    public Paper() : this("No Publication", new Person(), new DateTime(2222, 01, 02)) { }

    public override string ToString()
    {
        return string.Format(_Publication, " ", _Author.ToString(), " ", _TimeOfPublication.ToString());
    }
}
