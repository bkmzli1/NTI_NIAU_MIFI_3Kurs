namespace Lab2;

public interface IDateAndCopy
{
    object DeepCopy();
    DateTime Date { get; set; }
}