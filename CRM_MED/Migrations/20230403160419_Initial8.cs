using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_MED.Migrations
{
    /// <inheritdoc />
    public partial class Initial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkTimes_DoctorId",
                table: "WorkTimes");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_DoctorId",
                table: "WorkTimes",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkTimes_DoctorId",
                table: "WorkTimes");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_DoctorId",
                table: "WorkTimes",
                column: "DoctorId",
                unique: true);
        }
    }
}
