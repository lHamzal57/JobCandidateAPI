using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobCandidate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BestTimeToCall_Start = table.Column<TimeSpan>(type: "time", nullable: false),
                    BestTimeToCall_End = table.Column<TimeSpan>(type: "time", nullable: false),
                    LinkedInProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitHubProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreeTextComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    MustDeletedPhysical = table.Column<bool>(type: "bit", nullable: true),
                    FirstModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstModifiedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifiedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "credentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credentials", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "credentials",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("acf7595c-df33-4c68-8688-b8a39c9476e8"), "AQAAAAIAAYagAAAAEBiKTrtI4t9zT+V0Rb5SQn2jBqLa10V1vaxeXW01ipw+DjKy50phuxRgVwaGzTSIxA==", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_Email",
                table: "Candidates",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "credentials");
        }
    }
}
