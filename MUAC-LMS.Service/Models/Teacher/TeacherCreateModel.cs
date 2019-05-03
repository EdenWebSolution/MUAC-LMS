using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUAC_LMS.Service.Models.Teacher
{
    public class TeacherCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}
