using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MUAC_LMS.Domain;
using MUAC_LMS.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUAC_LMS.Data
{
    public class MUACContext : IdentityDbContext<StoreUser>
    {
        public MUACContext(DbContextOptions<MUACContext> options) : base(options) { }

        public DbSet<MainCategory> MainCategories { get; set; }
    }
}
