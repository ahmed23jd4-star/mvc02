using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addrese_buildnumber = table.Column<int>(type: "int", nullable: false),
                    addrese_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addrese_street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    joindate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.id);
                    table.CheckConstraint("checkemail", "email like '_%@_%._%'");
                    table.CheckConstraint("checkphone", "len(phone) = 11 and (phone like '010%' or phone like '011%' or phone like '012%' or phone like '015%')");
                });

            migrationBuilder.CreateTable(
                name: "plans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    describtion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    durationdays = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    isactive = table.Column<bool>(type: "bit", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.id);
                    table.CheckConstraint("plandurationdays", "durationdays between 1 and 365");
                });

            migrationBuilder.CreateTable(
                name: "trainers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hiredate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    specailisty = table.Column<int>(type: "int", nullable: false),
                    addrese_buildnumber = table.Column<int>(type: "int", nullable: false),
                    addrese_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addrese_street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainers", x => x.id);
                    table.CheckConstraint("checkemail1", "email like '_%@_%._%'");
                    table.CheckConstraint("checkphone1", "len(phone) = 11 and (phone like '010%' or phone like '011%' or phone like '012%' or phone like '015%')");
                });

            migrationBuilder.CreateTable(
                name: "memberships",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    planid = table.Column<int>(type: "int", nullable: false),
                    memberid = table.Column<int>(type: "int", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberships", x => x.id);
                    table.ForeignKey(
                        name: "FK_memberships_members_memberid",
                        column: x => x.memberid,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_memberships_plans_planid",
                        column: x => x.planid,
                        principalTable: "plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    describtaion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trainerid = table.Column<int>(type: "int", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    updatedate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessions", x => x.id);
                    table.CheckConstraint("sessioncapacity", "capacity between 1 and 25");
                    table.CheckConstraint("sessionenddate", "enddate > startdate");
                    table.ForeignKey(
                        name: "FK_sessions_trainers_trainerid",
                        column: x => x.trainerid,
                        principalTable: "trainers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_members_email",
                table: "members",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_members_phone",
                table: "members",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_memberships_memberid",
                table: "memberships",
                column: "memberid");

            migrationBuilder.CreateIndex(
                name: "IX_memberships_planid",
                table: "memberships",
                column: "planid");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_trainerid",
                table: "sessions",
                column: "trainerid");

            migrationBuilder.CreateIndex(
                name: "IX_trainers_email",
                table: "trainers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainers_phone",
                table: "trainers",
                column: "phone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "memberships");

            migrationBuilder.DropTable(
                name: "sessions");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "plans");

            migrationBuilder.DropTable(
                name: "trainers");
        }
    }
}
