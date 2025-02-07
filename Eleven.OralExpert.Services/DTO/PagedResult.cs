namespace Eleven.OralExpert.API.DTOs;

public class PagedResult<T>
{
    public int CurrentPage { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public IEnumerable<T> Data { get; }

    public PagedResult(IEnumerable<T> data, int currentPage, int pageSize, int totalCount)
    {
        Data = data;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
    }
}
