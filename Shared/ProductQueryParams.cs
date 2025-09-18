using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public SortingProducts Sort { get; set; }
        public string? Search { get; set; }

        #region Pagination
        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;

        private int _pageSize = DefaultPageSize;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value <= 0
                ? DefaultPageSize                   // fallback if invalid
                : Math.Min(value, MaxPageSize);     // clamp to MaxPageSize
        }

        #endregion
    }
}
