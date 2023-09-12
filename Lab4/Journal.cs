namespace Lab4;

public class Journal
{
    private List<JournalEntry> journalEntries = new List<JournalEntry>();
    
    public void StudentsCountChangedHandler(object source, StudentListHandlerEventArgs args)
    {
        journalEntries.Add(new JournalEntry(args.CollectionName, args.ChangeInfo, args.StudentData));
    }

    public void StudentReferenceChangedHandler(object source, StudentListHandlerEventArgs args)
    {
        journalEntries.Add(new JournalEntry(args.CollectionName, args.ChangeInfo, args.StudentData));
    }

    public override string ToString()
    {
        var entries = "";
        foreach (var entry in journalEntries)
        {
            entries += entry.ToString() + "\n";
        }
        return entries.TrimEnd('\n');
    }
}