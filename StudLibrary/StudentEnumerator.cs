using System.Collections;

namespace StudLibrary;

class StudentEnumerator : IEnumerator
{
    private int position = -1;
    private List<string> subjects;

    public StudentEnumerator(List<Test> tests, List<Exam> exams)
    {
        var examSubjects = exams.Select(e => e.Subject);
        var testSubjects = tests.Select(t => t.Subject);
        
        subjects = examSubjects.Intersect(testSubjects).ToList();
    }

    public object Current
    {
        get 
        {
            if (position == -1 || position >= subjects.Count)
            {
                throw new InvalidOperationException();
            }
            return subjects[position];
        }
    }

    public bool MoveNext()
    {
        if (position < subjects.Count - 1)
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