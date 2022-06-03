using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCore_React2.Data.Migrations
{
    public partial class _1Mp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime1",
                table: "PersistedGrants",
                column: "ConsumedTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_ConsumedTime1",
                table: "PersistedGrants");
        }
    }
}
