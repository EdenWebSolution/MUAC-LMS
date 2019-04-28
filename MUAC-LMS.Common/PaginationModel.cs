using System;
using System.Collections.Generic;
using System.Text;

namespace MUAC_LMS.Common
{
    public class PaginationModel<T> where T : class
    {
        public int TotalRecords { get; set; }
        public IEnumerable<T> Details { get; set; }
        public dynamic ExtensionData { get; set; }
    }
}
