﻿using Booky.API.Models.Response;
using Booky.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Booky.API.Middlewares;

public class ArgumentIsNotValidExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        if (exception is not ArgumentIsNotValidException argumentIsNotValidException)
            return false;

        await httpContext.Response.WriteAsJsonAsync(new Response
        {
            StatusCode = argumentIsNotValidException.StatusCode,
            Message = argumentIsNotValidException.Message,
        });

        return true;
    }
}
