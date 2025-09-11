using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenUsersAndExamTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ExamTemplates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ExamTemplates_CreatedById",
                table: "ExamTemplates",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamTemplates_Users_CreatedById",
                table: "ExamTemplates",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamTemplates_Users_CreatedById",
                table: "ExamTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ExamTemplates_CreatedById",
                table: "ExamTemplates");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ExamTemplates");
        }
    }
}
