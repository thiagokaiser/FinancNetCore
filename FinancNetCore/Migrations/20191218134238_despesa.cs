using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class despesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_categoria_CategoriaId",
                table: "Despesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa");

            migrationBuilder.RenameTable(
                name: "Despesa",
                newName: "despesa");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "despesa",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "despesa",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "despesa",
                newName: "categoriaid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "despesa",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Despesa_CategoriaId",
                table: "despesa",
                newName: "IX_despesa_categoriaid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_despesa",
                table: "despesa",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_despesa_categoria_categoriaid",
                table: "despesa",
                column: "categoriaid",
                principalTable: "categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_despesa_categoria_categoriaid",
                table: "despesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_despesa",
                table: "despesa");

            migrationBuilder.RenameTable(
                name: "despesa",
                newName: "Despesa");

            migrationBuilder.RenameColumn(
                name: "valor",
                table: "Despesa",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Despesa",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "categoriaid",
                table: "Despesa",
                newName: "CategoriaId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Despesa",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_despesa_categoriaid",
                table: "Despesa",
                newName: "IX_Despesa_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_categoria_CategoriaId",
                table: "Despesa",
                column: "CategoriaId",
                principalTable: "categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
