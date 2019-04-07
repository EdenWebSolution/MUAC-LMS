using System;
using System.Collections.Generic;
using System.Text;

namespace MUAC_LMS.Domain
{
    public class SubCategory : DomainBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MainCategory MainCategory { get; set; }

        public int MainCategoryId { get; set; }
    }
}
