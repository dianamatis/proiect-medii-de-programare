using Microsoft.EntityFrameworkCore.Migrations;

namespace Matis_Diana_ProiectExamen.Migrations
{
    public partial class fixconditontyop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneCondition_Condition_ConditionID",
                table: "PhoneCondition");

            migrationBuilder.DropColumn(
                name: "ConditonID",
                table: "PhoneCondition");

            migrationBuilder.AlterColumn<int>(
                name: "ConditionID",
                table: "PhoneCondition",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneCondition_Condition_ConditionID",
                table: "PhoneCondition",
                column: "ConditionID",
                principalTable: "Condition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneCondition_Condition_ConditionID",
                table: "PhoneCondition");

            migrationBuilder.AlterColumn<int>(
                name: "ConditionID",
                table: "PhoneCondition",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ConditonID",
                table: "PhoneCondition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneCondition_Condition_ConditionID",
                table: "PhoneCondition",
                column: "ConditionID",
                principalTable: "Condition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
