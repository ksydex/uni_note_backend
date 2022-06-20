namespace UniNote.Core.Common.Interfaces;

public interface IWithId<T>
{
    T Id { get; set; }
}