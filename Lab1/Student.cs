namespace Lab1;

using System;
using System.Collections.Generic;


public class Student
{
    private Person personData;
    private Education educationForm;
    private int groupNumber;
    private List<Exam> examList;

    public Student(Person personData, Education educationForm, int groupNumber)
    {
        this.personData = personData;
        this.educationForm = educationForm;
        this.groupNumber = groupNumber;
        this.examList = new List<Exam>();
    }

    public Student()
        : this(new Person(), Education.Bachelor, 0)
    {
    }

    public Person PersonData
    {
        get => personData;
        set => personData = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Person PersonData1
    {
        get => personData;
        set => personData = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Education EducationForm
    {
        get => educationForm;
        set => educationForm = value;
    }

    public int GroupNumber
    {
        get => groupNumber;
        set => groupNumber = value;
    }

    public List<Exam> ExamList
    {
        get => examList;
        set => examList = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void AddExams(params Exam[] exams)
    {
        foreach (var exam in exams)
        {
            examList.Add(exam);
        }
    }

    public string ToShortString()
    {
        return
            $"Student: {personData.Name} {personData.Surname}, Education: {educationForm}, Group: {groupNumber}";
    }

    public bool this[Education index]
    {
        get { return educationForm == index; }
    }

    public void addTests(params Test[] tests)
    {
        foreach (var exam in tests)
        {
            examList.Add(exam);
        }
    }
}