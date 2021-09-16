using Microsoft.EntityFrameworkCore.Migrations;

namespace CommunalServices.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProvider_Provider_ProviderId",
                table: "ServiceProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProvider_ServiceTypes_ServiceTypeId",
                table: "ServiceProvider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceProvider",
                table: "ServiceProvider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provider",
                table: "Provider");

            migrationBuilder.RenameTable(
                name: "ServiceProvider",
                newName: "ServiceProviders");

            migrationBuilder.RenameTable(
                name: "Provider",
                newName: "Providers");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProvider_ServiceTypeId",
                table: "ServiceProviders",
                newName: "IX_ServiceProviders_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProvider_ProviderId",
                table: "ServiceProviders",
                newName: "IX_ServiceProviders_ProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceProviders",
                table: "ServiceProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providers",
                table: "Providers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_Providers_ProviderId",
                table: "ServiceProviders",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_ServiceTypes_ServiceTypeId",
                table: "ServiceProviders",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_Providers_ProviderId",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_ServiceTypes_ServiceTypeId",
                table: "ServiceProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceProviders",
                table: "ServiceProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providers",
                table: "Providers");

            migrationBuilder.RenameTable(
                name: "ServiceProviders",
                newName: "ServiceProvider");

            migrationBuilder.RenameTable(
                name: "Providers",
                newName: "Provider");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProviders_ServiceTypeId",
                table: "ServiceProvider",
                newName: "IX_ServiceProvider_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProviders_ProviderId",
                table: "ServiceProvider",
                newName: "IX_ServiceProvider_ProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceProvider",
                table: "ServiceProvider",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provider",
                table: "Provider",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProvider_Provider_ProviderId",
                table: "ServiceProvider",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProvider_ServiceTypes_ServiceTypeId",
                table: "ServiceProvider",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
