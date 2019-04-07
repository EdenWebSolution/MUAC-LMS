using System;
using System.Collections.Generic;
using System.Text;

namespace MUAC_LMS.Domain
{
    public class Book : DomainBase
    {
        public int Id { get; set; }
        public string Identity { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
    }
}
