using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAMS.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_All_users_All_departments_User_department_id",
                table: "All_users");

            migrationBuilder.DropForeignKey(
                name: "FK_All_users_All_positions_User_Position_id",
                table: "All_users");

            migrationBuilder.AlterColumn<int>(
                name: "User_department_id",
                table: "All_users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "User_Position_id",
                table: "All_users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "User_pass",
                table: "All_users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_All_users_All_departments_User_department_id",
                table: "All_users",
                column: "User_department_id",
                principalTable: "All_departments",
                principalColumn: "Department_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_All_users_All_positions_User_Position_id",
                table: "All_users",
                column: "User_Position_id",
                principalTable: "All_positions",
                principalColumn: "Position_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_All_users_All_departments_User_department_id",
                table: "All_users");

            migrationBuilder.DropForeignKey(
                name: "FK_All_users_All_positions_User_Position_id",
                table: "All_users");

            migrationBuilder.DropColumn(
                name: "User_pass",
                table: "All_users");

            migrationBuilder.AlterColumn<int>(
                name: "User_department_id",
                table: "All_users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User_Position_id",
                table: "All_users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_All_users_All_departments_User_department_id",
                table: "All_users",
                column: "User_department_id",
                principalTable: "All_departments",
                principalColumn: "Department_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_All_users_All_positions_User_Position_id",
                table: "All_users",
                column: "User_Position_id",
                principalTable: "All_positions",
                principalColumn: "Position_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
