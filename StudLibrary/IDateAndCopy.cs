namespace StudLibrary;

public interface IDateAndCopy
{
    object DeepCopy();
    DateTime Date { get; set; }
}
