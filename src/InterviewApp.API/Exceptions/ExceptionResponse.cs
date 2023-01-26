using System.Net;

namespace InterviewApp.API.Exceptions;

internal sealed record ExceptionResponse(
    object Response,
    HttpStatusCode StatusCode
);
