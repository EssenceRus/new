using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_MED.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialitys_SpecialityNavigationSpecialityId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "SpecialityNavigationSpecialityId",
                table: "Doctors",
                newName: "SpecialityId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_SpecialityNavigationSpecialityId",
                table: "Doctors",
                newName: "IX_Doctors_SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialitys_SpecialityId",
                table: "Doctors",
                column: "SpecialityId",
                principalTable: "Specialitys",
                principalColumn: "SpecialityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialitys_SpecialityId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "SpecialityId",
                table: "Doctors",
                newName: "SpecialityNavigationSpecialityId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_SpecialityId",
                table: "Doctors",
                newName: "IX_Doctors_SpecialityNavigationSpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialitys_SpecialityNavigationSpecialityId",
                table: "Doctors",
                column: "SpecialityNavigationSpecialityId",
                principalTable: "Specialitys",
                principalColumn: "SpecialityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
