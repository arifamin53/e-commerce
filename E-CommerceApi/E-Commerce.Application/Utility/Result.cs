namespace E_Commerce.Application.Utility;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
public class Result<T>
{
    public T? Value { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public ProblemDetails ProblemDetails{ get; set; }
    public bool IsSuccess => ProblemDetails is null;

    public Result(T? value=default,int statusCode=StatusCodes.Status200OK)
    {
        Value = value;
        StatusCode = statusCode;    
    }

    public Result(ProblemDetails problemDetails)
    {
           ProblemDetails = problemDetails; 
    }

    public static Result<T> Success(T? value)
    {
        return new Result<T>()
        {
            Value = value
        };
    }

    public static Result<T> Success(T? value,string message)
    {
        return new Result<T>()
        {
            Value = value,
            Message=message 
        };
    }

    public static Result<T> Success(string message,int statusCode)
    {
        return new Result<T>()
        {
            Message=message,
            StatusCode=statusCode
        };

    }

    public static Result<T> Success(T? value,int statusCode)
    {
        return new Result<T>()
        {
            Value = value,
             StatusCode = statusCode
        };
    }

    public static Result<T> Success(T? value,string message,int statusCode)
    {
        return new Result<T>()
        {
            Value = value,
            Message=message,
            StatusCode = statusCode
        };
    }

    public static Result<T> Failure(ProblemDetails problemDetails)
    {
        var problem = new ProblemDetails()
        {
            Title = problemDetails.Title,
            Status=problemDetails.Status,
            Detail=problemDetails.Detail,
            Instance=problemDetails.Instance,
            Type=problemDetails.Type,
        };
        return new Result<T>(problem);
    }

    public static Result<T> Failure(string message,int statusCode=StatusCodes.Status500InternalServerError)
    {
        var problem = new ProblemDetails()
        {
            Title = message,
            Status = statusCode,
            Detail ="",
            Instance ="",
            Type ="",
        };
        return new Result<T>(problem);
    }
}
