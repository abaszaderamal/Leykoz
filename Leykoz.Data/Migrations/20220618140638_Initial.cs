using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Leykoz.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoSlides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Contetnt = table.Column<string>(nullable: false),
                    MsgContetnt = table.Column<string>(nullable: false),
                    ImageFile = table.Column<string>(nullable: false),
                    İsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    MsgTitleContetnt = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoSlides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Contetnt = table.Column<string>(nullable: false),
                    ImageFile = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Count = table.Column<int>(nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ImageURL = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrivateName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HeadTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saviors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ApplyType = table.Column<string>(nullable: false),
                    ApplyContent = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saviors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageFile = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ReportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportAmounts_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InfoSlides",
                columns: new[] { "Id", "Contetnt", "CreatedDate", "FirstName", "ImageFile", "LastName", "MsgContetnt", "MsgTitleContetnt", "Title" },
                values: new object[,]
                {
                    { 1, "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və", new DateTime(2022, 6, 18, 18, 6, 38, 559, DateTimeKind.Local).AddTicks(4948), "1Nicky", "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg", "Wolfe", "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu", "ttt", "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“" },
                    { 2, "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və", new DateTime(2022, 6, 18, 18, 6, 38, 560, DateTimeKind.Local).AddTicks(4699), "2Nicky", "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg", "Wolfe", "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu", "ttt", "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“" },
                    { 3, "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və", new DateTime(2022, 6, 18, 18, 6, 38, 560, DateTimeKind.Local).AddTicks(4740), "3Nicky", "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg", "Wolfe", "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu", "ttt", "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“" },
                    { 4, "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və", new DateTime(2022, 6, 18, 18, 6, 38, 560, DateTimeKind.Local).AddTicks(4744), "4Nicky", "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg", "Wolfe", "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu", "ttt", "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“" },
                    { 5, "Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və", new DateTime(2022, 6, 18, 18, 6, 38, 560, DateTimeKind.Local).AddTicks(4746), "5Nicky", "https://image.shutterstock.com/image-vector/tv-colour-bars-test-card-260nw-1723500997.jpg", "Wolfe", "Səadətdən məktub Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları vəBirliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Ardını oxu", "ttt", "“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçəngin“" }
                });

            migrationBuilder.InsertData(
                table: "SiteSettings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 18, "youtube", "demo" },
                    { 17, "linkedin", "demo" },
                    { 16, "twit", "demo" },
                    { 15, "insta", "demo" },
                    { 14, "fb", "demo" },
                    { 13, "footertxt", "demo" },
                    { 12, "youtublelink", "demo" },
                    { 11, "email", "demo" },
                    { 10, "address", "demo" },
                    { 8, "besupportivelink", "https://www.facebook.com/" },
                    { 7, "videoplink", "https://www.facebook.com/" },
                    { 6, "about", "<p>“Leykemiya ilə Mübarizə” İctimai Birliyi könüllülər və donorlar tərəfindən qan xərçənginə qarşı mübarizə aparan uşaqlara və onların ailələrinə dəstək məqsədi ilə qurulmuş qeyri-hökümət təşkilatıdır.</p><p>Birlik, 29 sentyabr 2006-cı ildə Azərbaycan Respublikası Ədliyyə Nazirliyi tərəfindən dövlət qeydiyyatına alınmışdır və öz fəaliyyətinin əsas məqsədi kimi gəlir əldə etməyi nəzərdə tutmamaqdadır.</p><p>“Leykemiya ilə Mübarizə” İctimai Birliyinin iştirakı və dəstəyi ilə mütəmadi olaraq müxtəlif xeyriyyə tədbirləri keçirilmiş və nəticədə toplanılmış vəsaitlər ilə uşaqlara dərman preparatları alınmış, şüa müalicəsində dəstək olunmuş və eləcə də ailələrə ərzaq yardımı göstərilmişdir.</p>" },
                    { 5, "mission", "  <p>Birliyimizin əsas missiyası cəmiyyətimizi leykemiya xəstəliyi (qan xərçəngi) haqqında maarifləndirmək və bu xəstəliklə mübarizə aparan uşaqlara dəstək proqramları üçün vəsait toplamaqdır. Məqsədimiz uşaqları və ailələrini leykemiya ilə mübarizədə tək qoymamaq, onları bu xəstəlikdən daha güclü olduqlarına inandırmaq və onlara sağlam gələcək bəxş etməkdir.</p><br><p>Bizim üçün leykemiya sadəcə sözdür, əsla hökm deyil!</p>" },
                    { 4, "card3", "https://www.github.com/" },
                    { 3, "card2", "https://www.fb.com/" },
                    { 2, "card1", "https://www.youtube.com/" },
                    { 1, "fmsg", "    <p>Sizə <span id=\"my__underline\">“Leykemiya ilə Mübarizə”</span>. İctimai Birliyi haqqında məlumat verərək bildirmək istəyirik ki, Birliyimiz könüllülər və donorlar tərəfindən qan xərçənginə <span id=\"my__underline\">qarşı mübarizə</span> aparan uşaqlara və onların ailələrinə dəstək məqsədi ilə qurulmuş qeyri-hökümət təşkilatıdır. Birliyimiz 29 sentyabr 2006-cı ildə Azərbaycan Respublikası Ədliyyə Nazirliyi tərəfindən dövlət qeydiyyatına alınmışdır və öz fəaliyyətinin əsas məqsədi kimi gəlir əldə etməyi nəzərdə tutmamaqdadır.</p>" },
                    { 9, "phone", "0554531254" }
                });

            migrationBuilder.InsertData(
                table: "Slide",
                columns: new[] { "Id", "ImageFile" },
                values: new object[,]
                {
                    { 6, "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    { 1, "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    { 2, "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    { 3, "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    { 4, "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    { 5, "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" },
                    { 7, "b6b09da3d6f15b0feb2d8794cee46fc8.jfif" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportAmounts_ReportId",
                table: "ReportAmounts",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "InfoSlides");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ReportAmounts");

            migrationBuilder.DropTable(
                name: "ReportYears");

            migrationBuilder.DropTable(
                name: "Saviors");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Slide");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
