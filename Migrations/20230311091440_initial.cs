using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeShop.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsTrendingProduct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Americanos are popular breakfast drinks and thought to have originated during World War II. Soldiers would add water to their coffee to extend their rations farther. The water dilutes the espresso while still maintaining a high level of caffeine.", "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_americano.jpg", false, "Americano", 0.0 },
                    { 2, "The espresso, also known as a short black, is approximately 1 oz. of highly concentrated coffee. Although simple in appearance, it can be difficult to master.", "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_espresso.jpg", false, "Espresso", 0.0 },
                    { 3, "A double espresso may also be listed as doppio, which is the Italian word for double. This drink is highly concentrated and strong.", "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_double-espresso.jpg", false, "Double Espresso", 0.0 },
                    { 4, "The long black is a similar coffee drink to the americano, but it originated in New Zealand and Australia. It generally has more crema than an americano.", "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_long-black.jpg", false, "Long Black", 0.0 },
                    { 5, "The word macchiato means mark or stain. This is in reference to the mark that steamed milk leaves on the surface of the espresso as it is dashed into the drink. Flavoring syrups are often added to the drink according to customer preference.", "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_macchiato.jpg", false, "Macchiato", 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
