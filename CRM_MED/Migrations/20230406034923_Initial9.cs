using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_MED.Migrations
{
    /// <inheritdoc />
    public partial class Initial9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalCards_PatientId",
                table: "MedicalCards");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "WorkTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_PatientId",
                table: "WorkTimes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCards_PatientId",
                table: "MedicalCards",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimes_Patients_PatientId",
                table: "WorkTimes",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimes_Patients_PatientId",
                table: "WorkTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkTimes_PatientId",
                table: "WorkTimes");

            migrationBuilder.DropIndex(
                name: "IX_MedicalCards_PatientId",
                table: "MedicalCards");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "WorkTimes");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCards_PatientId",
                table: "MedicalCards",
                column: "PatientId",
                unique: true);
        }
    }
}
