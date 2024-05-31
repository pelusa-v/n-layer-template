using Microsoft.AspNetCore.Mvc;

namespace project_api.API;

public class ResultResponse : ControllerBase
{
    public static ObjectResult Success<T>(T? data)
    {
        var res = new ResultResponse<T>(data, StatusCodes.Status200OK);
        return new ObjectResult(res)
        {
            StatusCode = StatusCodes.Status200OK,
        };
    }

    public static ObjectResult Success<T>(T? data, int total)
    {
        var res = new ResultResponse<T>(data, total, StatusCodes.Status200OK);
        return new ObjectResult(res)
        {
            StatusCode = StatusCodes.Status200OK,
        };
    }

    public static ObjectResult Created<T>(T? data)
    {
        var res = new ResultResponse<T>(data, StatusCodes.Status201Created);
        return new ObjectResult(res)
        {
            StatusCode = StatusCodes.Status201Created,
        };
    }

    public static ObjectResult NotFound<T>(T? data, string error)
    {
        var res = new ResultResponse<T>(data, error, StatusCodes.Status404NotFound);
        return new ObjectResult(res)
        {
            StatusCode = StatusCodes.Status404NotFound,
        };
    }

    public static ObjectResult InternalError<T>(T? data, string error)
    {
        var res = new ResultResponse<T>(data, error, StatusCodes.Status500InternalServerError);
        return new ObjectResult(res)
        {
            StatusCode = StatusCodes.Status500InternalServerError,
        };
    }

    public static ResultResponse<T> Unauthorized<T>(T? data, string error)
    {
        return new ResultResponse<T>(data, error, StatusCodes.Status401Unauthorized);
    }
}
