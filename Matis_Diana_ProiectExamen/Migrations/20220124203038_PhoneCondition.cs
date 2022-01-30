using Microsoft.EntityFrameworkCore.Migrations;

namespace Matis_Diana_ProiectExamen.Migrations
{
    public partial class PhoneCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Phone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneCondition",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneID = table.Column<int>(nullable: false),
                    ConditonID = table.Column<int>(nullable: false),
                    ConditionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCondition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhoneCondition_Condition_ConditionID",
                        column: x => x.ConditionID,
                        principalTable: "Condition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneCondition_Phone_PhoneID",
                        column: x => x.PhoneID,
                        principalTable: "Phone",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phone_BrandID",
                table: "Phone",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCondition_ConditionID",
                table: "PhoneCondition",
                column: "ConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCondition_PhoneID",
                table: "PhoneCondition",
                column: "PhoneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Brand_BrandID",
                table: "Phone",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Brand_BrandID",
                table: "Phone");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "PhoneCondition");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropIndex(
                name: "IX_Phone_BrandID",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Phone");
        }
    }
}
