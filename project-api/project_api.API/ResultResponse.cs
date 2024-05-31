namespace project_api.API;

public class ResultResponse<T>
{
    public T? Data { get; set; }
    public string? Error { get; set; }
    public int Total { get; set; }
    public int StatusCode { get; set; }

    internal ResultResponse(T data, string error, int statusCode)
    {
        Data = data;
        Error = error;
        Total = default;
        StatusCode = statusCode;
    }

    internal ResultResponse(T data, int statusCode)
    {
        Data = data;
        Error = default;
        Total = default;
        StatusCode = statusCode;
    }

    internal ResultResponse(T data, int total, int statusCode)
    {
        Data = data;
        Error = default;
        Total = total;
        StatusCode = statusCode;
    }

    internal ResultResponse(T data, string? error, int total, int statusCode)
    {
        Data = data;
        Error = error;
        Total = total;
        StatusCode = statusCode;
    }
}
