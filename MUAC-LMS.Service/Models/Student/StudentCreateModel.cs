using MUAC_LMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUAC_LMS.Service.Models.Student
{
    public class StudentCreateModel
    {
        [Required]
        public string Name { get; set; }
        public StudentGrades StudentGrades { get; set; }
    }
}
