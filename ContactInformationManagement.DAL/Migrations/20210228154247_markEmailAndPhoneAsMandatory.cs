using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactInformationManagement.DAL.Migrations
{
    public partial class markEmailAndPhoneAsMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Email",
                table: "ContactDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactDetails",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Email",
                table: "ContactDetails",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Email",
                table: "ContactDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactDetails",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.CreateIndex(
                name: "IX_Email",
                table: "ContactDetails",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }
    }
}
