using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddingNormalizedUsernameandemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8547dfbf-6634-4351-be7b-472a2c3bb561",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fccbc3c6-b938-4fa4-91e3-f35ea7136a7b", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEInVqfnRbaX0M+s/TMKeqfaNGpZEKg0nP8fKrrFZL/MT3wgRSX4hlkan//pAiI34Cg==", "c36ee6fe-3c72-4e19-95f5-60d2f8fee947" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8547dfbf-6634-4351-be7b-472a2c3bb561",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "211a4f04-a699-4689-ac14-651c49e84bd8", null, null, "AQAAAAIAAYagAAAAEGW4YVBFpqUYoNyP2Y/FbDd5CE1bxjOO/LTeCqoKfG+OhEhhiGoYjJydiH4c7xrSxA==", "e20398d0-045e-43de-b838-191df9796ae3" });
        }
    }
}
