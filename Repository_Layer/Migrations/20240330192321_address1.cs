using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class address1 : Migration
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

            migrationBuilder.CreateTable(
                name: "AddressTable",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandMark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTable", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_AddressTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressTable_UserId",
                table: "AddressTable",
                column: "UserId");

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

            migrationBuilder.DropTable(
                name: "AddressTable");

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
