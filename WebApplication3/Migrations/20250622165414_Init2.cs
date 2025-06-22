using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsibles_Employee_EmployeeId",
                table: "Responsibles");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsibles_SeedlingBatches_BatchId",
                table: "Responsibles");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedlingBatches_Nursery_NurseryId",
                table: "SeedlingBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedlingBatches_TreeSpecies_SpeciesId",
                table: "SeedlingBatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeedlingBatches",
                table: "SeedlingBatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsibles",
                table: "Responsibles");

            migrationBuilder.RenameTable(
                name: "SeedlingBatches",
                newName: "SeedlingBatch");

            migrationBuilder.RenameTable(
                name: "Responsibles",
                newName: "Responsible");

            migrationBuilder.RenameIndex(
                name: "IX_SeedlingBatches_SpeciesId",
                table: "SeedlingBatch",
                newName: "IX_SeedlingBatch_SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_SeedlingBatches_NurseryId",
                table: "SeedlingBatch",
                newName: "IX_SeedlingBatch_NurseryId");

            migrationBuilder.RenameIndex(
                name: "IX_Responsibles_EmployeeId",
                table: "Responsible",
                newName: "IX_Responsible_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeedlingBatch",
                table: "SeedlingBatch",
                column: "BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsible",
                table: "Responsible",
                columns: new[] { "BatchId", "EmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Responsible_Employee_EmployeeId",
                table: "Responsible",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsible_SeedlingBatch_BatchId",
                table: "Responsible",
                column: "BatchId",
                principalTable: "SeedlingBatch",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedlingBatch_Nursery_NurseryId",
                table: "SeedlingBatch",
                column: "NurseryId",
                principalTable: "Nursery",
                principalColumn: "NurseryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedlingBatch_TreeSpecies_SpeciesId",
                table: "SeedlingBatch",
                column: "SpeciesId",
                principalTable: "TreeSpecies",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsible_Employee_EmployeeId",
                table: "Responsible");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsible_SeedlingBatch_BatchId",
                table: "Responsible");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedlingBatch_Nursery_NurseryId",
                table: "SeedlingBatch");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedlingBatch_TreeSpecies_SpeciesId",
                table: "SeedlingBatch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeedlingBatch",
                table: "SeedlingBatch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsible",
                table: "Responsible");

            migrationBuilder.RenameTable(
                name: "SeedlingBatch",
                newName: "SeedlingBatches");

            migrationBuilder.RenameTable(
                name: "Responsible",
                newName: "Responsibles");

            migrationBuilder.RenameIndex(
                name: "IX_SeedlingBatch_SpeciesId",
                table: "SeedlingBatches",
                newName: "IX_SeedlingBatches_SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_SeedlingBatch_NurseryId",
                table: "SeedlingBatches",
                newName: "IX_SeedlingBatches_NurseryId");

            migrationBuilder.RenameIndex(
                name: "IX_Responsible_EmployeeId",
                table: "Responsibles",
                newName: "IX_Responsibles_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeedlingBatches",
                table: "SeedlingBatches",
                column: "BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsibles",
                table: "Responsibles",
                columns: new[] { "BatchId", "EmployeeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibles_Employee_EmployeeId",
                table: "Responsibles",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibles_SeedlingBatches_BatchId",
                table: "Responsibles",
                column: "BatchId",
                principalTable: "SeedlingBatches",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedlingBatches_Nursery_NurseryId",
                table: "SeedlingBatches",
                column: "NurseryId",
                principalTable: "Nursery",
                principalColumn: "NurseryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedlingBatches_TreeSpecies_SpeciesId",
                table: "SeedlingBatches",
                column: "SpeciesId",
                principalTable: "TreeSpecies",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
