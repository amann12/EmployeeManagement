using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeeManagement.Models
{
    public class AppDbcontext : IdentityDbContext
    {
        public AppDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Aman Gupta",
                    EmailId = "amangn12@gmail.com",
                    Number = 987654,
                    Department = dept.IT

                },
                new Employee
                {
                    Id = 2,
                    Name = "Dhruv Sharma",
                    EmailId = "dhruv.cs@gmail.com",
                    Number = 56846,
                    Department = dept.CSE
                },
                new Employee
                {
                    Id = 3,
                    Name = "Harsh Goyal",
                    EmailId = "harsh@gmail.com",
                    Number = 235468,
                    Department = dept.Marketing

                },
                new Employee
                {
                    Id = 4,
                    Name = "Akhil Yadav",
                    EmailId = "akhil@gmail.com",
                    Number = 123354,
                    Department = dept.Marketing

                }
                );
        }
    }
}
