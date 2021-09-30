using Microsoft.EntityFrameworkCore.Migrations;

namespace Payrol.Migrations
{
    public partial class addStaffToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffAge = table.Column<int>(type: "int", nullable: false),
                    StaffDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Department_StaffDepartmentId",
                        column: x => x.StaffDepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryBasic = table.Column<double>(type: "float", nullable: false),
                    SalaryTransportAllowance = table.Column<double>(type: "float", nullable: false),
                    SalaryPerformanceAllowance = table.Column<double>(type: "float", nullable: false),
                    SalaryOvertime = table.Column<double>(type: "float", nullable: false),
                    SalaryKwsp = table.Column<double>(type: "float", nullable: false),
                    SalaryStaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_Salary_Staff_SalaryStaffId",
                        column: x => x.SalaryStaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salary_SalaryStaffId",
                table: "Salary",
                column: "SalaryStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StaffDepartmentId",
                table: "Staff",
                column: "StaffDepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
