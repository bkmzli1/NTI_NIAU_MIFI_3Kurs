namespace Lab4;

using System;

using System;

public class StudentListHandlerEventArgs : EventArgs
{
    public string CollectionName { get; set; }
    public string ChangeInfo { get; set; }
    public Student StudentData { get; set; }
    public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);
    public StudentListHandlerEventArgs(string collectionName, string changeInfo, Student student)
    {
        CollectionName = collectionName;
        ChangeInfo = changeInfo;
        StudentData = student;
    }

    public override string ToString()
    {
        return $"Student List: {CollectionName} - Action: {ChangeInfo} - Student: {StudentData?.Name}";
    }
}