namespace Lab3;

public interface IDateAndCopy
{
    object DeepCopy();
    DateTime Date { get; set; }
}