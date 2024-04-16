using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testTask.Migrations
{
    /// <inheritdoc />
    public partial class changedManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Categories_CategoryId",
                table: "FilmCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategories_Films_FilmId",
                table: "FilmCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FilmCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategory_CategoryId",
                table: "FilmCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategory_FilmId",
                table: "FilmCategories",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategory_CategoryId",
                table: "FilmCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmCategory_FilmId",
                table: "FilmCategories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FilmCategories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_Categories_CategoryId",
                table: "FilmCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmCategories_Films_FilmId",
                table: "FilmCategories",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
