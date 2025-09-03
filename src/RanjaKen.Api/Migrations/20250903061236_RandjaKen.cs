using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RanjaKen.Api.Migrations
{
    /// <inheritdoc />
    public partial class RandjaKen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Logo_Name = table.Column<string>(type: "text", nullable: true),
                    Logo_Url = table.Column<string>(type: "text", nullable: true),
                    Logo_ContentType = table.Column<string>(type: "text", nullable: true),
                    Logo_Extension = table.Column<string>(type: "text", nullable: true),
                    Logo_size = table.Column<int>(type: "integer", nullable: true),
                    EmailAdress = table.Column<string>(type: "text", nullable: true),
                    Slogan = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Pseudo = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: true),
                    Avatar_Name = table.Column<string>(type: "text", nullable: true),
                    Avatar_Url = table.Column<string>(type: "text", nullable: true),
                    Avatar_ContentType = table.Column<string>(type: "text", nullable: true),
                    Avatar_Extension = table.Column<string>(type: "text", nullable: true),
                    Avatar_size = table.Column<int>(type: "integer", nullable: true),
                    TeamId = table.Column<Guid>(type: "uuid", nullable: true),
                    TeamId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId1",
                        column: x => x.TeamId1,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId1",
                table: "Players",
                column: "TeamId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
