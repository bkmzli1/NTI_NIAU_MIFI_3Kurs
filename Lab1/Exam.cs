﻿namespace Lab1;

using System;

public class Exam
{
    // Свойства класса
    public string Subject { get; set; } // Название предмета
    public int Grade { get; set; } // Оценка
    public DateTime ExamDate { get; set; } // Дата экзамена

    // Конструктор с параметрами для инициализации всех свойств класса
    public Exam(string subject, int grade, DateTime examDate)
    {
        Subject = subject;
        Grade = grade;
        ExamDate = examDate;
    }

    // Конструктор без параметров, инициализирующий все свойства класса значениями по умолчанию
    public Exam() : this("N/A", 0, DateTime.MinValue) 
    {
    }

    // Переопределение метода ToString()
    public override string ToString()
    {
        return $"Subject: {Subject}, Grade: {Grade}, Exam Date: {ExamDate.ToShortDateString()}";
    }
}