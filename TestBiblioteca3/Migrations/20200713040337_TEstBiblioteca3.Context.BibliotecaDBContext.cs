using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestBiblioteca3.Migrations
{
    public partial class TEstBiblioteca3ContextBibliotecaDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    cate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.cate);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    nombre = table.Column<string>(nullable: false),
                    disponible = table.Column<bool>(nullable: false),
                    cate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.nombre);
                    table.ForeignKey(
                        name: "FK_libros_categorias_cate",
                        column: x => x.cate,
                        principalTable: "categorias",
                        principalColumn: "cate",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "alquileres",
                columns: table => new
                {
                    IdAlquiler = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fin = table.Column<DateTime>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    idUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alquileres", x => x.IdAlquiler);
                    table.ForeignKey(
                        name: "FK_alquileres_usuarios_idUser",
                        column: x => x.idUser,
                        principalTable: "usuarios",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alquileres_libros_nombre",
                        column: x => x.nombre,
                        principalTable: "libros",
                        principalColumn: "nombre",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alquileres_idUser",
                table: "alquileres",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_alquileres_nombre",
                table: "alquileres",
                column: "nombre");

            migrationBuilder.CreateIndex(
                name: "IX_libros_cate",
                table: "libros",
                column: "cate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alquileres");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "libros");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
