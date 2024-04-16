using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.WebModel.Request
{
    public class PagedRequest
    {
        private int _pageSize;
        private int _pageNumber;
        private string? _sortBy;

        public bool isAscending { get; set; } = true;
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = (value < 1) ? 1 : value;
        }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value < 1) ? 1 : value;
        }
        public string? Search { get; set; }

        public string SortBy
        {
            get => _sortBy;
            set => _sortBy = value?.ToLower();
        }
    }
}
