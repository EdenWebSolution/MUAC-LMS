using MUAC_LMS.Common.Enums;
using MUAC_LMS.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUAC_LMS.Domain
{
    public class StudentGrade : DomainBase
    {   
        public int Id { get; set; }

        public StudentGrades StudentGrades { get; set; }

        public StoreUser StoreUser { get; set; }

    }
}
