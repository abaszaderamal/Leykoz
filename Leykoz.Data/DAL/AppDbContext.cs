using System;
using Leykoz.Core.Entities;
using Leykoz.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Leykoz.Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new InfoSlideConfig());
            builder.ApplyConfiguration(new NewsConfig());
            builder.ApplyConfiguration(new SiteSettingConfig());
            builder.ApplyConfiguration(new SlideConfig());
            builder.ApplyConfiguration(new SaviorConfig());
            builder.ApplyConfiguration(new TargetConfig());
            builder.ApplyConfiguration(new EventConfig());
            builder.ApplyConfiguration(new ReportConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new ReportYearConfig());
            builder.ApplyConfiguration(new ReportAmountConfig());

            #region Sider

            builder.Entity<SiteSetting>(p =>
            {
                p.HasData(new SiteSetting()
                    {
                        Id = 1,
                        Key = "fmsg",
                        Value =
                            @"    <p>Sizə <span id=""my__underline"">“Leykemiya ilə Mübarizə”</span>. İctimai Birliyi haqqında məlumat verərək bildirmək istəyirik ki, Birliyimiz könüllülər və donorlar tərəfindən qan xərçənginə <span id=""my__underline"">qarşı mübarizə</span> aparan uşaqlara və onların ailələrinə dəstək məqsədi ilə qurulmuş qeyri-hökümət təşkilatıdır. Birliyimiz 29 sentyabr 2006-cı ildə Azərbaycan Respublikası Ədliyyə Nazirliyi tərəfindən dövlət qeydiyyatına alınmışdır və öz fəaliyyətinin əsas məqsədi kimi gəlir əldə etməyi nəzərdə tutmamaqdadır.</p>"
                    }, new SiteSetting()
                    {
                        Id = 2,
                        Key = "card1",
                        Value = "https://www.youtube.com/"
                    },
                    new SiteSetting()
                    {
                        Id = 3,
                        Key = "card2",
                        Value = "https://www.fb.com/"
                    },
                    new SiteSetting()
                    {
                        Id = 4,
                        Key = "card3",
                        Value = "https://www.github.com/"
                    },
                    new SiteSetting()
                    {
                        Id = 5,
                        Key = "mission",
                        Value =
                            "  <p>Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və ailələrini leykemiya ilə mübarizədə tək qoymamaq, onları bu xəstəlikdən daha güclü olduqlarına inandırmaq və onlara sağlam gələcək bəxş etməkdir.</p><br><p>Bizim üçün leykemiya sadəcə sözdür, əsla hökm deyil!</p>"
                    }, new SiteSetting()
                    {
                        Id = 6,
                        Key = "about",
                        Value =
                            "<p>“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçənginə qarşı mübarizə aparan uşaqlara və onların ailələrinə dəstək məqsədi ilə qurulmuş qeyri-hökümət təşkilatıdır.</p><p>Birlik, 29 sentyabr 2006-cı ildə Azərbaycan Respublikası Ədliyyə Nazirliyi tərəfindən dövlət qeydiyyatına alınmışdır və öz fəaliyyətinin əsas məqsədi kimi gəlir əldə etməyi nəzərdə tutmamaqdadır.</p><p>“Leykemiya ilə Mübarizə” İctimai Birliyinin iştirakı və dəstəyi ilə mütəmadi olaraq müxtəlif xeyriyyə tədbirləri keçirilmiş və nəticədə toplanılmış vəsaitlər ilə uşaqlara dərman preparatları alınmış, şüa müalicəsində dəstək olunmuş və eləcə də ailələrə ərzaq yardımı göstərilmişdir.</p>"
                    }
                    ,
                    new SiteSetting()
                    {
                        Id = 7,
                        Key = "videoplink",
                        Value = "https://www.facebook.com/"
                    },
                    new SiteSetting()
                    {
                        Id = 8,
                        Key = "besupportivelink",
                        Value = "https://www.facebook.com/"
                    },
                    new SiteSetting()
                    {
                        Id = 9,
                        Key = "phone",
                        Value = "0554531254"
                    },
                    new SiteSetting()
                    {
                        Id = 10,
                        Key = "address",
                        Value = "demo"
                    },
                    new SiteSetting()
                    {
                        Id = 11,
                        Key = "email",
                        Value = "demo"
                    },
                    new SiteSetting()
                    {
                        Id = 12,
                        Key = "youtublelink",
                        Value = "demo"
                    },
                    new SiteSetting()
                    {
                        Id = 13,
                        Key = "footertxt",
                        Value = "demo"
                    },
                    new SiteSetting()
                    {
                        Id = 14,
                        Key = "fb",
                        Value = "demo"
                    },
                    new SiteSetting()
                    {
                        Id = 15,
                        Key = "insta",
                        Value = "demo"
                    },
                    new SiteSetting()
                    {
                        Id = 16,
                        Key = "twit",
                        Value = "demo"
                    },
                    new SiteSetting()
                    {
                        Id = 17,
                        Key = "linkedin",
                        Value = "demo"
                    },
                    new SiteSetting()
                    {
                        Id = 18,
                        Key = "youtube",
                        Value = "demo"
                    }
                );
            });


            builder.Entity<Slide>(p =>
            {
                p.HasData(new Slide()
                        { Id = 1, ImageFile = "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    new Slide()
                        { Id = 2, ImageFile = "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    new Slide()
                        { Id = 3, ImageFile = "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    new Slide()
                        { Id = 4, ImageFile = "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    new Slide()
                        { Id = 5, ImageFile = "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    new Slide()
                        { Id = 6, ImageFile = "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    new Slide()
                        { Id = 7, ImageFile = "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" });
            });

            builder.Entity<InfoSlide>(p =>
            {
                p.HasData(
                    new InfoSlide()
                    {
                        Id = 1,
                        FirstName = "1Nicky",
                        LastName = "Wolfe",
                        Title =
                            "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“",
                        Contetnt =
                            "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və",
                        MsgContetnt =
                            "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu",
                        ImageFile =
                            "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg",
                        CreatedDate = DateTime.Now,
                        MsgTitleContetnt = "ttt"
                    },
                    new InfoSlide()
                    {
                        Id = 2,
                        FirstName = "2Nicky",
                        LastName = "Wolfe",
                        Title =
                            "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“",
                        Contetnt =
                            "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və",
                        MsgContetnt =
                            "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu",
                        ImageFile =
                            "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg",
                        CreatedDate = DateTime.Now,
                        MsgTitleContetnt = "ttt"
                    },
                    new InfoSlide()
                    {
                        Id = 3,
                        FirstName = "3Nicky",
                        LastName = "Wolfe",
                        Title =
                            "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“",
                        Contetnt =
                            "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və",
                        MsgContetnt =
                            "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu",
                        ImageFile =
                            "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg",
                        CreatedDate = DateTime.Now,
                        MsgTitleContetnt = "ttt"
                    },
                    new InfoSlide()
                    {
                        Id = 4,
                        FirstName = "4Nicky",
                        LastName = "Wolfe",
                        Title =
                            "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“",
                        Contetnt =
                            "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və",
                        MsgContetnt =
                            "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu",
                        ImageFile =
                            "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg",
                        CreatedDate = DateTime.Now,
                        MsgTitleContetnt = "ttt"
                    },
                    new InfoSlide()
                    {
                        Id = 5,
                        FirstName = "5Nicky",
                        LastName = "Wolfe",
                        Title =
                            "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“",
                        Contetnt =
                            "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və",
                        MsgContetnt =
                            "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu",
                        ImageFile =
                            "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg",
                        CreatedDate = DateTime.Now,
                        MsgTitleContetnt = "ttt"
                    });
            });

            #endregion

            base.OnModelCreating(builder);
        }


        public DbSet<InfoSlide> InfoSlides { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<Savior> Saviors { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportAmount> ReportAmounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ReportYear> ReportYears { get; set; }
    }
}