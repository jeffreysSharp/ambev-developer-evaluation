namespace Ambev.DeveloperEvaluation.SalesApi.Common;

public class ApiResponseWithData<T> : ApiResponse
{
    public T? Data { get; set; }
}
