﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeManagement.Web.Migrations
{
    /// <inheritdoc />
    public partial class AvatarPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "students");
        }
    }
}
