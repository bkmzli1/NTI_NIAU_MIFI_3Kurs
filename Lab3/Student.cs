namespace Lab3;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Student : Person, IDateAndCopy, IEnumerable
{
    private Education education;
    private int groupNumber;

    private ArrayList exams = new ArrayList();
    private ArrayList tests = new ArrayList();

    // Инициализаторы
    public Student(Person person, Education educationForm, int groupNumber) : base(person.Name, person.Surname,
        person.Date)
    {
        this.education = educationForm;
        this.GroupNumber = groupNumber;
        this.exams = new ArrayList();
        this.tests = new ArrayList();
    }

    public Student() : this(new Person(), Education.Specialist, 1)
    {
    }

    // Свойства
    public Person PersonData
    {
        get { return (Person)this.DeepCopy(); }
        set
        {
            this.Name = value.Name;
            this.Surname = value.Surname;
        }
    }

    public Education EducationForm
    {
        get { return education; }
        set { education = value; }
    }

    public int GroupNumber
    {
        get { return groupNumber; }
        set
        {
            if (value < 100 || value > 600)
                try
                {
                    throw new ArgumentOutOfRangeException("GroupNumber must be between 100 and 599");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error\n"+e);
                }
            else
                groupNumber = value;
        }
    }

    public ArrayList ExamList
    {
        get { return exams; }
        set { exams = value; }
    }

    public ArrayList TestList
    {
        get { return tests; }
        set { tests = value; }
    }

    public double AverageGrade
    {
        get { return exams.Count > 0 ? exams.Cast<Exam>().Average(e => e.Grade) : 0; }
    }

    // Методы
    public void AddExams(params Exam[] exams)
    {
        foreach (var exam in exams)
            this.exams.Add(exam);
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}\nEducation: {education}\nGroupNumber: {groupNumber}\nExams: {string.Join(", ", exams.Cast<Exam>().Select(e => e.ToString()))}\nTests: {string.Join(", ", tests.Cast<Test>().Select(t => t.ToString()))}";
    }

    public virtual string ToShortString()
    {
        return $"{base.ToString()}\nEducation: {education}\nGroupNumber: {groupNumber}\nAverage grade: {AverageGrade}";
    }

    // IDateAndCopy
    public object DeepCopy()
    {
        var copy = new Student(this, this.education, this.groupNumber);
        copy.exams = (ArrayList)this.exams.Clone();
        copy.tests = (ArrayList)this.tests.Clone();
        return copy;
    }

    public DateTime Date { get; set; }

    // Итераторы
    public IEnumerable ExamsAndTests
    {
        get
        {
            foreach (Exam exam in exams)
                yield return exam;

            foreach (Test test in tests)
                yield return test;
        }
    }

    public IEnumerable GetExamsMoreThan(int grade)
    {
        foreach (Exam exam in exams)
            if (exam.Grade > grade)
                yield return exam;
    }

    public bool this[Education index] //индексатор булевского типа (только с методом get)
    {
        get { return EducationForm == index; }
    }
    public IEnumerator<string> GetEnumerator()
    {
        return new StudentEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public IEnumerable GetPassedExamsAndTests()
    {
        foreach (Exam exam in exams)
            if (exam.Grade > 2)
                yield return exam;

        foreach (Test test in tests)
            if (test.IsPassed)
                yield return test;
    }
    public IEnumerable GetPassedExamsAndTestsLinked()
    {
        foreach (Test test in tests)
        {
            if (test.IsPassed)
            {
                foreach (Exam exam in exams)
                {
                    if (exam.Grade > 2 && exam.Subject == test.Subject)
                    {
                        yield return test;
                        break;
                    }
                }
            }
        }
    }
}