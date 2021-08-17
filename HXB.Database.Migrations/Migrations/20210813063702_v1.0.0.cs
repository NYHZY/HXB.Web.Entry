using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HXB.Database.Migrations.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sys_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loginname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    realname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    sex = table.Column<int>(type: "int", nullable: false),
                    idno = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    nationality = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys_user", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sys_user");
        }
    }
}
