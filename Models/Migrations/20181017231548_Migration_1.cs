using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class Migration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    ServingSize = table.Column<decimal>(nullable: false),
                    ServingUnit = table.Column<string>(nullable: true),
                    TotalFat = table.Column<decimal>(nullable: false),
                    SaturatedFat = table.Column<decimal>(nullable: false),
                    TransFat = table.Column<decimal>(nullable: false),
                    Cholesterol = table.Column<decimal>(nullable: false),
                    Sodium = table.Column<decimal>(nullable: false),
                    TotalCarbs = table.Column<decimal>(nullable: false),
                    DietaryFiber = table.Column<decimal>(nullable: false),
                    SolubleFiber = table.Column<decimal>(nullable: false),
                    InsolubleFiber = table.Column<decimal>(nullable: false),
                    Sugar = table.Column<decimal>(nullable: false),
                    Protein = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Servings = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<decimal>(nullable: false),
                    QuantityUnit = table.Column<string>(nullable: true),
                    FoodItemId = table.Column<int>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeLines_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeLines_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLines_FoodItemId",
                table: "RecipeLines",
                column: "FoodItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLines_RecipeId",
                table: "RecipeLines",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeLines");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
