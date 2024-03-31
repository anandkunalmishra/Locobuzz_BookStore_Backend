using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTable_UserTable_UserId",
                table: "BookTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CartTable_BookTable_Book_Id",
                table: "CartTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CartTable_UserTable_UserId",
                table: "CartTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistTable_BookTable_Book_Id",
                table: "WishlistTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistTable_UserTable_UserId",
                table: "WishlistTable");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTable_UserTable_UserId",
                table: "BookTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CartTable_BookTable_Book_Id",
                table: "CartTable",
                column: "Book_Id",
                principalTable: "BookTable",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CartTable_UserTable_UserId",
                table: "CartTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistTable_BookTable_Book_Id",
                table: "WishlistTable",
                column: "Book_Id",
                principalTable: "BookTable",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistTable_UserTable_UserId",
                table: "WishlistTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTable_UserTable_UserId",
                table: "BookTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CartTable_BookTable_Book_Id",
                table: "CartTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CartTable_UserTable_UserId",
                table: "CartTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistTable_BookTable_Book_Id",
                table: "WishlistTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistTable_UserTable_UserId",
                table: "WishlistTable");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTable_UserTable_UserId",
                table: "BookTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartTable_BookTable_Book_Id",
                table: "CartTable",
                column: "Book_Id",
                principalTable: "BookTable",
                principalColumn: "Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartTable_UserTable_UserId",
                table: "CartTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistTable_BookTable_Book_Id",
                table: "WishlistTable",
                column: "Book_Id",
                principalTable: "BookTable",
                principalColumn: "Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistTable_UserTable_UserId",
                table: "WishlistTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "UserId");
        }
    }
}
