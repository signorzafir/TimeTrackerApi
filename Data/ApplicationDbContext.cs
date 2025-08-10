using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TimeTrackerAPI.Constants;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkEntry> WorkEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Employee User Relation
            builder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserId)
                ;

            //Seeding Roles
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole
                    {
                        Name = ApiRoles.User,
                        NormalizedName = ApiRoles.User.ToUpper(),
                        Id = "11163a23-ce1b-4809-b39d-8f153489a4cb"
                    },
                    new IdentityRole
                    {
                        Name = ApiRoles.Administrator,
                        NormalizedName = ApiRoles.Administrator.ToUpper(),
                        Id = "6880cbe1-c055-455e-b6ca-c0060ddc28c2"
                    }
                );

            //Seeding Users
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData
                (
                    new ApplicationUser
                    {
                        Id= "78158e67-cea7-4398-9304-715aebaff2ae",
                        Email="admin@timetracker.com",
                        NormalizedEmail="ADMIN@TIMETRACKER.COM",
                        UserName= "admin@timetracker.com",
                        NormalizedUserName= "ADMIN@TIMETRACKER.COM",
                        FullName="System Admin",
                        PasswordHash = "AQAAAAIAAYagAAAAEDoBzQ5PB7kefERvqTpxoTkmkZrm1MfQrIlC76PtKI5pCAeUe0a4zBMTwi4Ah8Ibzw==",
                        EmailConfirmed=true
                    },
                    new ApplicationUser
                    {
                        Id = "51841e02-fa5b-4e18-9eef-b3f78eefff51",
                        Email = "alphauser@timetracker.com",
                        NormalizedEmail = "ALPHAUSER@TIMETRACKER.COM",
                        UserName = "alphauser@timetracker.com",
                        NormalizedUserName = "ALPHAUSER@TIMETRACKER.COM",
                        FullName = "Alpha User",
                        PasswordHash = "AQAAAAIAAYagAAAAEDoBzQ5PB7kefERvqTpxoTkmkZrm1MfQrIlC76PtKI5pCAeUe0a4zBMTwi4Ah8Ibzw==",
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "397752af-b4a2-46fe-bef1-22ce604f9337",
                        Email = "bravouser@timetracker.com",
                        NormalizedEmail = "BRAVOUSER@TIMETRACKER.COM",
                        UserName = "bravouser@timetracker.com",
                        NormalizedUserName = "BRAVOUSER@TIMETRACKER.COM",
                        FullName = "Bravo User",
                        PasswordHash = "AQAAAAIAAYagAAAAEDoBzQ5PB7kefERvqTpxoTkmkZrm1MfQrIlC76PtKI5pCAeUe0a4zBMTwi4Ah8Ibzw==",
                        EmailConfirmed = true
                    }
                );

            //Seeding UserRoles
            builder.Entity<IdentityUserRole<string>>().HasData
                (
                    //Admin = RegularUser
                    new IdentityUserRole<string>
                    {
                        UserId= "78158e67-cea7-4398-9304-715aebaff2ae",
                        RoleId= "11163a23-ce1b-4809-b39d-8f153489a4cb"
                    },
                    //Admin = Admin
                    new IdentityUserRole<string>
                    {
                        UserId = "78158e67-cea7-4398-9304-715aebaff2ae",
                        RoleId = "6880cbe1-c055-455e-b6ca-c0060ddc28c2"
                    },
                    //AlphaUser = User
                    new IdentityUserRole<string>
                    {
                        UserId = "51841e02-fa5b-4e18-9eef-b3f78eefff51",
                        RoleId = "11163a23-ce1b-4809-b39d-8f153489a4cb"
                    },
                    //BravoUser = User
                    new IdentityUserRole<string>
                    {
                        UserId = "397752af-b4a2-46fe-bef1-22ce604f9337",
                        RoleId = "11163a23-ce1b-4809-b39d-8f153489a4cb"
                    }
                );
        }
    }
}
