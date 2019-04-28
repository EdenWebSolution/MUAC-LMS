using System;
using System.Collections.Generic;
using System.Text;

namespace MUAC_LMS.Common
{
    public class PaginationBase
    {
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
        public string SearchQuery { get; set; }
        public string OrderBy { get; set; }
    }
}
