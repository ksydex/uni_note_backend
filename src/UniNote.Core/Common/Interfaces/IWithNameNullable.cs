namespace UniNote.Core.Common.Interfaces;

public interface IWithNameNullable
{
    string? Name { get; }
}

public interface IWithName
{
    string Name { get; set; }
}