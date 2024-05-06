using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hnh.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "properties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Right = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reports_PropertyId",
                table: "reports",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_reports_UserId",
                table: "reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_properties_CategoryId",
                table: "properties",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_properties_DistrictId",
                table: "properties",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_properties_UserId",
                table: "properties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_properties_UsersUserId",
                table: "properties",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_PropertyId",
                table: "comments",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_properties_PropertyId",
                table: "comments",
                column: "PropertyId",
                principalTable: "properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_properties_Districts_DistrictId",
                table: "properties",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_properties_User_UserId",
                table: "properties",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_properties_categories_CategoryId",
                table: "properties",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_properties_users_UsersUserId",
                table: "properties",
                column: "UsersUserId",
                principalTable: "users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_reports_properties_PropertyId",
                table: "reports",
                column: "PropertyId",
                principalTable: "properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_users_UserId",
                table: "reports",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_properties_PropertyId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_properties_Districts_DistrictId",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "FK_properties_User_UserId",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "FK_properties_categories_CategoryId",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "FK_properties_users_UsersUserId",
                table: "properties");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_properties_PropertyId",
                table: "reports");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_users_UserId",
                table: "reports");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_reports_PropertyId",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_reports_UserId",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_properties_CategoryId",
                table: "properties");

            migrationBuilder.DropIndex(
                name: "IX_properties_DistrictId",
                table: "properties");

            migrationBuilder.DropIndex(
                name: "IX_properties_UserId",
                table: "properties");

            migrationBuilder.DropIndex(
                name: "IX_properties_UsersUserId",
                table: "properties");

            migrationBuilder.DropIndex(
                name: "IX_comments_PropertyId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_UserId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "properties");
        }
    }
}
