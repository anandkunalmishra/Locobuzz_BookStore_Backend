using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class wishlist2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishlistTable_UserTable_Book_id",
                table: "WishlistTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistTable_UserTable_userId",
                table: "WishlistTable");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "WishlistTable",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Book_id",
                table: "WishlistTable",
                newName: "Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistTable_userId",
                table: "WishlistTable",
                newName: "IX_WishlistTable_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistTable_Book_id",
                table: "WishlistTable",
                newName: "IX_WishlistTable_Book_Id");

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
                name: "FK_WishlistTable_BookTable_Book_Id",
                table: "WishlistTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WishlistTable_UserTable_UserId",
                table: "WishlistTable");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WishlistTable",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Book_Id",
                table: "WishlistTable",
                newName: "Book_id");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistTable_UserId",
                table: "WishlistTable",
                newName: "IX_WishlistTable_userId");

            migrationBuilder.RenameIndex(
                name: "IX_WishlistTable_Book_Id",
                table: "WishlistTable",
                newName: "IX_WishlistTable_Book_id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistTable_UserTable_Book_id",
                table: "WishlistTable",
                column: "Book_id",
                principalTable: "UserTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_WishlistTable_UserTable_userId",
                table: "WishlistTable",
                column: "userId",
                principalTable: "UserTable",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
