// <auto-generated />
using EmployeeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeeManagement.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    [Migration("20210502205355_table")]
    partial class table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeeManagement.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Department");

                    b.Property<string>("EmailId");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 1,
                            EmailId = "amangn12@gmail.com",
                            Name = "Aman Gupta",
                            Number = 987654
                        },
                        new
                        {
                            Id = 2,
                            Department = 2,
                            EmailId = "dhruv.cs@gmail.com",
                            Name = "Dhruv Sharma",
                            Number = 56846
                        },
                        new
                        {
                            Id = 3,
                            Department = 3,
                            EmailId = "harsh@gmail.com",
                            Name = "Harsh Goyal",
                            Number = 235468
                        },
                        new
                        {
                            Id = 4,
                            Department = 3,
                            EmailId = "akhil@gmail.com",
                            Name = "Akhil Yadav",
                            Number = 123354
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
