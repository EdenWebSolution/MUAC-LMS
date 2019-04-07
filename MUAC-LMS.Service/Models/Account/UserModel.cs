using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUAC_LMS.Service.Models.Account
{
    public class UserModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsTeacher { get; set; }
    }
}
