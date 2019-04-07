using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MUAC_LMS.Domain.User
{
    public class StoreUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public bool IsTeacher { get; set; }

        public bool IsDeleted { get; set; }
    }
}
