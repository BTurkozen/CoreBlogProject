using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBlogProject.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 30, nullable: false),
                    Slug = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(maxLength: 200, nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    EditTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Slug" },
                values: new object[] { 1, "Web Tasarım", "web-tasarım" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Slug" },
                values: new object[] { 2, "Web Yazılım", "web-yazilim" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Slug" },
                values: new object[] { 3, "Kurumsal", "kurumsal" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "AddTime", "CategoryId", "Content", "EditTime", "PhotoPath", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 21, 14, 0, 14, 283, DateTimeKind.Local).AddTicks(8258), 1, "Mükemmel bir web tasarımınız olabilir ama tüm cihazlara uyumlu değilse eksiktir. Projenizi kim, hangi cihazdan ziyaret edecek bilemezsiniz. Responsive tasarım, web sitesinin mobil ve cihazlara uyumlu oluşu sitenizi ziyaret eden kullanıcılara kullanım kolaylığı sağlar. Günümüzde internet kullanıcılarının % 70 i mobil cihazlardan gezinti yapıyor ve başta Google olmak üzere tüm arama motorları mobil uyumlu web sitelerine sıralamalarında öncelik tanımaktadır.Güncel tüm tarayıcılar, tabletler, mobil, her biri için web tasarımı, ekran genişliğine ve çözünürlüğüne göre şekillendirilir böylece ekrana tam uyum sağlar.Kısacası kalıplaşmış mobil tasarımlar değil, projenize uyumlu tasarımlar.Ayrı ayrı veri tabanı yok.Tüm tasarımlar aynı panelden güncellenir.Hatta dilerseniz bambaşka bir responsive tasarımı... İnternete özel web tasarım projesinin yanında, isterseniz mobillere özel tasarımlar yapabiliriz. Yenilikçi bir web sayfasına sahip olmak için responsive tasarım önemlidir.Kullanım kolaylığı için tasarımın birbirinden farklı olan ekran çözünürlüklerine uyum sağlaması önemlidir.Web sitenizdeki kusursuz tasarım diğer cihazlarda da farklılaşarak kusursuz olmalıdır.Menüler girilen cihaza uyum sağlayacak şekilde küçülüp üzerine dokunulduğunda açılmalı, metinler rahat okunmalı, resimler de ekran çözünürlüğüne göre esneyerek uygun tasarım elde edilmelidir. Tüm ticari şirketlerin web sitesi tasarımından beklentisi arama motorlarında üst sırada yer almak olduğuna göre artık responsive(mobil uyumluluk) vazgeçilmez bir ihtiyaç haline gelmiştir.Tekdüze olmayın, farklı olursanız farklı kalabilirsiniz.İyi görünmek için Atamedya ile çalışabilirsiniz..", new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(4496), "~/Images/mbUws.jpg", "mobil-uyumlu-web-sitesi", "Mobil uyumlu web sitesi" },
                    { 2, new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5611), 1, "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5625), "~/Images/bootsrap.jpg", "bootstrap-kullanmak-için-10-sebep", "Bootstrap Kullanmak İçin 10 Sebep" },
                    { 3, new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5680), 2, "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5684), "~/Images/bootsrap.jpg", "asp.net-core-ile-crud-islemleri", "ASP.NET Core ile CRUD işlemleri" },
                    { 4, new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5718), 2, "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5720), "~/Images/bootsrap.jpg", "vuejs-baslangic", "VUEjs Başlangıç" },
                    { 5, new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5751), 3, "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5753), "~/Images/bootsrap.jpg", "asp.net-core-ile-kurumsal-islemleri", "ASP.NET Core ile Kurumsal İşlemler" },
                    { 6, new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5789), 3, "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", new DateTime(2020, 6, 21, 14, 0, 14, 285, DateTimeKind.Local).AddTicks(5792), "~/Images/bootsrap.jpg", "vuejs-kurumsal", "VUEjs Kurumsal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
