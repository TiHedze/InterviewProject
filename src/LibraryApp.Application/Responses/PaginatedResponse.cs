namespace LibraryApp.Application.Responses
{
    using System.Collections.Generic;

    public class PaginatedResponse<T>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public List<T> Data { get; set; } = new List<T>();

        public PaginatedResponse(int page, int pageSize, List<T> data)
        {
            this.Page = page;
            this.PageSize = pageSize;
            this.Data = data;
        }

    }


}
