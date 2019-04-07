using System;
using System.Collections.Generic;
using System.Text;

namespace MUAC_LMS.Domain
{
    public abstract class DomainBase
    {
        public string CreatedById { get; set; }
        public string EditedById { get; set; }
        public DateTimeOffset? EditedOn { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
