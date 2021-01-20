using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp2.Shared
{
   public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        public int QuantityperPage { get; set; } = 10;
    }
}
