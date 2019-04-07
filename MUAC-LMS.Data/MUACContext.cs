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

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<StudentGrade> StudentGrades { get; set; }

        public DbSet<BookBorrow> BookBorrows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasIndex(u => u.Identity)
                .IsUnique();
        }
    }
}
