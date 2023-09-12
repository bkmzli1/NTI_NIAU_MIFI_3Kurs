namespace Lab4;

using System.Collections.Generic;

public class StudentCollection
{
    private List<Student> students = new List<Student>();

    public string CollectionName { get; set; }

    // Event that fires when the Student Count Changes
    public event StudentListHandler StudentsCountChanged;
    
    // Event that fires when a Student Reference Changes
    public event StudentListHandler StudentReferenceChanged;

    // Invoker for StudentsCountChanged Event
    protected virtual void OnStudentsCountChanged(StudentListHandlerEventArgs e)
    {
        StudentsCountChanged?.Invoke(this, e);
    }
    
    // Invoker for StudentReferenceChanged Event
    protected virtual void OnStudentReferenceChanged(StudentListHandlerEventArgs e)
    {
        StudentReferenceChanged?.Invoke(this, e);
    }

    public void AddDefaults()
    {
        // add default student
        OnStudentsCountChanged(new StudentListHandlerEventArgs(CollectionName, "Add", null));
    }

    public void AddStudents(params Student[] students)
    {
        this.students.AddRange(students);
        OnStudentsCountChanged(new StudentListHandlerEventArgs(CollectionName, "Add", null));
    }

    public bool Remove(int j) 
    {
        if (j < 0 || j >= students.Count) return false;
        
        var student = students[j];
        students.RemoveAt(j);
        OnStudentsCountChanged(new StudentListHandlerEventArgs(CollectionName, "Remove", student));

        return true;
    }

    public Student this[int i]
    {
        get
        {
            return students[i];
        }
        set
        {
            students[i] = value;
            OnStudentReferenceChanged(new StudentListHandlerEventArgs(CollectionName, "Change", value));
        }
    }

}