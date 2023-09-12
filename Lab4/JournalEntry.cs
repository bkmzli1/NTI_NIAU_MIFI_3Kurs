namespace Lab4;

public class JournalEntry
{
    public string CollectionName { get; set; }
    public string ChangeType { get; set; }
    public string StudentInfo { get; set; }

    public JournalEntry(string collectionName, string changeType, Student student)
    {
        CollectionName = collectionName;
        ChangeType = changeType;
        StudentInfo = student != null ? student.ToString() : "No data";
    }

    public override string ToString()
    {
        return $"Collection: {CollectionName} - Change: {ChangeType} - Student: {StudentInfo}";
    }
}