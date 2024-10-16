using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookApp.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_BookPositions_BookPositionId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_BookPositions_BookPositionId",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "BookPositionId",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookInventoryId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BookPositionId",
                table: "Rentals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookInventoryId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BookInventoryId",
                table: "Sales",
                column: "BookInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BookInventoryId",
                table: "Rentals",
                column: "BookInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_BookInventories_BookInventoryId",
                table: "Rentals",
                column: "BookInventoryId",
                principalTable: "BookInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_BookPositions_BookPositionId",
                table: "Rentals",
                column: "BookPositionId",
                principalTable: "BookPositions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_BookInventories_BookInventoryId",
                table: "Sales",
                column: "BookInventoryId",
                principalTable: "BookInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_BookPositions_BookPositionId",
                table: "Sales",
                column: "BookPositionId",
                principalTable: "BookPositions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_BookInventories_BookInventoryId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_BookPositions_BookPositionId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_BookInventories_BookInventoryId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_BookPositions_BookPositionId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_BookInventoryId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_BookInventoryId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "BookInventoryId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "BookInventoryId",
                table: "Rentals");

            migrationBuilder.AlterColumn<int>(
                name: "BookPositionId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookPositionId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_BookPositions_BookPositionId",
                table: "Rentals",
                column: "BookPositionId",
                principalTable: "BookPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_BookPositions_BookPositionId",
                table: "Sales",
                column: "BookPositionId",
                principalTable: "BookPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
