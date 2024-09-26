namespace Domain.Common;

public class PaginationResultResponse<T>
{
    public T? Data { get; set; }
    public int Total { get; set; } = 0;
    public int Page { get; set; } = 0;
}