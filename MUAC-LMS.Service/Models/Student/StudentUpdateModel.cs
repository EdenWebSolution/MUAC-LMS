using MUAC_LMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUAC_LMS.Service.Models.Student
{
    public class StudentUpdateModel
    {
        public string StoreUserId { get; set; }
        public string Name { get; set; }
        public StudentGrades StudentGrades { get; set; }
    }
}
