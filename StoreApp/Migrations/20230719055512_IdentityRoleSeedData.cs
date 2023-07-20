using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "22bdd0b6-c0a7-4f1f-a198-3c90153a2f73", "8e3cc6c6-96c2-4a8c-859e-dcd5049b336b", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91ec2fa5-5d58-444c-8ceb-45a92704082b", "95fd8558-6814-4b45-b6ca-c8a81c5604c5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a10cdc8a-728a-4a90-b487-7770ada5cc06", "b364fff7-b273-449c-b3b3-b85a309e4532", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22bdd0b6-c0a7-4f1f-a198-3c90153a2f73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91ec2fa5-5d58-444c-8ceb-45a92704082b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a10cdc8a-728a-4a90-b487-7770ada5cc06");
        }
    }
}
