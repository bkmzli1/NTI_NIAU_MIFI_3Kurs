namespace Lab1;

using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private Person personData; //закрытое поле типа Person, в котором хранятся данные студента;
    private Education educationForm; //закрытое поле типа Education для информации о форме обучения;
    private int groupNumber; //закрытое поле типа int для номера группы;
    private List<Exam> examsList = new List<Exam>(); //закрытое поле типа List<Exam> для информации об экзаменах, которые сдал студент.

    public Student(Person personData, Education educationForm, int groupNumber) // конструктор c параметрами типа Person, Education, int для инициализации соответствующих полей класса;
    {
        this.personData = personData;
        this.educationForm = educationForm;
        this.groupNumber = groupNumber;
    }

    public Student() : this(new Person(), Education.Specialist, 1) { } // конструктор без параметров, инициализирующий поля класса значениями по умолчанию.

    // свойства c методами get и set
    public Person PersonData
    {
        get { return personData; }
        set { personData = value; }
    }

    public Education EducationForm
    {
        get { return educationForm; }
        set { educationForm = value; }
    }

    public int GroupNumber
    {
        get { return groupNumber; }
        set { groupNumber = value; }
    }

    public Exam[] ExamsList
    {
        get { return examsList.ToArray(); }
        set { examsList = value.ToList(); }
    }

    public double AverageGrade //свойство типа double ( только с методом get), в котором вычисляется средний балл как среднее значение оценок в списке сданных экзаменов;
    {
        get 
        { 
            if (examsList.Count == 0)
            {
                return 0; //или другое значение по умолчанию
            }
            return examsList.Average(e => e.Grade); 
        }
    }

    public bool this[Education index] //индексатор булевского типа (только с методом get)
    {
        get { return educationForm == index; }
    }

    public void AddExams(params Exam[] newExams) //метод для добавления элементов в список экзаменов;
    {
        examsList.AddRange(newExams);
    }

    public override string ToString() //перегруженная версия виртуального метода string ToString()
    {
        return $"Person Data: {personData}, Education Form: {educationForm}, Group Number: {groupNumber}, Exams: {string.Join(", ", examsList)}";
    }

    public virtual string ToShortString() //виртуальный метод string ToShortString()
    {
        return $"Person Data: {personData}, Education Form: {educationForm}, Group Number: {groupNumber}, Average Grade: {AverageGrade}";
    }
}