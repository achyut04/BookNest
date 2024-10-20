using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookNest.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CopiesAvailable", "ISBN", "Title", "TotalCopies", "YearPublished" },
                values: new object[,]
                {
                    { 1, "Harper Lee", 7, "9780060935467", "To Kill a Mockingbird", 10, 1960 },
                    { 2, "George Orwell", 5, "9780451524935", "1984", 8, 1949 },
                    { 3, "F. Scott Fitzgerald", 3, "9780743273565", "The Great Gatsby", 6, 1925 },
                    { 4, "J.D. Salinger", 8, "9780316769488", "The Catcher in the Rye", 12, 1951 },
                    { 5, "Jane Austen", 6, "9780141439518", "Pride and Prejudice", 9, 1813 },
                    { 6, "J.R.R. Tolkien", 3, "9780618640157", "The Lord of the Rings", 5, 1954 },
                    { 7, "J.K. Rowling", 15, "9780439708180", "Harry Potter and the Sorcerer's Stone", 20, 1997 },
                    { 8, "Herman Melville", 4, "9781503280786", "Moby-Dick", 7, 1851 },
                    { 9, "Leo Tolstoy", 2, "9780199232765", "War and Peace", 4, 1869 },
                    { 10, "Fyodor Dostoevsky", 3, "9780143107637", "Crime and Punishment", 6, 1866 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10);
        }
    }
}
