namespace Lab1;

using System;

public class Exam
{
    public string Subject { get; set; }
    public int Grade { get; set; }
    public DateTime ExamDate { get; set; }

    public Exam(string subject, int grade, DateTime examDate)
    {
        Subject = subject;
        Grade = grade;
        ExamDate = examDate;
    }

    public Exam() : this("Default", 0, DateTime.MinValue) { }

    public override string ToString()
    {
        return $"{Subject} {Grade} {ExamDate.ToShortDateString()}";
    }
}