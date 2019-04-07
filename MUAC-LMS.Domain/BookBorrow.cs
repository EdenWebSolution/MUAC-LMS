using MUAC_LMS.Common.Enums;
using MUAC_LMS.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUAC_LMS.Domain
{
    public class BookBorrow : DomainBase
    {
        public int Id { get; set; }

        public StoreUser StoreUser { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }

        public DateTimeOffset FromDate { get; set; }

        public DateTimeOffset ToDate { get; set; }

        public BookBorrowStatus BookBorrowStatus { get; set; }
    }
}
