using System;
using System.Collections.Generic;
using System.Text;
using CoreBlogProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreBlogProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Web Tasarım", Slug = "web-tasarım" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Web Yazılım", Slug = "web-yazilim" });
            builder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Kurumsal", Slug = "kurumsal" });

            #region Web Tasarım CID = 1 
            builder.Entity<Post>().HasData(new Post
            {
                PostId = 1,
                Title = "Mobil uyumlu web sitesi",
                Content = "Mükemmel bir web tasarımınız olabilir ama tüm cihazlara uyumlu değilse eksiktir. Projenizi kim, hangi cihazdan ziyaret edecek bilemezsiniz. Responsive tasarım, web sitesinin mobil ve cihazlara uyumlu oluşu sitenizi ziyaret eden kullanıcılara kullanım kolaylığı sağlar. Günümüzde internet kullanıcılarının % 70 i mobil cihazlardan gezinti yapıyor ve başta Google olmak üzere tüm arama motorları mobil uyumlu web sitelerine sıralamalarında öncelik tanımaktadır.Güncel tüm tarayıcılar, tabletler, mobil, her biri için web tasarımı, ekran genişliğine ve çözünürlüğüne göre şekillendirilir böylece ekrana tam uyum sağlar.Kısacası kalıplaşmış mobil tasarımlar değil, projenize uyumlu tasarımlar.Ayrı ayrı veri tabanı yok.Tüm tasarımlar aynı panelden güncellenir.Hatta dilerseniz bambaşka bir responsive tasarımı... İnternete özel web tasarım projesinin yanında, isterseniz mobillere özel tasarımlar yapabiliriz. Yenilikçi bir web sayfasına sahip olmak için responsive tasarım önemlidir.Kullanım kolaylığı için tasarımın birbirinden farklı olan ekran çözünürlüklerine uyum sağlaması önemlidir.Web sitenizdeki kusursuz tasarım diğer cihazlarda da farklılaşarak kusursuz olmalıdır.Menüler girilen cihaza uyum sağlayacak şekilde küçülüp üzerine dokunulduğunda açılmalı, metinler rahat okunmalı, resimler de ekran çözünürlüğüne göre esneyerek uygun tasarım elde edilmelidir. Tüm ticari şirketlerin web sitesi tasarımından beklentisi arama motorlarında üst sırada yer almak olduğuna göre artık responsive(mobil uyumluluk) vazgeçilmez bir ihtiyaç haline gelmiştir.Tekdüze olmayın, farklı olursanız farklı kalabilirsiniz.İyi görünmek için Atamedya ile çalışabilirsiniz..",
                Slug = "mobil-uyumlu-web-sitesi",
                CategoryId = 1,
                PhotoPath = "~/Images/mbUws.jpg",
                AddTime = DateTime.Now,
                EditTime = DateTime.Now
            });

            builder.Entity<Post>().HasData(new Post
            {
                PostId = 2,
                Title = "Bootstrap Kullanmak İçin 10 Sebep",
                Content = "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                Slug= "bootstrap-kullanmak-için-10-sebep",
                CategoryId = 1,
                PhotoPath = "~/Images/bootsrap.jpg",
                AddTime = DateTime.Now,
                EditTime = DateTime.Now
            });
            #endregion

            #region Web Yazılım CID = 2
            builder.Entity<Post>().HasData(new Post
            {
                PostId = 3,
                Title = "ASP.NET Core ile CRUD işlemleri",
                Content = "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                Slug = "asp.net-core-ile-crud-islemleri",
                CategoryId = 2,
                PhotoPath = "~/Images/bootsrap.jpg",
                AddTime = DateTime.Now,
                EditTime = DateTime.Now
            });
            builder.Entity<Post>().HasData(new Post
            {
                PostId = 4,
                Title = "VUEjs Başlangıç",
                Content = "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                Slug= "vuejs-baslangic",
                CategoryId = 2,
                PhotoPath = "~/Images/bootsrap.jpg",
                AddTime = DateTime.Now,
                EditTime = DateTime.Now
            });
            #endregion

            #region Kurumsal CID = 3
            builder.Entity<Post>().HasData(new Post
            {
                PostId = 5,
                Title = "ASP.NET Core ile Kurumsal İşlemler",
                Content = "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                Slug = "asp.net-core-ile-kurumsal-islemleri",
                CategoryId = 3,
                PhotoPath = "~/Images/bootsrap.jpg",
                AddTime = DateTime.Now,
                EditTime = DateTime.Now
            });
            builder.Entity<Post>().HasData(new Post
            {
                PostId = 6,
                Title = "VUEjs Kurumsal",
                Content = "dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                Slug = "vuejs-kurumsal",
                CategoryId = 3,
                PhotoPath = "~/Images/bootsrap.jpg",
                AddTime = DateTime.Now,
                EditTime = DateTime.Now
            });
            #endregion
        }
    }
}
