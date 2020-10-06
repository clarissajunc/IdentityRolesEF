using System;
using System.Collections.Generic;
using System.Text;
using IdentityRolesEF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityRolesEF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            var hasher = new PasswordHasher<IdentityUser>();

            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ADMIN_ID = "a4280b6a-0653-4cbd-a0p6-f1701e926e73";
            const string BASIC_ID = "b4280b6a-0613-4ciod-a9e6-f1702f926e73";
            const string ROLE_BASIC_ID = "c9280b6a-0613-4cbd-a9e6-f1701e926e73";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ADMIN_ID
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "basic",
                NormalizedName="BASIC",
                Id = ROLE_BASIC_ID
            });
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                UserName="admin@admin.com",
                NormalizedUserName = "admin@admin.com".ToUpper(),
                NormalizedEmail = "admin@admin.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "admin")
            });
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = BASIC_ID,
                Email = "basic@basic.com",
                UserName = "basic@basic.com",
                NormalizedUserName = "basic@basic.com".ToUpper(),
                NormalizedEmail = "basic@basic.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "basic")

            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ADMIN_ID,
                UserId = ADMIN_ID
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_BASIC_ID,
                UserId = BASIC_ID
            });
            builder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId=1,
                FirstName="admin",
                LastName="admin",
                UserId=ADMIN_ID
            });
            builder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "basic",
                LastName = "basic",
                UserId = BASIC_ID
            });
        }
    }
}
