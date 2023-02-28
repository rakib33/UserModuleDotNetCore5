using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagementCore.Migrations
{
    public partial class updateuserdetailsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "company_id",
                table: "SiteMaster",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyMastercompany_id",
                table: "SiteMaster",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AppUserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreditCard",
                table: "AppUserDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppRoles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "ApplicationMenu",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MenuDisplayName",
                table: "ApplicationMenu",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiteMaster_CompanyMastercompany_id",
                table: "SiteMaster",
                column: "CompanyMastercompany_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteMaster_CompanyMaster_CompanyMastercompany_id",
                table: "SiteMaster",
                column: "CompanyMastercompany_id",
                principalTable: "CompanyMaster",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteMaster_CompanyMaster_CompanyMastercompany_id",
                table: "SiteMaster");

            migrationBuilder.DropIndex(
                name: "IX_SiteMaster_CompanyMastercompany_id",
                table: "SiteMaster");

            migrationBuilder.DropColumn(
                name: "CompanyMastercompany_id",
                table: "SiteMaster");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AppUserDetails");

            migrationBuilder.DropColumn(
                name: "CreditCard",
                table: "AppUserDetails");

            migrationBuilder.AlterColumn<string>(
                name: "company_id",
                table: "SiteMaster",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppRoles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "ApplicationMenu",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "MenuDisplayName",
                table: "ApplicationMenu",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
