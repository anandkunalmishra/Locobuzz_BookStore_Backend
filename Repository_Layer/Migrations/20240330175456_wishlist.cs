using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class wishlist : Migration
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

            migrationBuilder.CreateTable(
                name: "WishlistTable",
                columns: table => new
                {
                    WishlistId = table.Column<int>(name: "Wishlist_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    Bookid = table.Column<int>(name: "Book_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistTable", x => x.WishlistId);
                    table.ForeignKey(
                        name: "FK_WishlistTable_UserTable_Book_id",
                        column: x => x.Bookid,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WishlistTable_UserTable_userId",
                        column: x => x.userId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishlistTable_Book_id",
                table: "WishlistTable",
                column: "Book_id");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistTable_userId",
                table: "WishlistTable",
                column: "userId");

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

            migrationBuilder.DropTable(
                name: "WishlistTable");

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
        }
    }
}
