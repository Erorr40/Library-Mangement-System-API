using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_Mangement_System.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowRecordMember",
                columns: table => new
                {
                    BorrowRecordsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRecordMember", x => new { x.BorrowRecordsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_BorrowRecordMember_BorrowRecords_BorrowRecordsId",
                        column: x => x.BorrowRecordsId,
                        principalTable: "BorrowRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowRecordMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowRecord",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    BorrowRecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowRecord", x => new { x.BooksId, x.BorrowRecordsId });
                    table.ForeignKey(
                        name: "FK_BookBorrowRecord_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowRecord_BorrowRecords_BorrowRecordsId",
                        column: x => x.BorrowRecordsId,
                        principalTable: "BorrowRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BorrowRecords",
                columns: new[] { "Id", "BorrowDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 24, 12, 1, 29, 383, DateTimeKind.Local).AddTicks(8268), null },
                    { 2, new DateTime(2026, 9, 19, 12, 1, 29, 383, DateTimeKind.Local).AddTicks(8324), new DateTime(2026, 9, 23, 12, 1, 29, 383, DateTimeKind.Local).AddTicks(8328) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Science Fiction" },
                    { 2, "Fantasy" },
                    { 3, "Mystery" },
                    { 4, "Romance" },
                    { 5, "Non-Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "FullName", "PhoneNumber" },
                values: new object[] { 1, "ahmed.ali@mail.com", "Ahmed Ali", null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "CategoryId", "Price", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "Abo ali", 5, 1, 9.99m, 1965, "book1" },
                    { 2, "The Father of Book", 3, 2, 7m, 1937, "The Book" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowRecord_BorrowRecordsId",
                table: "BookBorrowRecord",
                column: "BorrowRecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRecordMember_MembersId",
                table: "BorrowRecordMember",
                column: "MembersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrowRecord");

            migrationBuilder.DropTable(
                name: "BorrowRecordMember");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BorrowRecords");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
