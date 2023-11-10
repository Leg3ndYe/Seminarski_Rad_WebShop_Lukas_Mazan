using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Motorcycle_WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added15ProductsToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "When Yamaha launched the first MT Hyper Naked a decade ago the motorcycle world changed forever. With a clear focus on torque, agility and feel, the MT range has given riders the chance to experience the raw emotion and on-demand excitement that makes every Hyper Naked special.");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "In 2015, the first Tracer 900 changed the Sport Touring class forever. With its torque-rich CP3 engine, sporty chassis and all-round versatility, it became the bike of choice for over 50,000 European riders who wanted an agile and exciting multi-role motorcycle with plenty of attitude. Perhaps no surprise then that it’s the best-selling bike of its class.");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "R1 is the most focused and high-tech Supersport bike ever built by Yamaha, ever since the launch of the original model over 25 years ago. And just about everything on the latest R1 can directly trace its origins back to the racetrack, where Yamaha’s factory racing teams and test riders have been developing and testing the advanced technology that you can now see and experience on your R1. ");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "This is the kind of motorcycle that you can enjoy in almost any kind of situation. It’s easy ergonomics are specially designed to give you an open and adaptable riding position that makes every ride more enjoyable. From narrow twisty backroads through to fast open corners or relaxed cruising through town, the XSR900 is ready for anything. ");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "The key to NIKEN GT’s outstanding handling performance is Yamaha’s LMW system. Featuring twin leaning front wheels, this innovative front end gives class leading cornering performance with enhanced feelings of stability – and it’s what makes this premium Sport Tourer one of the most capable machines in its category. ");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "IsActive", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 6, "Now even more stylish and aggressively muscular, just a quick glance and you catch the burnished metal finishes that reflect the tradition of a hard-charging Café Racer. ", true, 13499m, 17m, "HONDA CB1000R" },
                    { 7, "This is why we race. Why we’ve always raced, and it is feedback from HRC and our riders that’s produced the new CBR1000RR-R Fireblade. It’s got more mid-range power from intake and cylinder head upgrades, with revised gearbox ratios for incredible drive out of corners. ", true, 27899m, 13m, "HONDA CB1000RR" },
                    { 8, "Forget the expected. It’s time for a new generation to shake things up. Start with a brand-new engine producing incredible, class-leading power. Dial in a lightweight chassis honed for sports, tightly wrapped in head-turning streetfighter style and the new CB750 Hornet takes flight. Nothing else comes close. ", true, 27899m, 16m, "HONDA CB750 HORNET" },
                    { 9, "The Gold Wing Tour takes care of rider and pillion alike. With dynamic handling and engine response to satisfy any rider, the pillion can settle back into their luxurious and even more expansive space and enjoy the journey ahead. ", true, 37799m, 9m, "HONDA GL1800 GOLD WING" },
                    { 10, "The NT1100 offers everything you need in one motorcycle. It’s built agile for the demands of the city with light, easy handling and long-travel suspension. ", true, 15499m, 13m, "HONDA NT1100" },
                    { 11, "Turn heads as you take on your next adventure aboard a Kawasaki Vulcan 900 cruiser. Right off the showroom floor, the 903cc V-twin powered cruiser has all the style and attitude of a one-of-a-kind build. From the detailed paint to the exciting exhaust, the Vulcan 900 Series is an artful expression of individuality. ", true, 8999m, 15m, "KAWASAKI VULCAN 900" },
                    { 12, "The sport appeal of Kawasaki Ninja motorcycles goes well beyond the racetrack with the remarkably versatile Ninja 1000SX sportbike. Enjoy pure sporting thrill with superior power, two-up touring capability and advanced rider support electronics. A force to be reckoned with on the track and a machine built for weekend trips. ", true, 17549m, 11m, "KAWASAKI NINJA 1000SX" },
                    { 13, "The Ninja ZX™-10R supersport bike is built for those who rise to the challenge. Hailing from the proving grounds of the FIM WorldSBK Championship, the Ninja ZX-10R is the direct result of decades of world-class road racing innovation, carrying the Kawasaki Racing Team (KRT) to six consecutive championship titles. Push your limits aboard the Ninja ZX-10R. ", true, 17799m, 17m, "KAWASAKI NINJA ZX-10R" },
                    { 14, " ", true, 9999m, 21m, "KAWASAKI Z900" },
                    { 15, "The development of the Ninja H2R motorcycle goes beyond the boundaries of any other Kawasaki motorcycle. Born through the unprecedented collaboration between multiple divisions within the Kawasaki Heavy Industries, Ltd. (KHI) organization, the limited-production supercharged model represents the unbridled pinnacle of Kawasaki engineering, with astonishing acceleration and mind-bending top speed suitable only for the track. ", true, 62299m, 5m, "KAWASAKI NINJA H2R" },
                    { 16, "At the pinnacle of the GSX-R family of ultra-high-performance motorcycles, the 2024 GSX-R1000R’s versatile engine provides class-leading power that is delivered smoothly and controllably across a broad rpm range. Like the original GSX-R1000, the 2024’s compact chassis delivers nimble handling with excellent suspension feel and braking control, ready to conquer a racetrack or cruise a country road.", true, 18499m, 13m, "SUZUKI GSX-R1000R" },
                    { 17, "The Suzuki Hayabusa remains firmly in place as motorcycling’s Ultimate Sportbike. The 2024 version of Suzuki’s flagship sportbike continues to be propelled by a muscular, refined inline four-cylinder engine housed in a proven, yet modernized chassis with incomparable manners, managed by an unequaled suite of electronic rider aids within stunning aerodynamic bodywork that is distinctly Hayabusa.", true, 18999m, 20m, "SUZUKI HAYABUSA" },
                    { 18, "An exotic blend of heritage, styling, and engineering—the refined 2024 Suzuki KATANA is poised to revolutionize your cherished motorcycle collection. Named after the legendary samurai sword, the KATANA retains its iconic design and features technical updates designed to enhance the riding pleasure of this distinctive motorcycle.", true, 13899m, 7m, "SUZUKI KATANA" },
                    { 19, "Ready to make a statement? Swing a leg over the 2024 Suzuki GSX-8S and let your riding speak volumes. Engineered from the ground up as an innovative path for future Suzuki sportbikes, the GSX-8S is a naked street fighter with a robust engine, an agile chassis, a suite of rider aids, plus stunning looks with a smart price that is a statement to your brilliance.", true, 8999m, 15m, "SUZUKI GSX-8S" },
                    { 20, "The 2024 GSX-S1000GT intelligently combines the championship performance of its GSX-R1000-based engine with a nimble, lightweight chassis to provide riders with an exciting and comfortable GT riding experience.  Here is a Grand Tourer with sportbike level functionality, avantgarde styling, and an extensive selection of optional equipment like truly functional, integrated side cases.", true, 13499m, 15m, "SUZUKI GSX-S1000GT" }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "FilePath", "IsMainImage", "ProductId", "Title" },
                values: new object[,]
                {
                    { 21, "/images/products/6/main.jpg", true, 6, "CB1000R.main" },
                    { 22, "/images/products/6/1.jpg", false, 6, "CB1000R.01" },
                    { 23, "/images/products/6/2.jpg", false, 6, "CB1000R.02" },
                    { 24, "/images/products/6/3.jpg", false, 6, "CB1000R.03" },
                    { 25, "/images/products/7/main.jpg", true, 7, "CB1000RR.main" },
                    { 26, "/images/products/7/1.jpg", false, 7, "CB1000RR.01" },
                    { 27, "/images/products/7/2.jpg", false, 7, "CB1000RR.02" },
                    { 28, "/images/products/7/3.jpg", false, 7, "CB1000RR.03" },
                    { 29, "/images/products/8/main.jpg", true, 8, "CB750.main" },
                    { 30, "/images/products/8/1.jpg", false, 8, "CB750.01" },
                    { 31, "/images/products/8/2.jpg", false, 8, "CB750.02" },
                    { 32, "/images/products/8/3.jpg", false, 8, "CB750.03" },
                    { 33, "/images/products/9/main.jpg", true, 9, "GL1800.main" },
                    { 34, "/images/products/9/1.jpg", false, 9, "GL1800.01" },
                    { 35, "/images/products/9/2.jpg", false, 9, "GL1800.02" },
                    { 36, "/images/products/9/3.jpg", false, 9, "GL1800.03" },
                    { 37, "/images/products/10/main.jpg", true, 10, "NT1100.main" },
                    { 38, "/images/products/10/1.jpg", false, 10, "NT1100.01" },
                    { 39, "/images/products/10/2.jpg", false, 10, "NT1100.02" },
                    { 40, "/images/products/10/3.jpg", false, 10, "NT1100.03" },
                    { 41, "/images/products/11/main.jpg", true, 11, "VULCAN 900.main" },
                    { 42, "/images/products/11/1.jpg", false, 11, "VULCAN 900.01" },
                    { 43, "/images/products/11/2.jpg", false, 11, "VULCAN 900.02" },
                    { 44, "/images/products/11/3.jpg", false, 11, "VULCAN 900.03" },
                    { 45, "/images/products/12/main.jpg", true, 12, "NINJA 1000SX.main" },
                    { 46, "/images/products/12/1.jpg", false, 12, "NINJA 1000SX.01" },
                    { 47, "/images/products/12/2.jpg", false, 12, "NINJA 1000SX.02" },
                    { 48, "/images/products/12/3.jpg", false, 12, "NINJA 1000SX.03" },
                    { 49, "/images/products/13/main.jpg", true, 13, "NINJA ZX-10R.main" },
                    { 50, "/images/products/13/1.jpg", false, 13, "NINJA ZX-10R.01" },
                    { 51, "/images/products/13/2.jpg", false, 13, "NINJA ZX-10R.02" },
                    { 52, "/images/products/13/3.jpg", false, 13, "NINJA ZX-10R.03" },
                    { 53, "/images/products/14/main.jpg", true, 14, "Z900.main" },
                    { 54, "/images/products/14/1.jpg", false, 14, "Z900.01" },
                    { 55, "/images/products/14/2.jpg", false, 14, "Z900.02" },
                    { 56, "/images/products/14/3.jpg", false, 14, "Z900.03" },
                    { 57, "/images/products/15/main.jpg", true, 15, "NINJA H2R.main" },
                    { 58, "/images/products/15/1.jpg", false, 15, "NINJA H2R.01" },
                    { 59, "/images/products/15/2.jpg", false, 15, "NINJA H2R.02" },
                    { 60, "/images/products/15/3.jpg", false, 15, "NINJA H2R.03" },
                    { 61, "/images/products/16/main.jpg", true, 16, "GSX-R1000R.main" },
                    { 62, "/images/products/16/1.jpg", false, 16, "GSX-R1000R.01" },
                    { 63, "/images/products/16/2.jpg", false, 16, "GSX-R1000R.02" },
                    { 64, "/images/products/16/3.jpg", false, 16, "GSX-R1000R.03" },
                    { 65, "/images/products/17/main.jpg", true, 17, "HAYABUSA.main" },
                    { 66, "/images/products/17/1.jpg", false, 17, "HAYABUSA.01" },
                    { 67, "/images/products/17/2.jpg", false, 17, "HAYABUSA.02" },
                    { 68, "/images/products/17/3.jpg", false, 17, "HAYABUSA.03" },
                    { 69, "/images/products/18/main.jpg", true, 18, "KATANA.main" },
                    { 70, "/images/products/18/1.jpg", false, 18, "KATANA.01" },
                    { 71, "/images/products/18/2.jpg", false, 18, "KATANA.02" },
                    { 72, "/images/products/18/3.jpg", false, 18, "KATANA.03" },
                    { 73, "/images/products/19/main.jpg", true, 19, "GSX-8S.main" },
                    { 74, "/images/products/19/1.jpg", false, 19, "GSX-8S.01" },
                    { 75, "/images/products/19/2.jpg", false, 19, "GSX-8S.02" },
                    { 76, "/images/products/19/3.jpg", false, 19, "GSX-8S.03" },
                    { 77, "/images/products/20/main.jpg", true, 20, "GSX-S1000GT.main" },
                    { 78, "/images/products/20/1.jpg", false, 20, "GSX-S1000GT.01" },
                    { 79, "/images/products/20/2.jpg", false, 20, "GSX-S1000GT.02" },
                    { 80, "/images/products/20/3.jpg", false, 20, "GSX-S1000GT.03" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Kada je Yamaha prije desetak godina predstavila prvi model MT iz asortimana Hyper Naked, svijet motocikla zauvijek se promijenio. Uz jasnu usredotočenost na okretni moment, okretnost i osjećaj, asortiman modela MT vozačima je pružio mogućnost da dožive sirove emocije i uzbuđenje na zahtjev koji svaki Hyper Naked model čine posebnim.");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "U 2015. prvi je TRACER 900 zauvijek promijenio klasu sportskih krstarica. Uz svoj CP3 agregat velikog okretnog momenta, sportsko podvozje i izvanrednu svestranost, Tracer 900 je bio odabir više od 50.000 europskih vozača koji žele okretan i uzbudljiv višenamjenski motocikl s puno stava. Možda i nije iznenađenje što je to najprodavaniji motocikl u klasi.");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Model R1 najusredotočeniji je i najsuvremeniji motocikl kategorije Supersport kojeg je Yamaha ikada napravila, sve od predstavljanja originalnog modela prije više od 25 godina. Gotovo sve na najnovijem modelu R1 ima svoje izravno podrijetlo na trkalištu, gdje su Yamahine tvorničke trkaće momčadi i probni vozači razvijali i testirali naprednu tehnologiju koju sada možete vidjeti i isprobati na svom modelu R1.");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Ovo je motocikl na kojem možete uživati u gotovo svakoj situaciji. Njegova jednostavna ergonomija posebno je dizajnirana kako bi vam pružila otvoren i prilagodljiv položaj za vožnju koji svaku vožnju čini ugodnijom. Od uskih zavojitih uličica do brzih otvorenih zavoja ili opuštenog krstarenja gradom, XSR900 spreman je na sve. ");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Ključ iznimnih sportskih i putnih performansi modela NIKEN njegov je naprednom tehnologijom izrađen prednji kraj. Ovaj jedinstveni dizajn s dva nagibna prednja kotača ima veliku dodirnu površinu s cestom, čime pruža brojne prednosti. ");
        }
    }
}
