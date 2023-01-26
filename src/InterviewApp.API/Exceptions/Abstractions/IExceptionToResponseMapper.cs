namespace InterviewApp.API.Exceptions.Abstractions;

internal interface IExceptionToResponseMapper
{
    ExceptionResponse Map(Exception exception);
}