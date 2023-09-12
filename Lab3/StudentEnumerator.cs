using System.Collections;

namespace Lab3;

public class StudentEnumerator : IEnumerator<string>
{
    private Student student;
    private int position = -1;

    public StudentEnumerator(Student student)
    {
        this.student = student;
    }

    public string Current
    {
        get
        {
            if (position == -1 || position >= student.ExamList.Count)
                throw new InvalidOperationException();
            return (student.ExamList[position] as Exam).Subject;
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (position < student.ExamList.Count - 1)
        {
            position++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        position = -1;
    }
    
}