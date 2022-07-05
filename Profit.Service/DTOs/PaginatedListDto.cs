using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Service.DTOs
{
    public class PaginatedListDto<TItem>
    {
        public PaginatedListDto(List<TItem> items, int count, int PageSize, int pageIndex)
        {
            this.PageIndex = pageIndex;
            this.TotalPage = (int)Math.Ceiling(count / (double)PageSize);
            this.Items.AddRange(items);

        }
        public List<TItem> Items { get; set; } = new List<TItem>();
        public int TotalPage { get; set; }
        public int PageIndex { get; set; }
        public bool HasPrev => PageIndex > 1;
        public bool HasNext => PageIndex < TotalPage;
    }
}

