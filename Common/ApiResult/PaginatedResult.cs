namespace Common.ApiResult;

public class PaginatedResult<T>
{
    public PaginatedResult(IEnumerable<T> data)
    {
        Data = data;
        this.PageId = 1;
        this.Take = 20;
        this.EntitesCount = Data.Count();
        
        //checks for remaining data that is less than a page
        this.PagesCount = (Data.Count() % Take > 0) ? (Data.Count() / Take) + 1 : (Data.Count() / Take);
    }

    public PaginatedResult(IEnumerable<T> data, int pageId = 1, int take = 20, Dictionary<string, string> filter = null)
    {
        Data = data;
        PageId = pageId;
        Take = take;
        EntitesCount = Data.Count();
        PagesCount = (Data.Count() % Take > 0) ? (Data.Count() / Take) + 1 : (Data.Count() / Take);
        Filter = filter;
    }

    public IEnumerable<T> Data { get; set; }
    public int PageId { get; set; }
    public int Take { get; set; }
    public int EntitesCount { get; set; }
    public int PagesCount { get; set; }
    public Dictionary<string,string> Filter { get; set; }
}
