using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Exam_appilcation.Migrations
{
    /// <inheritdoc />
    public partial class INITTABLESINTODATABSE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ExamBot");

            migrationBuilder.CreateTable(
                name: "Examiners",
                schema: "ExamBot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    exam_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examiners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "ExamBot",
                columns: table => new
                {
                    FileId = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    FileUniqueId = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                schema: "ExamBot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    exam_name = table.Column<string>(type: "text", nullable: false),
                    FileId = table.Column<string>(type: "text", nullable: true),
                    examiner = table.Column<long>(type: "bigint", nullable: false),
                    start_datatime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_datatime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.id);
                    table.ForeignKey(
                        name: "FK_Exams_Examiners_examiner",
                        column: x => x.examiner,
                        principalSchema: "ExamBot",
                        principalTable: "Examiners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exams_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "ExamBot",
                        principalTable: "File",
                        principalColumn: "FileId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "ExamBot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    telegram_chat_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    exam_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Exams_exam_id",
                        column: x => x.exam_id,
                        principalSchema: "ExamBot",
                        principalTable: "Exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "ExamBot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    telgram_chat_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Students_id",
                        column: x => x.id,
                        principalSchema: "ExamBot",
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "ExamBot",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    nickname = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    is_premium = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.id);
                    table.ForeignKey(
                        name: "FK_Client_Users_user_id",
                        column: x => x.user_id,
                        principalSchema: "ExamBot",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_user_id",
                schema: "ExamBot",
                table: "Client",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_examiner",
                schema: "ExamBot",
                table: "Exams",
                column: "examiner",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_FileId",
                schema: "ExamBot",
                table: "Exams",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_exam_id",
                schema: "ExamBot",
                table: "Students",
                column: "exam_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client",
                schema: "ExamBot");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "ExamBot");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "ExamBot");

            migrationBuilder.DropTable(
                name: "Exams",
                schema: "ExamBot");

            migrationBuilder.DropTable(
                name: "Examiners",
                schema: "ExamBot");

            migrationBuilder.DropTable(
                name: "File",
                schema: "ExamBot");
        }
    }
}
