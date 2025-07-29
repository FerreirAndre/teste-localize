namespace CnpjControl.Domain.Models.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name) : base($"User {name} not found.")
    {
    }
}