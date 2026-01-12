using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCookbook.Migrations
{
    /// <inheritdoc />
    public partial class editMealPlanRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanRecipes_Recipes_RecipeId",
                table: "MealPlanRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlanRecipes",
                table: "MealPlanRecipes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "MealPlanRecipes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MealPlanRecipes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlanRecipes",
                table: "MealPlanRecipes",
                columns: new[] { "MealPlanDayId", "CategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanRecipes_CategoryId",
                table: "MealPlanRecipes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanRecipes_Categories_CategoryId",
                table: "MealPlanRecipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanRecipes_Recipes_RecipeId",
                table: "MealPlanRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanRecipes_Categories_CategoryId",
                table: "MealPlanRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanRecipes_Recipes_RecipeId",
                table: "MealPlanRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlanRecipes",
                table: "MealPlanRecipes");

            migrationBuilder.DropIndex(
                name: "IX_MealPlanRecipes_CategoryId",
                table: "MealPlanRecipes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MealPlanRecipes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "MealPlanRecipes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlanRecipes",
                table: "MealPlanRecipes",
                columns: new[] { "MealPlanDayId", "RecipeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanRecipes_Recipes_RecipeId",
                table: "MealPlanRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
