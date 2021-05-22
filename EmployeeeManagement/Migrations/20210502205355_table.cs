using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeeManagement.Migrations
{
    public partial class table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Department = table.Column<int>(nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "EmailId", "Name", "Number", "Photo" },
                values: new object[,]
                {
                    { 1, 1, "amangn12@gmail.com", "Aman Gupta", 987654, null },
                    { 2, 2, "dhruv.cs@gmail.com", "Dhruv Sharma", 56846, null },
                    { 3, 3, "harsh@gmail.com", "Harsh Goyal", 235468, null },
                    { 4, 3, "akhil@gmail.com", "Akhil Yadav", 123354, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
