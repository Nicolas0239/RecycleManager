using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecycleManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenomeandoEnderecoParaAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "CollectionPoints",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "CollectionPoints",
                newName: "Adress");
        }
    }
}
