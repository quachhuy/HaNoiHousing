using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hnh.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    districtid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.districtid);
                });

            migrationBuilder.CreateTable(
                name: "report_statuses",
                columns: table => new
                {
                    reportstatusid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_report_statuses", x => x.reportstatusid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "no-avatar.jpg"),
                    remembertoken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "password_resets",
                columns: table => new
                {
                    password_resetid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password_resets", x => x.password_resetid);
                    table.ForeignKey(
                        name: "FK_password_resets_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    propertyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    area = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    countview = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    latLng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "no-img.jpg"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    districtid = table.Column<int>(type: "int", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    furniture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    approve = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.propertyid);
                    table.ForeignKey(
                        name: "FK_properties_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_properties_districts_districtid",
                        column: x => x.districtid,
                        principalTable: "districts",
                        principalColumn: "districtid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_properties_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    commentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "getdate()"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    propertyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.commentid);
                    table.ForeignKey(
                        name: "FK_comments_properties_propertyid",
                        column: x => x.propertyid,
                        principalTable: "properties",
                        principalColumn: "propertyid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    reportid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "getdate()"),
                    userid = table.Column<int>(type: "int", nullable: false),
                    propertyid = table.Column<int>(type: "int", nullable: false),
                    reportstatusid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.reportid);
                    table.ForeignKey(
                        name: "FK_reports_properties_propertyid",
                        column: x => x.propertyid,
                        principalTable: "properties",
                        principalColumn: "propertyid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reports_report_statuses_reportstatusid",
                        column: x => x.reportstatusid,
                        principalTable: "report_statuses",
                        principalColumn: "reportstatusid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reports_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_propertyid",
                table: "comments",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "IX_comments_userid",
                table: "comments",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_password_resets_userid",
                table: "password_resets",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_properties_categoryid",
                table: "properties",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_properties_districtid",
                table: "properties",
                column: "districtid");

            migrationBuilder.CreateIndex(
                name: "IX_properties_userid",
                table: "properties",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_reports_propertyid",
                table: "reports",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "IX_reports_reportstatusid",
                table: "reports",
                column: "reportstatusid");

            migrationBuilder.CreateIndex(
                name: "IX_reports_userid",
                table: "reports",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "password_resets");

            migrationBuilder.DropTable(
                name: "reports");

            migrationBuilder.DropTable(
                name: "properties");

            migrationBuilder.DropTable(
                name: "report_statuses");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
