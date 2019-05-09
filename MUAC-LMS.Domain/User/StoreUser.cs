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

        public string CreatedById { get; set; }
        public string EditedById { get; set; }
        public DateTimeOffset? EditedOn { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
