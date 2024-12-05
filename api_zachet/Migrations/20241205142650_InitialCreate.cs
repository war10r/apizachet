using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_zachet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    personID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    surname = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phoneNumber = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.personID);
                    table.UniqueConstraint("AK_Persons_phoneNumber", x => x.phoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    tariffID = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    name = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.tariffID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacherID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    surname = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phoneNumber = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.teacherID)
                        .Annotation("SqlServer:FillFactor", 1);
                });

            migrationBuilder.CreateTable(
                name: "Signs",
                columns: table => new
                {
                    signID = table.Column<int>(type: "int", nullable: false),
                    personID = table.Column<int>(type: "int", nullable: false),
                    phoneNumber = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signs", x => x.signID);
                    table.ForeignKey(
                        name: "FK_Signs_Persons",
                        column: x => x.personID,
                        principalTable: "Persons",
                        principalColumn: "personID");
                    table.ForeignKey(
                        name: "FK_Signs_Persons1",
                        column: x => x.phoneNumber,
                        principalTable: "Persons",
                        principalColumn: "phoneNumber");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    lessonID = table.Column<int>(type: "int", nullable: false),
                    teacherID = table.Column<int>(type: "int", nullable: false),
                    tariffID = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    classroomNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.lessonID);
                    table.ForeignKey(
                        name: "FK_Lessons_Tariffs",
                        column: x => x.tariffID,
                        principalTable: "Tariffs",
                        principalColumn: "tariffID");
                    table.ForeignKey(
                        name: "FK_Lessons_Teacher",
                        column: x => x.teacherID,
                        principalTable: "Teacher",
                        principalColumn: "teacherID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_tariffID",
                table: "Lessons",
                column: "tariffID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_teacherID",
                table: "Lessons",
                column: "teacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons",
                table: "Persons",
                column: "phoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Signs_personID",
                table: "Signs",
                column: "personID");

            migrationBuilder.CreateIndex(
                name: "IX_Signs_phoneNumber",
                table: "Signs",
                column: "phoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Signs");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
