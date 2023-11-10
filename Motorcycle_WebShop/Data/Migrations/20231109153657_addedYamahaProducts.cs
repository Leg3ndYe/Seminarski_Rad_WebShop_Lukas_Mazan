using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Motorcycle_WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedYamahaProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "IsActive", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Kada je Yamaha prije desetak godina predstavila prvi model MT iz asortimana Hyper Naked, svijet motocikla zauvijek se promijenio. Uz jasnu usredotočenost na okretni moment, okretnost i osjećaj, asortiman modela MT vozačima je pružio mogućnost da dožive sirove emocije i uzbuđenje na zahtjev koji svaki Hyper Naked model čine posebnim.", true, 15199m, 14m, "YAMAHA MT-10" },
                    { 2, "U 2015. prvi je TRACER 900 zauvijek promijenio klasu sportskih krstarica. Uz svoj CP3 agregat velikog okretnog momenta, sportsko podvozje i izvanrednu svestranost, Tracer 900 je bio odabir više od 50.000 europskih vozača koji žele okretan i uzbudljiv višenamjenski motocikl s puno stava. Možda i nije iznenađenje što je to najprodavaniji motocikl u klasi.", true, 16499m, 10m, "YAMAHA TRACER 9" },
                    { 3, "Model R1 najusredotočeniji je i najsuvremeniji motocikl kategorije Supersport kojeg je Yamaha ikada napravila, sve od predstavljanja originalnog modela prije više od 25 godina. Gotovo sve na najnovijem modelu R1 ima svoje izravno podrijetlo na trkalištu, gdje su Yamahine tvorničke trkaće momčadi i probni vozači razvijali i testirali naprednu tehnologiju koju sada možete vidjeti i isprobati na svom modelu R1.", true, 17399m, 21m, "YAMAHA R1" },
                    { 4, "Ovo je motocikl na kojem možete uživati u gotovo svakoj situaciji. Njegova jednostavna ergonomija posebno je dizajnirana kako bi vam pružila otvoren i prilagodljiv položaj za vožnju koji svaku vožnju čini ugodnijom. Od uskih zavojitih uličica do brzih otvorenih zavoja ili opuštenog krstarenja gradom, XSR900 spreman je na sve. ", true, 10199m, 13m, "YAMAHA XSR900" },
                    { 5, "Ključ iznimnih sportskih i putnih performansi modela NIKEN njegov je naprednom tehnologijom izrađen prednji kraj. Ovaj jedinstveni dizajn s dva nagibna prednja kotača ima veliku dodirnu površinu s cestom, čime pruža brojne prednosti. ", true, 15999m, 11m, "YAMAHA NIKEN" }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "FilePath", "IsMainImage", "ProductId", "Title" },
                values: new object[,]
                {
                    { 1, "/images/products/1/main.jpg", true, 1, "MT-10.main" },
                    { 2, "/images/products/1/1.jpg", false, 1, "MT-10.01" },
                    { 3, "/images/products/1/2.jpg", false, 1, "MT-10.02" },
                    { 4, "/images/products/1/3.jpg", false, 1, "MT-10.03" },
                    { 5, "/images/products/2/main.jpg", true, 2, "TRACER 9.main" },
                    { 6, "/images/products/2/1.jpg", false, 2, "TRACER 9.01" },
                    { 7, "/images/products/2/2.jpg", false, 2, "TRACER 9.02" },
                    { 8, "/images/products/2/3.jpg", false, 2, "TRACER 9.03" },
                    { 9, "/images/products/3/main.jpg", true, 3, "R1.main" },
                    { 10, "/images/products/3/1.jpg", false, 3, "R1.01" },
                    { 11, "/images/products/3/2.jpg", false, 3, "R1.02" },
                    { 12, "/images/products/3/3.jpg", false, 3, "R1.03" },
                    { 13, "/images/products/4/main.jpg", true, 4, "XSR900.main" },
                    { 14, "/images/products/4/1.jpg", false, 4, "XSR900.01" },
                    { 15, "/images/products/4/2.jpg", false, 4, "XSR900.02" },
                    { 16, "/images/products/4/3.jpg", false, 4, "XSR900.03" },
                    { 17, "/images/products/5/main.jpg", true, 5, "NIKEN.main" },
                    { 18, "/images/products/5/1.jpg", false, 5, "NIKEN.01" },
                    { 19, "/images/products/5/2.jpg", false, 5, "NIKEN.02" },
                    { 20, "/images/products/5/3.jpg", false, 5, "NIKEN.03" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
