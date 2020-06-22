using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliotecaCore.Dal.Migrations
{
    public partial class _2MigrationIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_Authorid",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_Categoryid",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "Categoryid",
                table: "Book",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Authorid",
                table: "Book",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_Authorid",
                table: "Book",
                column: "Authorid",
                principalTable: "Author",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_Categoryid",
                table: "Book",
                column: "Categoryid",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_Authorid",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_Categoryid",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "Categoryid",
                table: "Book",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Authorid",
                table: "Book",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_Authorid",
                table: "Book",
                column: "Authorid",
                principalTable: "Author",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_Categoryid",
                table: "Book",
                column: "Categoryid",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
