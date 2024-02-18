using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeminarHub.Data.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "SeminarsParticipants",
                type: "nvarchar(450)",
                nullable: false,
                comment: "ParticipantId",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "SeminarId",
                table: "SeminarsParticipants",
                type: "int",
                nullable: false,
                comment: "Seminar ID",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Seminars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Topic name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Seminars",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Orginizer Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Lecturer",
                table: "Seminars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                comment: "Lecturer name",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Seminars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Duration of topic",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Seminars",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Details of topic",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "Seminars",
                type: "datetime2",
                nullable: false,
                comment: "DateAndtiem of creation the Topic",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Seminars",
                type: "int",
                nullable: false,
                comment: "Topics category id",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seminars",
                type: "int",
                nullable: false,
                comment: "Primary Key",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Category name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                comment: "Primary key",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "SeminarsParticipants",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "ParticipantId");

            migrationBuilder.AlterColumn<int>(
                name: "SeminarId",
                table: "SeminarsParticipants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Seminar ID");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Seminars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Topic name");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Seminars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Orginizer Id");

            migrationBuilder.AlterColumn<string>(
                name: "Lecturer",
                table: "Seminars",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldComment: "Lecturer name");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Seminars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Duration of topic");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Seminars",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Details of topic");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "Seminars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "DateAndtiem of creation the Topic");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Seminars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Topics category id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Seminars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary Key")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Category name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary key")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
