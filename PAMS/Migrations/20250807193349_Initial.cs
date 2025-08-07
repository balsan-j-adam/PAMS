using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAMS.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "All_departments",
                columns: table => new
                {
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Department_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_departments", x => x.Department_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "All_positions",
                columns: table => new
                {
                    Position_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Position_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_positions", x => x.Position_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Risk_Categories",
                columns: table => new
                {
                    Risk_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Risk_Category_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk_Categories", x => x.Risk_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Add_checklists",
                columns: table => new
                {
                    Checklist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Checklist_question = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Checklist_dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Add_checklists", x => x.Checklist_id);
                    table.ForeignKey(
                        name: "FK_Add_checklists_All_departments_Checklist_dept_id",
                        column: x => x.Checklist_dept_id,
                        principalTable: "All_departments",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "All_users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_pass = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_department_id = table.Column<int>(type: "int", nullable: true),
                    User_Position_id = table.Column<int>(type: "int", nullable: true),
                    User_Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_users", x => x.User_id);
                    table.ForeignKey(
                        name: "FK_All_users_All_departments_User_department_id",
                        column: x => x.User_department_id,
                        principalTable: "All_departments",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_All_users_All_positions_User_Position_id",
                        column: x => x.User_Position_id,
                        principalTable: "All_positions",
                        principalColumn: "Position_Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "All_Audit_universes",
                columns: table => new
                {
                    Audit_Universe_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Audit_Universe_Dept_Id = table.Column<int>(type: "int", nullable: false),
                    Audit_Universe_Risk_Id = table.Column<int>(type: "int", nullable: false),
                    Audit_Universe_Impact = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Audit_Universe_likelihood = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Audit_Universe_Risk_ratio = table.Column<int>(type: "int", nullable: false),
                    Audit_Universe_Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All_Audit_universes", x => x.Audit_Universe_Id);
                    table.ForeignKey(
                        name: "FK_All_Audit_universes_All_departments_Audit_Universe_Dept_Id",
                        column: x => x.Audit_Universe_Dept_Id,
                        principalTable: "All_departments",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_All_Audit_universes_Risk_Categories_Audit_Universe_Risk_Id",
                        column: x => x.Audit_Universe_Risk_Id,
                        principalTable: "Risk_Categories",
                        principalColumn: "Risk_Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Audit_Assigns_all",
                columns: table => new
                {
                    Audit_Assign_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Audit_Assign_Objective = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Audit_Assign_uni_id = table.Column<int>(type: "int", nullable: false),
                    Audit_Assign_auditor_id = table.Column<int>(type: "int", nullable: false),
                    Audit_Assign_start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Audit_Assign_end_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Audit_status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_Assigns_all", x => x.Audit_Assign_id);
                    table.ForeignKey(
                        name: "FK_Audit_Assigns_all_All_Audit_universes_Audit_Assign_uni_id",
                        column: x => x.Audit_Assign_uni_id,
                        principalTable: "All_Audit_universes",
                        principalColumn: "Audit_Universe_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_Assigns_all_All_users_Audit_Assign_auditor_id",
                        column: x => x.Audit_Assign_auditor_id,
                        principalTable: "All_users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Audit_questions",
                columns: table => new
                {
                    Audit_Questions_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuditId = table.Column<int>(type: "int", nullable: true),
                    Checklist_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_questions", x => x.Audit_Questions_Id);
                    table.ForeignKey(
                        name: "FK_Audit_questions_Add_checklists_Checklist_Id",
                        column: x => x.Checklist_Id,
                        principalTable: "Add_checklists",
                        principalColumn: "Checklist_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_questions_Audit_Assigns_all_AuditId",
                        column: x => x.AuditId,
                        principalTable: "Audit_Assigns_all",
                        principalColumn: "Audit_Assign_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Audit_tasks",
                columns: table => new
                {
                    all_task_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Assigned_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Due_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    task_Audit_Id = table.Column<int>(type: "int", nullable: false),
                    task_QuestionId = table.Column<int>(type: "int", nullable: false),
                    task_Assign_AuditorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_tasks", x => x.all_task_id);
                    table.ForeignKey(
                        name: "FK_Audit_tasks_All_users_task_Assign_AuditorId",
                        column: x => x.task_Assign_AuditorId,
                        principalTable: "All_users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_tasks_Audit_Assigns_all_task_Audit_Id",
                        column: x => x.task_Audit_Id,
                        principalTable: "Audit_Assigns_all",
                        principalColumn: "Audit_Assign_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audit_tasks_Audit_questions_task_QuestionId",
                        column: x => x.task_QuestionId,
                        principalTable: "Audit_questions",
                        principalColumn: "Audit_Questions_Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "task_Responses",
                columns: table => new
                {
                    Response_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Response_TaskId = table.Column<int>(type: "int", nullable: false),
                    Response_AuditeeId = table.Column<int>(type: "int", nullable: false),
                    Response_Finding = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Response_EvidenceFilePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Response_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Task_Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task_Responses", x => x.Response_Id);
                    table.ForeignKey(
                        name: "FK_task_Responses_All_users_Response_AuditeeId",
                        column: x => x.Response_AuditeeId,
                        principalTable: "All_users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_task_Responses_Audit_tasks_Response_TaskId",
                        column: x => x.Response_TaskId,
                        principalTable: "Audit_tasks",
                        principalColumn: "all_task_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Add_checklists_Checklist_dept_id",
                table: "Add_checklists",
                column: "Checklist_dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_All_Audit_universes_Audit_Universe_Dept_Id",
                table: "All_Audit_universes",
                column: "Audit_Universe_Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_All_Audit_universes_Audit_Universe_Risk_Id",
                table: "All_Audit_universes",
                column: "Audit_Universe_Risk_Id");

            migrationBuilder.CreateIndex(
                name: "IX_All_users_User_department_id",
                table: "All_users",
                column: "User_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_All_users_User_Position_id",
                table: "All_users",
                column: "User_Position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_Assigns_all_Audit_Assign_auditor_id",
                table: "Audit_Assigns_all",
                column: "Audit_Assign_auditor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_Assigns_all_Audit_Assign_uni_id",
                table: "Audit_Assigns_all",
                column: "Audit_Assign_uni_id");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_questions_AuditId",
                table: "Audit_questions",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_questions_Checklist_Id",
                table: "Audit_questions",
                column: "Checklist_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_tasks_task_Assign_AuditorId",
                table: "Audit_tasks",
                column: "task_Assign_AuditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_tasks_task_Audit_Id",
                table: "Audit_tasks",
                column: "task_Audit_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_tasks_task_QuestionId",
                table: "Audit_tasks",
                column: "task_QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_task_Responses_Response_AuditeeId",
                table: "task_Responses",
                column: "Response_AuditeeId");

            migrationBuilder.CreateIndex(
                name: "IX_task_Responses_Response_TaskId",
                table: "task_Responses",
                column: "Response_TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task_Responses");

            migrationBuilder.DropTable(
                name: "Audit_tasks");

            migrationBuilder.DropTable(
                name: "Audit_questions");

            migrationBuilder.DropTable(
                name: "Add_checklists");

            migrationBuilder.DropTable(
                name: "Audit_Assigns_all");

            migrationBuilder.DropTable(
                name: "All_Audit_universes");

            migrationBuilder.DropTable(
                name: "All_users");

            migrationBuilder.DropTable(
                name: "Risk_Categories");

            migrationBuilder.DropTable(
                name: "All_departments");

            migrationBuilder.DropTable(
                name: "All_positions");
        }
    }
}
