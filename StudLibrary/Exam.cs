namespace StudLibrary;

class Exam : IDateAndCopy
{
    public object DeepCopy()
    {
        return this.MemberwiseClone();
    }

    public DateTime Date { get; set; }
    public int Mark { get; set; }
    public string Subject { get; set; }
}