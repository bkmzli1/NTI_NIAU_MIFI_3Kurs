using System.Collections;

namespace StudLibrary;

class Student : Person, IDateAndCopy
{
    private Education educationLevel;
    private int groupNumber;
    private List<Test> tests;
    private List<Exam> exams;

    public Student(Person person, Education level, int group) : base(person.Name, person.Surname, person.DateOfBirth)
    {
        this.educationLevel = level;
        this.groupNumber = group;
        this.tests = new List<Test>();
        this.exams = new List<Exam>();
    }

    public override bool Equals(object obj)
    {
        if (obj is Student)
        {
            var other = obj as Student;
            return base.Equals(other) && this.educationLevel == other.educationLevel &&
                   this.groupNumber == other.groupNumber && this.tests.SequenceEqual(other.tests) &&
                   this.exams.SequenceEqual(other.exams);
        }

        return false;
    }

    public static bool operator ==(Student left, Student right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Student left, Student right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode() + educationLevel.GetHashCode() + groupNumber.GetHashCode() +
               tests.GetHashCode() + exams.GetHashCode();
    }

    public object DeepCopy()
    {
        var copy = new Student(this, this.educationLevel, this.groupNumber);
        copy.tests = tests.ToList();
        copy.exams = exams.ToList();
        return copy;
    }

    public DateTime Date { get; set; }

    public IEnumerable PassedExams()
    {
        foreach (var exam in exams)
        {
            if (exam.Mark > 2)
            {
                yield return exam;
            }
        }
    }
    public IEnumerable PassedTestsAndExams()
    {
        foreach (var test in tests)
        {
            if (test.IsPassed && exams.Any(e => e.Subject == test.Subject && e.Mark > 2))
            {
                yield return test;
            }
        }
    }
    public IEnumerator GetEnumerator()
    {
        return new StudentEnumerator(tests, exams);
    }
//дада мне лень было делать конструктор
    public void addExam(int a,DateTime dateTime,String aubject)
    {
        Exam exam = new Exam();
        exam.Mark = a; exam.Date =dateTime; exam.Subject = aubject;
        exams.Add(exam);
    }
    public void addTest(String s,Boolean b)
    {
        Test test = new Test();
        test.Subject =  s;
        test.IsPassed = b;
        tests.Add(test);
    }
}