using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TVersion.Migrations
{
    public partial class H3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AppPackages");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AppPackages");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "AppPackages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AppChangeLogs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AppChangeLogs");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "AppChangeLogs");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "AppPackages",
                newName: "LastModificationTime");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "AppChangeLogs",
                newName: "LastModificationTime");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppPackages",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppPackages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppPackages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppPackages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppPackages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppChangeLogs",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppChangeLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppChangeLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppChangeLogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppChangeLogs",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppPackages");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppPackages");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppPackages");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppPackages");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppPackages");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppChangeLogs");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppChangeLogs");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppChangeLogs");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppChangeLogs");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppChangeLogs");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "AppPackages",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "LastModificationTime",
                table: "AppChangeLogs",
                newName: "DateUpdated");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AppPackages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AppPackages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "AppPackages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AppChangeLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AppChangeLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedById",
                table: "AppChangeLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
