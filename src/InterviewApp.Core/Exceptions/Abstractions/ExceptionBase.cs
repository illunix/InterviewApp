namespace InterviewApp.Core.Exceptions.Abstractions;

public abstract class ExceptionBase : Exception
{
    protected ExceptionBase(string msg) : base(msg) { }
}