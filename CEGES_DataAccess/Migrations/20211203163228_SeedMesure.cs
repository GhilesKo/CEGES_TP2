using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CEGES_DataAccess.Migrations
{
    public partial class SeedMesure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1, 1, 1, 4050m },
                    { 922, 58, 26, 0m },
                    { 921, 58, 25, 0m },
                    { 920, 58, 24, 0m },
                    { 919, 58, 23, 0m },
                    { 918, 58, 22, 0m },
                    { 917, 58, 21, 0m },
                    { 916, 58, 20, 0m },
                    { 915, 58, 19, 0m },
                    { 914, 58, 18, 0m },
                    { 913, 58, 17, 0m },
                    { 912, 57, 32, 1740m },
                    { 911, 57, 31, 1249m },
                    { 910, 57, 30, 1075m },
                    { 909, 57, 29, 1437m },
                    { 908, 57, 28, 1448m },
                    { 907, 57, 27, 1532m },
                    { 906, 57, 26, 1034m },
                    { 923, 58, 27, 0m },
                    { 924, 58, 28, 0m },
                    { 925, 58, 29, 0m },
                    { 926, 58, 30, 0m },
                    { 944, 59, 32, 75.81m },
                    { 943, 59, 31, 6.66m },
                    { 942, 59, 30, 86.71m },
                    { 941, 59, 29, 76m },
                    { 940, 59, 28, 54.53m },
                    { 939, 59, 27, 66.34m },
                    { 938, 59, 26, 12.71m },
                    { 937, 59, 25, 78.46m },
                    { 905, 57, 25, 1186m },
                    { 936, 59, 24, 66.03m },
                    { 934, 59, 22, 30.71m },
                    { 933, 59, 21, 48.31m },
                    { 932, 59, 20, 57.08m },
                    { 931, 59, 19, 98.97m },
                    { 930, 59, 18, 47.83m },
                    { 929, 59, 17, 60.28m },
                    { 928, 58, 32, 0m },
                    { 927, 58, 31, 0m },
                    { 935, 59, 23, 90.45m },
                    { 945, 60, 17, 67.53m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 904, 57, 24, 1759m },
                    { 902, 57, 22, 1093m },
                    { 879, 55, 31, 90.3m },
                    { 878, 55, 30, 86.3m },
                    { 877, 55, 29, 93.8m },
                    { 876, 55, 28, 89.3m },
                    { 875, 55, 27, 88.9m },
                    { 874, 55, 26, 88.9m },
                    { 873, 55, 25, 94.3m },
                    { 872, 55, 24, 82m },
                    { 871, 55, 23, 81.4m },
                    { 870, 55, 22, 93.3m },
                    { 869, 55, 21, 94.1m },
                    { 868, 55, 20, 93.5m },
                    { 867, 55, 19, 85.9m },
                    { 866, 55, 18, 88.4m },
                    { 865, 55, 17, 93.4m },
                    { 864, 54, 32, 28.5m },
                    { 863, 54, 31, 51.5m },
                    { 880, 55, 32, 91.1m },
                    { 881, 56, 17, 16.6m },
                    { 882, 56, 18, 18.52m },
                    { 883, 56, 19, 22.86m },
                    { 901, 57, 21, 1498m },
                    { 900, 57, 20, 1304m },
                    { 899, 57, 19, 1661m },
                    { 898, 57, 18, 1641m },
                    { 897, 57, 17, 1015m },
                    { 896, 56, 32, 16.39m },
                    { 895, 56, 31, 11.53m },
                    { 894, 56, 30, 8.45m },
                    { 903, 57, 23, 1134m },
                    { 893, 56, 29, 7.44m },
                    { 891, 56, 27, 12.04m },
                    { 890, 56, 26, 10.99m },
                    { 889, 56, 25, 14.56m },
                    { 888, 56, 24, 19.08m },
                    { 887, 56, 23, 23.95m },
                    { 886, 56, 22, 19.56m },
                    { 885, 56, 21, 23.43m },
                    { 884, 56, 20, 26.76m },
                    { 892, 56, 28, 8.71m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 862, 54, 30, 51.8m },
                    { 946, 60, 18, 51.65m },
                    { 948, 60, 20, 75.79m },
                    { 1008, 63, 32, 92332m },
                    { 1007, 63, 31, 106827m },
                    { 1006, 63, 30, 120561m },
                    { 1005, 63, 29, 117721m },
                    { 1004, 63, 28, 128227m },
                    { 1003, 63, 27, 133549m },
                    { 1002, 63, 26, 124761m },
                    { 1001, 63, 25, 136982m },
                    { 1000, 63, 24, 142945m },
                    { 999, 63, 23, 134559m },
                    { 998, 63, 22, 122985m },
                    { 997, 63, 21, 173204m },
                    { 996, 63, 20, 236499m },
                    { 995, 63, 19, 298290m },
                    { 994, 63, 18, 350782m },
                    { 993, 63, 17, 397412m },
                    { 992, 62, 32, 93.69m },
                    { 1009, 64, 17, 99.9m },
                    { 1010, 64, 18, 91.8m },
                    { 1011, 64, 19, 91.6m },
                    { 1012, 64, 20, 96.7m },
                    { 1030, 65, 22, 109.8m },
                    { 1029, 65, 21, 113.8m },
                    { 1028, 65, 20, 148.8m },
                    { 1027, 65, 19, 149.2m },
                    { 1026, 65, 18, 111.6m },
                    { 1025, 65, 17, 107.8m },
                    { 1024, 64, 32, 108.7m },
                    { 1023, 64, 31, 107.7m },
                    { 991, 62, 31, 94.38m },
                    { 1022, 64, 30, 105.7m },
                    { 1020, 64, 28, 108m },
                    { 1019, 64, 27, 93.6m },
                    { 1018, 64, 26, 93.8m },
                    { 1017, 64, 25, 108.8m },
                    { 1016, 64, 24, 91.3m },
                    { 1015, 64, 23, 93.9m },
                    { 1014, 64, 22, 108.5m },
                    { 1013, 64, 21, 104.5m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1021, 64, 29, 90m },
                    { 947, 60, 19, 62.55m },
                    { 990, 62, 30, 93.94m },
                    { 988, 62, 28, 95.18m },
                    { 965, 61, 21, 8.61m },
                    { 964, 61, 20, 6.92m },
                    { 963, 61, 19, 9.9m },
                    { 962, 61, 18, 10.33m },
                    { 961, 61, 17, 12.15m },
                    { 960, 60, 32, 63.46m },
                    { 959, 60, 31, 50.15m },
                    { 958, 60, 30, 21.79m },
                    { 957, 60, 29, 51.52m },
                    { 956, 60, 28, 60.97m },
                    { 955, 60, 27, 29.66m },
                    { 954, 60, 26, 35.66m },
                    { 953, 60, 25, 69.91m },
                    { 952, 60, 24, 31.76m },
                    { 951, 60, 23, 30.27m },
                    { 950, 60, 22, 26.89m },
                    { 949, 60, 21, 39.44m },
                    { 966, 61, 22, 8.56m },
                    { 967, 61, 23, 7.72m },
                    { 968, 61, 24, 9.77m },
                    { 969, 61, 25, 8.02m },
                    { 987, 62, 27, 90.11m },
                    { 986, 62, 26, 91.14m },
                    { 985, 62, 25, 91.97m },
                    { 984, 62, 24, 88.69m },
                    { 983, 62, 23, 88.8m },
                    { 982, 62, 22, 95.98m },
                    { 981, 62, 21, 89.6m },
                    { 980, 62, 20, 95.6m },
                    { 989, 62, 29, 88.18m },
                    { 979, 62, 19, 95.32m },
                    { 977, 62, 17, 96.86m },
                    { 976, 61, 32, 15.82m },
                    { 975, 61, 31, 12.88m },
                    { 974, 61, 30, 12.1m },
                    { 973, 61, 29, 12.15m },
                    { 972, 61, 28, 11.73m },
                    { 971, 61, 27, 11.08m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 970, 61, 26, 8.31m },
                    { 978, 62, 18, 88.59m },
                    { 1031, 65, 23, 100.4m },
                    { 861, 54, 29, 11.2m },
                    { 859, 54, 27, 84.4m },
                    { 750, 47, 30, 0m },
                    { 749, 47, 29, 0m },
                    { 748, 47, 28, 0m },
                    { 747, 47, 27, 0m },
                    { 746, 47, 26, 0m },
                    { 745, 47, 25, 0m },
                    { 744, 47, 24, 0m },
                    { 743, 47, 23, 0m },
                    { 742, 47, 22, 0m },
                    { 741, 47, 21, 0m },
                    { 740, 47, 20, 0m },
                    { 739, 47, 19, 0m },
                    { 738, 47, 18, 0m },
                    { 737, 47, 17, 0m },
                    { 736, 46, 32, 583m },
                    { 735, 46, 31, 18m },
                    { 734, 46, 30, 235m },
                    { 751, 47, 31, 0m },
                    { 752, 47, 32, 0m },
                    { 753, 48, 17, 19m },
                    { 754, 48, 18, 47.16m },
                    { 772, 49, 20, 23.92m },
                    { 771, 49, 19, 23.93m },
                    { 770, 49, 18, 21.17m },
                    { 769, 49, 17, 18.98m },
                    { 768, 48, 32, 10.58m },
                    { 767, 48, 31, 8.55m },
                    { 766, 48, 30, 22.5m },
                    { 765, 48, 29, 10.52m },
                    { 733, 46, 29, 493m },
                    { 764, 48, 28, 9.15m },
                    { 762, 48, 26, 43.39m },
                    { 761, 48, 25, 43.68m },
                    { 760, 48, 24, 39.03m },
                    { 759, 48, 23, 23.94m },
                    { 758, 48, 22, 23.88m },
                    { 757, 48, 21, 46.53m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 756, 48, 20, 42.59m },
                    { 755, 48, 19, 38.2m },
                    { 763, 48, 27, 23.6m },
                    { 773, 49, 21, 21.67m },
                    { 732, 46, 28, 541m },
                    { 730, 46, 26, 587m },
                    { 707, 45, 19, 16167m },
                    { 706, 45, 18, 13721m },
                    { 705, 45, 17, 17660m },
                    { 704, 44, 32, 0m },
                    { 703, 44, 31, 0m },
                    { 702, 44, 30, 0m },
                    { 701, 44, 29, 0m },
                    { 700, 44, 28, 0m },
                    { 699, 44, 27, 0m },
                    { 698, 44, 26, 0m },
                    { 697, 44, 25, 0m },
                    { 696, 44, 24, 0m },
                    { 695, 44, 23, 0m },
                    { 694, 44, 22, 0m },
                    { 693, 44, 21, 0m },
                    { 692, 44, 20, 0m },
                    { 691, 44, 19, 0m },
                    { 708, 45, 20, 20004m },
                    { 709, 45, 21, 16661m },
                    { 710, 45, 22, 17304m },
                    { 711, 45, 23, 14680m },
                    { 729, 46, 25, 656m },
                    { 728, 46, 24, 650m },
                    { 727, 46, 23, 621m },
                    { 726, 46, 22, 434m },
                    { 725, 46, 21, 413m },
                    { 724, 46, 20, 671m },
                    { 723, 46, 19, 657m },
                    { 722, 46, 18, 455m },
                    { 731, 46, 27, 636m },
                    { 721, 46, 17, 471m },
                    { 719, 45, 31, 1453m },
                    { 718, 45, 30, 13687m },
                    { 717, 45, 29, 28957m },
                    { 716, 45, 28, 25343m },
                    { 715, 45, 27, 22893m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 714, 45, 26, 19964m },
                    { 713, 45, 25, 17994m },
                    { 712, 45, 24, 16162m },
                    { 720, 45, 32, 27613m },
                    { 860, 54, 28, 81.5m },
                    { 774, 49, 22, 19.4m },
                    { 776, 49, 24, 17.81m },
                    { 836, 53, 20, 107.4m },
                    { 835, 53, 19, 90m },
                    { 834, 53, 18, 96m },
                    { 833, 53, 17, 109.5m },
                    { 832, 52, 32, 661565m },
                    { 831, 52, 31, 616127m },
                    { 830, 52, 30, 592971m },
                    { 829, 52, 29, 534301m },
                    { 828, 52, 28, 618860m },
                    { 827, 52, 27, 771233m },
                    { 826, 52, 26, 663109m },
                    { 825, 52, 25, 599333m },
                    { 824, 52, 24, 618335m },
                    { 823, 52, 23, 687748m },
                    { 822, 52, 22, 813013m },
                    { 821, 52, 21, 857729m },
                    { 820, 52, 20, 1145096m },
                    { 837, 53, 21, 68.4m },
                    { 838, 53, 22, 103.2m },
                    { 839, 53, 23, 60.6m },
                    { 840, 53, 24, 106.8m },
                    { 858, 54, 26, 25.8m },
                    { 857, 54, 25, 40m },
                    { 856, 54, 24, 72.1m },
                    { 855, 54, 23, 83.5m },
                    { 854, 54, 22, 41m },
                    { 853, 54, 21, 70.2m },
                    { 852, 54, 20, 82.7m },
                    { 851, 54, 19, 70.9m },
                    { 819, 52, 19, 1011121m },
                    { 850, 54, 18, 19.8m },
                    { 848, 53, 32, 82.9m },
                    { 847, 53, 31, 94m },
                    { 846, 53, 30, 73.6m },
                    { 845, 53, 29, 108.3m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 844, 53, 28, 101.5m },
                    { 843, 53, 27, 75.5m },
                    { 842, 53, 26, 92.1m },
                    { 841, 53, 25, 74.6m },
                    { 849, 54, 17, 78.9m },
                    { 775, 49, 23, 18.03m },
                    { 818, 52, 18, 997178m },
                    { 816, 51, 32, 89.37m },
                    { 793, 50, 25, 101.87m },
                    { 792, 50, 24, 33.07m },
                    { 791, 50, 23, 24.78m },
                    { 790, 50, 22, 43.91m },
                    { 789, 50, 21, 66.3m },
                    { 788, 50, 20, 53.08m },
                    { 787, 50, 19, 30.28m },
                    { 786, 50, 18, 91.07m },
                    { 785, 50, 17, 44.49m },
                    { 784, 49, 32, 19.17m },
                    { 783, 49, 31, 1.01m },
                    { 782, 49, 30, 10.47m },
                    { 781, 49, 29, 17.51m },
                    { 780, 49, 28, 18.11m },
                    { 779, 49, 27, 17.97m },
                    { 778, 49, 26, 17.52m },
                    { 777, 49, 25, 17.19m },
                    { 794, 50, 26, 48.92m },
                    { 795, 50, 27, 79.21m },
                    { 796, 50, 28, 41.1m },
                    { 797, 50, 29, 84.37m },
                    { 815, 51, 31, 19.65m },
                    { 814, 51, 30, 75.24m },
                    { 813, 51, 29, 88.95m },
                    { 812, 51, 28, 89.34m },
                    { 811, 51, 27, 92.65m },
                    { 810, 51, 26, 93.42m },
                    { 809, 51, 25, 94.05m },
                    { 808, 51, 24, 95.1m },
                    { 817, 52, 17, 1195635m },
                    { 807, 51, 23, 96.96m },
                    { 805, 51, 21, 91.74m },
                    { 804, 51, 20, 90.75m },
                    { 803, 51, 19, 90.92m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 802, 51, 18, 91.81m },
                    { 801, 51, 17, 88.82m },
                    { 800, 50, 32, 26.37m },
                    { 799, 50, 31, 12.3m },
                    { 798, 50, 30, 55.96m },
                    { 806, 51, 22, 92.28m },
                    { 690, 44, 18, 0m },
                    { 1032, 65, 24, 117.3m },
                    { 1034, 65, 26, 108.3m },
                    { 1266, 80, 18, 341m },
                    { 1265, 80, 17, 295m },
                    { 1264, 79, 32, 39.47m },
                    { 1263, 79, 31, 44.46m },
                    { 1262, 79, 30, 49.03m },
                    { 1261, 79, 29, 47.08m },
                    { 1260, 79, 28, 49.45m },
                    { 1259, 79, 27, 45m },
                    { 1258, 79, 26, 48.88m },
                    { 1257, 79, 25, 51.1m },
                    { 1256, 79, 24, 46.96m },
                    { 1255, 79, 23, 45.38m },
                    { 1254, 79, 22, 48.86m },
                    { 1253, 79, 21, 45.93m },
                    { 1252, 79, 20, 45.29m },
                    { 1251, 79, 19, 48.76m },
                    { 1250, 79, 18, 51.28m },
                    { 1267, 80, 19, 388m },
                    { 1268, 80, 20, 392m },
                    { 1269, 80, 21, 313m },
                    { 1270, 80, 22, 303m },
                    { 1288, 81, 24, 0m },
                    { 1287, 81, 23, 0m },
                    { 1286, 81, 22, 0m },
                    { 1285, 81, 21, 0m },
                    { 1284, 81, 20, 0m },
                    { 1283, 81, 19, 0m },
                    { 1282, 81, 18, 0m },
                    { 1281, 81, 17, 0m },
                    { 1249, 79, 17, 48.47m },
                    { 1280, 80, 32, 269m },
                    { 1278, 80, 30, 312m },
                    { 1277, 80, 29, 307m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1276, 80, 28, 256m },
                    { 1275, 80, 27, 284m },
                    { 1274, 80, 26, 239m },
                    { 1273, 80, 25, 337m },
                    { 1272, 80, 24, 315m },
                    { 1271, 80, 23, 279m },
                    { 1279, 80, 31, 368m },
                    { 1289, 81, 25, 0m },
                    { 1248, 78, 32, 0m },
                    { 1246, 78, 30, 862m },
                    { 1223, 77, 23, 0m },
                    { 1222, 77, 22, 0m },
                    { 1221, 77, 21, 0m },
                    { 1220, 77, 20, 0m },
                    { 1219, 77, 19, 0m },
                    { 1218, 77, 18, 0m },
                    { 1217, 77, 17, 0m },
                    { 1216, 76, 32, 59.7m },
                    { 1215, 76, 31, 69.7m },
                    { 1214, 76, 30, 68m },
                    { 1213, 76, 29, 69.8m },
                    { 1212, 76, 28, 60.9m },
                    { 1211, 76, 27, 61.5m },
                    { 1210, 76, 26, 51.3m },
                    { 1209, 76, 25, 61.6m },
                    { 1208, 76, 24, 66m },
                    { 1207, 76, 23, 60m },
                    { 1224, 77, 24, 0m },
                    { 1225, 77, 25, 0m },
                    { 1226, 77, 26, 0m },
                    { 1227, 77, 27, 0m },
                    { 1245, 78, 29, 3060m },
                    { 1244, 78, 28, 4252m },
                    { 1243, 78, 27, 0m },
                    { 1242, 78, 26, 0m },
                    { 1241, 78, 25, 2304m },
                    { 1240, 78, 24, 0m },
                    { 1239, 78, 23, 0m },
                    { 1238, 78, 22, 1261m },
                    { 1247, 78, 31, 0m },
                    { 1237, 78, 21, 3479m },
                    { 1235, 78, 19, 0m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1234, 78, 18, 2682m },
                    { 1233, 78, 17, 775m },
                    { 1232, 77, 32, 0m },
                    { 1231, 77, 31, 0m },
                    { 1230, 77, 30, 0m },
                    { 1229, 77, 29, 0m },
                    { 1228, 77, 28, 0m },
                    { 1236, 78, 20, 3688m },
                    { 1206, 76, 22, 50.8m },
                    { 1290, 81, 26, 0m },
                    { 1292, 81, 28, 0m },
                    { 1352, 85, 24, 80.91m },
                    { 1351, 85, 23, 103.46m },
                    { 1350, 85, 22, 24.69m },
                    { 1349, 85, 21, 54.54m },
                    { 1348, 85, 20, 43.34m },
                    { 1347, 85, 19, 32.79m },
                    { 1346, 85, 18, 31.1m },
                    { 1345, 85, 17, 26.63m },
                    { 1344, 84, 32, 22.32m },
                    { 1343, 84, 31, 24.71m },
                    { 1342, 84, 30, 22.18m },
                    { 1341, 84, 29, 20.1m },
                    { 1340, 84, 28, 17.87m },
                    { 1339, 84, 27, 20.03m },
                    { 1338, 84, 26, 21.26m },
                    { 1337, 84, 25, 24.21m },
                    { 1336, 84, 24, 23.3m },
                    { 1353, 85, 25, 90.06m },
                    { 1354, 85, 26, 96.15m },
                    { 1355, 85, 27, 77.12m },
                    { 1356, 85, 28, 44.71m },
                    { 1374, 86, 30, 91.12m },
                    { 1373, 86, 29, 97.77m },
                    { 1372, 86, 28, 91.16m },
                    { 1371, 86, 27, 89.24m },
                    { 1370, 86, 26, 96.21m },
                    { 1369, 86, 25, 92.42m },
                    { 1368, 86, 24, 95.77m },
                    { 1367, 86, 23, 93.34m },
                    { 1335, 84, 23, 25.59m },
                    { 1366, 86, 22, 93.88m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1364, 86, 20, 93.53m },
                    { 1363, 86, 19, 90.48m },
                    { 1362, 86, 18, 94.7m },
                    { 1361, 86, 17, 90.46m },
                    { 1360, 85, 32, 83.92m },
                    { 1359, 85, 31, 93.86m },
                    { 1358, 85, 30, 64.14m },
                    { 1357, 85, 29, 69.84m },
                    { 1365, 86, 21, 94.22m },
                    { 1291, 81, 27, 0m },
                    { 1334, 84, 22, 26.45m },
                    { 1332, 84, 20, 26.91m },
                    { 1309, 82, 29, 0m },
                    { 1308, 82, 28, 0m },
                    { 1307, 82, 27, 0m },
                    { 1306, 82, 26, 0m },
                    { 1305, 82, 25, 0m },
                    { 1304, 82, 24, 0m },
                    { 1303, 82, 23, 0m },
                    { 1302, 82, 22, 0m },
                    { 1301, 82, 21, 0m },
                    { 1300, 82, 20, 0m },
                    { 1299, 82, 19, 0m },
                    { 1298, 82, 18, 0m },
                    { 1297, 82, 17, 0m },
                    { 1296, 81, 32, 0m },
                    { 1295, 81, 31, 0m },
                    { 1294, 81, 30, 0m },
                    { 1293, 81, 29, 0m },
                    { 1310, 82, 30, 0m },
                    { 1311, 82, 31, 0m },
                    { 1312, 82, 32, 0m },
                    { 1313, 83, 17, 64.97m },
                    { 1331, 84, 19, 25.62m },
                    { 1330, 84, 18, 23.18m },
                    { 1329, 84, 17, 24.87m },
                    { 1328, 83, 32, 21.7m },
                    { 1327, 83, 31, 59.18m },
                    { 1326, 83, 30, 29.53m },
                    { 1325, 83, 29, 43.16m },
                    { 1324, 83, 28, 33.57m },
                    { 1333, 84, 21, 24.25m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1323, 83, 27, 48.59m },
                    { 1321, 83, 25, 66.02m },
                    { 1320, 83, 24, 77.97m },
                    { 1319, 83, 23, 33.67m },
                    { 1318, 83, 22, 63.59m },
                    { 1317, 83, 21, 59.46m },
                    { 1316, 83, 20, 27.42m },
                    { 1315, 83, 19, 35.21m },
                    { 1314, 83, 18, 39.97m },
                    { 1322, 83, 26, 36.26m },
                    { 1033, 65, 25, 116.4m },
                    { 1205, 76, 21, 54.6m },
                    { 1203, 76, 19, 54.2m },
                    { 1094, 69, 22, 0m },
                    { 1093, 69, 21, 0m },
                    { 1092, 69, 20, 0m },
                    { 1091, 69, 19, 0m },
                    { 1090, 69, 18, 0m },
                    { 1089, 69, 17, 0m },
                    { 1088, 68, 32, 0m },
                    { 1087, 68, 31, 0m },
                    { 1086, 68, 30, 0m },
                    { 1085, 68, 29, 0m },
                    { 1084, 68, 28, 0m },
                    { 1083, 68, 27, 0m },
                    { 1082, 68, 26, 0m },
                    { 1081, 68, 25, 0m },
                    { 1080, 68, 24, 0m },
                    { 1079, 68, 23, 0m },
                    { 1078, 68, 22, 0m },
                    { 1095, 69, 23, 0m },
                    { 1096, 69, 24, 0m },
                    { 1097, 69, 25, 0m },
                    { 1098, 69, 26, 0m },
                    { 1116, 70, 28, 83.32m },
                    { 1115, 70, 27, 65.76m },
                    { 1114, 70, 26, 67.44m },
                    { 1113, 70, 25, 57.98m },
                    { 1112, 70, 24, 74.81m },
                    { 1111, 70, 23, 54.11m },
                    { 1110, 70, 22, 85.97m },
                    { 1109, 70, 21, 80.82m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1077, 68, 21, 0m },
                    { 1108, 70, 20, 61.58m },
                    { 1106, 70, 18, 64.9m },
                    { 1105, 70, 17, 93.29m },
                    { 1104, 69, 32, 0m },
                    { 1103, 69, 31, 0m },
                    { 1102, 69, 30, 0m },
                    { 1101, 69, 29, 0m },
                    { 1100, 69, 28, 0m },
                    { 1099, 69, 27, 0m },
                    { 1107, 70, 19, 71.29m },
                    { 1117, 70, 29, 75.05m },
                    { 1076, 68, 20, 0m },
                    { 1074, 68, 18, 0m },
                    { 1051, 66, 27, 0m },
                    { 1050, 66, 26, 0m },
                    { 1049, 66, 25, 0m },
                    { 1048, 66, 24, 0m },
                    { 1047, 66, 23, 0m },
                    { 1046, 66, 22, 0m },
                    { 1045, 66, 21, 0m },
                    { 1044, 66, 20, 0m },
                    { 1043, 66, 19, 0m },
                    { 1042, 66, 18, 0m },
                    { 1041, 66, 17, 0m },
                    { 1040, 65, 32, 114.6m },
                    { 1039, 65, 31, 117.3m },
                    { 1038, 65, 30, 143.3m },
                    { 1037, 65, 29, 117.7m },
                    { 1036, 65, 28, 132.5m },
                    { 1035, 65, 27, 142.2m },
                    { 1052, 66, 28, 0m },
                    { 1053, 66, 29, 0m },
                    { 1054, 66, 30, 0m },
                    { 1055, 66, 31, 0m },
                    { 1073, 68, 17, 0m },
                    { 1072, 67, 32, 2938m },
                    { 1071, 67, 31, 2217m },
                    { 1070, 67, 30, 2029m },
                    { 1069, 67, 29, 3142m },
                    { 1068, 67, 28, 3240m },
                    { 1067, 67, 27, 2998m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1066, 67, 26, 2072m },
                    { 1075, 68, 19, 0m },
                    { 1065, 67, 25, 2698m },
                    { 1063, 67, 23, 2432m },
                    { 1062, 67, 22, 2214m },
                    { 1061, 67, 21, 2094m },
                    { 1060, 67, 20, 2176m },
                    { 1059, 67, 19, 3458m },
                    { 1058, 67, 18, 2043m },
                    { 1057, 67, 17, 2745m },
                    { 1056, 66, 32, 0m },
                    { 1064, 67, 24, 2325m },
                    { 1204, 76, 20, 66.7m },
                    { 1118, 70, 30, 54.79m },
                    { 1120, 70, 32, 68.05m },
                    { 1180, 74, 28, 82590m },
                    { 1179, 74, 27, 73614m },
                    { 1178, 74, 26, 67708m },
                    { 1177, 74, 25, 76947m },
                    { 1176, 74, 24, 66260m },
                    { 1175, 74, 23, 57531m },
                    { 1174, 74, 22, 56905m },
                    { 1173, 74, 21, 59036m },
                    { 1172, 74, 20, 54691m },
                    { 1171, 74, 19, 48365m },
                    { 1170, 74, 18, 60249m },
                    { 1169, 74, 17, 66023m },
                    { 1168, 73, 32, 89.64m },
                    { 1167, 73, 31, 92.84m },
                    { 1166, 73, 30, 89.54m },
                    { 1165, 73, 29, 91.67m },
                    { 1164, 73, 28, 89.76m },
                    { 1181, 74, 29, 91813m },
                    { 1182, 74, 30, 108657m },
                    { 1183, 74, 31, 105649m },
                    { 1184, 74, 32, 109447m },
                    { 1202, 76, 18, 50.4m },
                    { 1201, 76, 17, 52.4m },
                    { 1200, 75, 32, 53.7m },
                    { 1199, 75, 31, 48.8m },
                    { 1198, 75, 30, 61.1m },
                    { 1197, 75, 29, 25.1m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1196, 75, 28, 83.5m },
                    { 1195, 75, 27, 54.3m },
                    { 1163, 73, 27, 91.78m },
                    { 1194, 75, 26, 71.3m },
                    { 1192, 75, 24, 42.2m },
                    { 1191, 75, 23, 21.9m },
                    { 1190, 75, 22, 65.3m },
                    { 1189, 75, 21, 19m },
                    { 1188, 75, 20, 74.9m },
                    { 1187, 75, 19, 44.6m },
                    { 1186, 75, 18, 30.7m },
                    { 1185, 75, 17, 39.4m },
                    { 1193, 75, 25, 65.8m },
                    { 1119, 70, 31, 87.19m },
                    { 1162, 73, 26, 89.59m },
                    { 1160, 73, 24, 97.32m },
                    { 1137, 72, 17, 69.6m },
                    { 1136, 71, 32, 18.57m },
                    { 1135, 71, 31, 19.08m },
                    { 1134, 71, 30, 18.96m },
                    { 1133, 71, 29, 17.69m },
                    { 1132, 71, 28, 20.16m },
                    { 1131, 71, 27, 21.16m },
                    { 1130, 71, 26, 23.22m },
                    { 1129, 71, 25, 25.57m },
                    { 1128, 71, 24, 23.55m },
                    { 1127, 71, 23, 22.54m },
                    { 1126, 71, 22, 19.62m },
                    { 1125, 71, 21, 20.26m },
                    { 1124, 71, 20, 23.21m },
                    { 1123, 71, 19, 20.86m },
                    { 1122, 71, 18, 23.16m },
                    { 1121, 71, 17, 20.53m },
                    { 1138, 72, 18, 64.38m },
                    { 1139, 72, 19, 34.15m },
                    { 1140, 72, 20, 43.37m },
                    { 1141, 72, 21, 99.62m },
                    { 1159, 73, 23, 91.73m },
                    { 1158, 73, 22, 97.13m },
                    { 1157, 73, 21, 91.56m },
                    { 1156, 73, 20, 97.46m },
                    { 1155, 73, 19, 96.31m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 1154, 73, 18, 96.32m },
                    { 1153, 73, 17, 97.94m },
                    { 1152, 72, 32, 25.85m },
                    { 1161, 73, 25, 97.26m },
                    { 1151, 72, 31, 86.16m },
                    { 1149, 72, 29, 89.44m },
                    { 1148, 72, 28, 90.03m },
                    { 1147, 72, 27, 81.14m },
                    { 1146, 72, 26, 25.42m },
                    { 1145, 72, 25, 83.49m },
                    { 1144, 72, 24, 49.78m },
                    { 1143, 72, 23, 72.18m },
                    { 1142, 72, 22, 43.93m },
                    { 1150, 72, 30, 42.72m },
                    { 689, 44, 17, 0m },
                    { 688, 43, 32, 1094.2m },
                    { 687, 43, 31, 50.6m },
                    { 233, 15, 25, 0m },
                    { 232, 15, 24, 0m },
                    { 231, 15, 23, 0m },
                    { 230, 15, 22, 0m },
                    { 229, 15, 21, 0m },
                    { 228, 15, 20, 0m },
                    { 227, 15, 19, 0m },
                    { 226, 15, 18, 0m },
                    { 225, 15, 17, 0m },
                    { 224, 14, 32, 675.7m },
                    { 223, 14, 31, 328.7m },
                    { 222, 14, 30, 238.4m },
                    { 221, 14, 29, 287.3m },
                    { 220, 14, 28, 397.1m },
                    { 219, 14, 27, 481.1m },
                    { 218, 14, 26, 267.5m },
                    { 217, 14, 25, 250.4m },
                    { 234, 15, 26, 0m },
                    { 235, 15, 27, 0m },
                    { 236, 15, 28, 0m },
                    { 237, 15, 29, 0m },
                    { 255, 16, 31, 34337m },
                    { 254, 16, 30, 31061m },
                    { 253, 16, 29, 31192m },
                    { 252, 16, 28, 27023m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 251, 16, 27, 25120m },
                    { 250, 16, 26, 25504m },
                    { 249, 16, 25, 29929m },
                    { 248, 16, 24, 27095m },
                    { 216, 14, 24, 680.1m },
                    { 247, 16, 23, 31966m },
                    { 245, 16, 21, 39643m },
                    { 244, 16, 20, 42478m },
                    { 243, 16, 19, 46518m },
                    { 242, 16, 18, 41931m },
                    { 241, 16, 17, 43857m },
                    { 240, 15, 32, 0m },
                    { 239, 15, 31, 0m },
                    { 238, 15, 30, 0m },
                    { 246, 16, 22, 35775m },
                    { 256, 16, 32, 29793m },
                    { 215, 14, 23, 640.5m },
                    { 213, 14, 21, 350.7m },
                    { 190, 12, 30, 41.6m },
                    { 189, 12, 29, 22.7m },
                    { 188, 12, 28, 22.3m },
                    { 187, 12, 27, 65.4m },
                    { 186, 12, 26, 26.5m },
                    { 185, 12, 25, 62.3m },
                    { 184, 12, 24, 41.4m },
                    { 183, 12, 23, 52.4m },
                    { 182, 12, 22, 72.9m },
                    { 181, 12, 21, 77.7m },
                    { 180, 12, 20, 55.5m },
                    { 179, 12, 19, 60.8m },
                    { 178, 12, 18, 37.2m },
                    { 177, 12, 17, 13.4m },
                    { 176, 11, 32, 91.5m },
                    { 175, 11, 31, 61.4m },
                    { 174, 11, 30, 65.3m },
                    { 191, 12, 31, 28.2m },
                    { 192, 12, 32, 65.2m },
                    { 193, 13, 17, 82.3m },
                    { 194, 13, 18, 92.3m },
                    { 212, 14, 20, 490.4m },
                    { 211, 14, 19, 221.1m },
                    { 210, 14, 18, 324.5m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 209, 14, 17, 213.9m },
                    { 208, 13, 32, 86m },
                    { 207, 13, 31, 93.9m },
                    { 206, 13, 30, 86.9m },
                    { 205, 13, 29, 86.6m },
                    { 214, 14, 22, 419m },
                    { 204, 13, 28, 89.7m },
                    { 202, 13, 26, 90.7m },
                    { 201, 13, 25, 88m },
                    { 200, 13, 24, 94m },
                    { 199, 13, 23, 80.7m },
                    { 198, 13, 22, 85.1m },
                    { 197, 13, 21, 89m },
                    { 196, 13, 20, 85m },
                    { 195, 13, 19, 80.2m },
                    { 203, 13, 27, 88.7m },
                    { 173, 11, 29, 60.7m },
                    { 257, 17, 17, 54.56m },
                    { 259, 17, 19, 58.05m },
                    { 319, 20, 31, 0m },
                    { 318, 20, 30, 0m },
                    { 317, 20, 29, 0m },
                    { 316, 20, 28, 0m },
                    { 315, 20, 27, 0m },
                    { 314, 20, 26, 0m },
                    { 313, 20, 25, 0m },
                    { 312, 20, 24, 0m },
                    { 311, 20, 23, 0m },
                    { 310, 20, 22, 0m },
                    { 309, 20, 21, 0m },
                    { 308, 20, 20, 0m },
                    { 307, 20, 19, 0m },
                    { 306, 20, 18, 0m },
                    { 305, 20, 17, 0m },
                    { 304, 19, 32, 0m },
                    { 303, 19, 31, 0m },
                    { 320, 20, 32, 0m },
                    { 321, 21, 17, 21m },
                    { 322, 21, 18, 43.82m },
                    { 323, 21, 19, 44.36m },
                    { 341, 22, 21, 43.58m },
                    { 340, 22, 20, 40.36m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 339, 22, 19, 44.65m },
                    { 338, 22, 18, 37.23m },
                    { 337, 22, 17, 32.16m },
                    { 336, 21, 32, 35.91m },
                    { 335, 21, 31, 31.65m },
                    { 334, 21, 30, 19.32m },
                    { 302, 19, 30, 0m },
                    { 333, 21, 29, 44.49m },
                    { 331, 21, 27, 11.24m },
                    { 330, 21, 26, 10.43m },
                    { 329, 21, 25, 44.13m },
                    { 328, 21, 24, 16.42m },
                    { 327, 21, 23, 41.16m },
                    { 326, 21, 22, 47.62m },
                    { 325, 21, 21, 39.07m },
                    { 324, 21, 20, 43.47m },
                    { 332, 21, 28, 26.24m },
                    { 258, 17, 18, 55.26m },
                    { 301, 19, 29, 0m },
                    { 299, 19, 27, 0m },
                    { 276, 18, 20, 1082m },
                    { 275, 18, 19, 996m },
                    { 274, 18, 18, 1176m },
                    { 273, 18, 17, 695m },
                    { 272, 17, 32, 57.17m },
                    { 271, 17, 31, 55.45m },
                    { 270, 17, 30, 57.85m },
                    { 269, 17, 29, 55.37m },
                    { 268, 17, 28, 58.53m },
                    { 267, 17, 27, 58.12m },
                    { 266, 17, 26, 53.72m },
                    { 265, 17, 25, 58.02m },
                    { 264, 17, 24, 60.58m },
                    { 263, 17, 23, 62.29m },
                    { 262, 17, 22, 60.37m },
                    { 261, 17, 21, 65.01m },
                    { 260, 17, 20, 61.96m },
                    { 277, 18, 21, 1135m },
                    { 278, 18, 22, 719m },
                    { 279, 18, 23, 683m },
                    { 280, 18, 24, 734m },
                    { 298, 19, 26, 0m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 297, 19, 25, 0m },
                    { 296, 19, 24, 0m },
                    { 295, 19, 23, 0m },
                    { 294, 19, 22, 0m },
                    { 293, 19, 21, 0m },
                    { 292, 19, 20, 0m },
                    { 291, 19, 19, 0m },
                    { 300, 19, 28, 0m },
                    { 290, 19, 18, 0m },
                    { 288, 18, 32, 1226m },
                    { 287, 18, 31, 933m },
                    { 286, 18, 30, 564m },
                    { 285, 18, 29, 627m },
                    { 284, 18, 28, 796m },
                    { 283, 18, 27, 1013m },
                    { 282, 18, 26, 655m },
                    { 281, 18, 25, 802m },
                    { 289, 19, 17, 0m },
                    { 342, 22, 22, 67.09m },
                    { 172, 11, 28, 78.5m },
                    { 170, 11, 26, 92.6m },
                    { 61, 4, 13, 0m },
                    { 60, 4, 12, 0m },
                    { 59, 4, 11, 0m },
                    { 58, 4, 10, 0m },
                    { 57, 4, 9, 0m },
                    { 56, 4, 8, 0m },
                    { 55, 4, 7, 0m },
                    { 54, 4, 6, 0m },
                    { 53, 4, 5, 0m },
                    { 52, 4, 4, 0m },
                    { 51, 4, 3, 0m },
                    { 50, 4, 2, 0m },
                    { 49, 4, 1, 0m },
                    { 48, 3, 16, 56.9m },
                    { 47, 3, 15, 59.5m },
                    { 46, 3, 14, 59.1m },
                    { 45, 3, 13, 56.4m },
                    { 62, 4, 14, 0m },
                    { 63, 4, 15, 0m },
                    { 64, 4, 16, 0m },
                    { 65, 5, 1, 8324m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 83, 6, 3, 8185m },
                    { 82, 6, 2, 7819m },
                    { 81, 6, 1, 7503m },
                    { 80, 5, 16, 2293m },
                    { 79, 5, 15, 341m },
                    { 78, 5, 14, 2312m },
                    { 77, 5, 13, 5073m },
                    { 76, 5, 12, 7587m },
                    { 44, 3, 12, 58.2m },
                    { 75, 5, 11, 10218m },
                    { 73, 5, 9, 10156m },
                    { 72, 5, 8, 10487m },
                    { 71, 5, 7, 10626m },
                    { 70, 5, 6, 10236m },
                    { 69, 5, 5, 9782m },
                    { 68, 5, 4, 9439m },
                    { 67, 5, 3, 9048m },
                    { 66, 5, 2, 8678m },
                    { 74, 5, 10, 9986m },
                    { 84, 6, 4, 8512m },
                    { 43, 3, 11, 59.1m },
                    { 41, 3, 9, 88.9m },
                    { 18, 2, 2, 0m },
                    { 17, 2, 1, 0m },
                    { 16, 1, 16, 5269m },
                    { 15, 1, 15, 5053m },
                    { 14, 1, 14, 5044m },
                    { 13, 1, 13, 4961m },
                    { 12, 1, 12, 4830m },
                    { 11, 1, 11, 4664m },
                    { 10, 1, 10, 4573m },
                    { 9, 1, 9, 4654m },
                    { 8, 1, 8, 4841m },
                    { 7, 1, 7, 4932m },
                    { 6, 1, 6, 4769m },
                    { 5, 1, 5, 4588m },
                    { 4, 1, 4, 4468m },
                    { 3, 1, 3, 4319m },
                    { 2, 1, 2, 4182m },
                    { 19, 2, 3, 5.4m },
                    { 20, 2, 4, 12m },
                    { 21, 2, 5, 23.5m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 22, 2, 6, 45.8m },
                    { 40, 3, 8, 99.5m },
                    { 39, 3, 7, 89.2m },
                    { 38, 3, 6, 81.6m },
                    { 37, 3, 5, 68m },
                    { 36, 3, 4, 61m },
                    { 35, 3, 3, 61.2m },
                    { 34, 3, 2, 50.9m },
                    { 33, 3, 1, 56.4m },
                    { 42, 3, 10, 71.7m },
                    { 32, 2, 16, 8.5m },
                    { 30, 2, 14, 0m },
                    { 29, 2, 13, 0m },
                    { 28, 2, 12, 0m },
                    { 27, 2, 11, 5.2m },
                    { 26, 2, 10, 42.2m },
                    { 25, 2, 9, 65.1m },
                    { 24, 2, 8, 85.8m },
                    { 23, 2, 7, 78.1m },
                    { 31, 2, 15, 4.1m },
                    { 171, 11, 27, 85.9m },
                    { 85, 6, 5, 8842m },
                    { 87, 6, 7, 9604m },
                    { 147, 10, 19, 172375m },
                    { 146, 10, 18, 160788m },
                    { 145, 10, 17, 163836m },
                    { 144, 9, 16, 8509m },
                    { 143, 9, 15, 9035m },
                    { 142, 9, 14, 8986m },
                    { 141, 9, 13, 8894m },
                    { 140, 9, 12, 8963m },
                    { 139, 9, 11, 0m },
                    { 138, 9, 10, 0m },
                    { 137, 9, 9, 0m },
                    { 136, 9, 8, 0m },
                    { 135, 9, 7, 0m },
                    { 134, 9, 6, 0m },
                    { 133, 9, 5, 0m },
                    { 132, 9, 4, 0m },
                    { 131, 9, 3, 0m },
                    { 148, 10, 20, 172905m },
                    { 149, 10, 21, 164062m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 150, 10, 22, 150376m },
                    { 151, 10, 23, 151478m },
                    { 169, 11, 25, 59.3m },
                    { 168, 11, 24, 58.1m },
                    { 167, 11, 23, 93.9m },
                    { 166, 11, 22, 96.1m },
                    { 165, 11, 21, 89.3m },
                    { 164, 11, 20, 52.9m },
                    { 163, 11, 19, 61.2m },
                    { 162, 11, 18, 65.4m },
                    { 130, 9, 2, 0m },
                    { 161, 11, 17, 101.9m },
                    { 159, 10, 31, 178919m },
                    { 158, 10, 30, 181597m },
                    { 157, 10, 29, 168771m },
                    { 156, 10, 28, 177088m },
                    { 155, 10, 27, 164012m },
                    { 154, 10, 26, 149610m },
                    { 153, 10, 25, 147739m },
                    { 152, 10, 24, 152684m },
                    { 160, 10, 32, 172435m },
                    { 86, 6, 6, 9242m },
                    { 129, 9, 1, 0m },
                    { 127, 8, 15, 8962m },
                    { 104, 7, 8, 8593m },
                    { 103, 7, 7, 8697m },
                    { 102, 7, 6, 8374m },
                    { 101, 7, 5, 7864m },
                    { 100, 7, 4, 7727m },
                    { 99, 7, 3, 7404m },
                    { 98, 7, 2, 7068m },
                    { 97, 7, 1, 6716m },
                    { 96, 6, 16, 0m },
                    { 95, 6, 15, 0m },
                    { 94, 6, 14, 0m },
                    { 93, 6, 13, 0m },
                    { 92, 6, 12, 0m },
                    { 91, 6, 11, 9208m },
                    { 90, 6, 10, 9002m },
                    { 89, 6, 9, 9171m },
                    { 88, 6, 8, 9439m },
                    { 105, 7, 9, 8169m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 106, 7, 10, 8219m },
                    { 107, 7, 11, 8366m },
                    { 108, 7, 12, 8082m },
                    { 126, 8, 14, 8964m },
                    { 125, 8, 13, 8842m },
                    { 124, 8, 12, 8960m },
                    { 123, 8, 11, 0m },
                    { 122, 8, 10, 0m },
                    { 121, 8, 9, 0m },
                    { 120, 8, 8, 0m },
                    { 119, 8, 7, 0m },
                    { 128, 8, 16, 8490m },
                    { 118, 8, 6, 0m },
                    { 116, 8, 4, 0m },
                    { 115, 8, 3, 0m },
                    { 114, 8, 2, 0m },
                    { 113, 8, 1, 0m },
                    { 112, 7, 16, 7680m },
                    { 111, 7, 15, 8138m },
                    { 110, 7, 14, 8126m },
                    { 109, 7, 13, 8002m },
                    { 117, 8, 5, 0m },
                    { 343, 22, 23, 60.23m },
                    { 344, 22, 24, 33.4m },
                    { 345, 22, 25, 20.64m },
                    { 578, 37, 18, 25.87m },
                    { 577, 37, 17, 23.86m },
                    { 576, 36, 32, 36.54m },
                    { 575, 36, 31, 58.1m },
                    { 574, 36, 30, 62.15m },
                    { 573, 36, 29, 63.44m },
                    { 572, 36, 28, 64.8m },
                    { 571, 36, 27, 47.2m },
                    { 570, 36, 26, 31.05m },
                    { 569, 36, 25, 26.98m },
                    { 568, 36, 24, 76.63m },
                    { 567, 36, 23, 53.9m },
                    { 566, 36, 22, 69.24m },
                    { 565, 36, 21, 73.92m },
                    { 564, 36, 20, 23.91m },
                    { 563, 36, 19, 57.84m },
                    { 562, 36, 18, 23.36m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 579, 37, 19, 27.82m },
                    { 580, 37, 20, 29.02m },
                    { 581, 37, 21, 29.28m },
                    { 582, 37, 22, 30.31m },
                    { 600, 38, 24, 68.94m },
                    { 599, 38, 23, 91.85m },
                    { 598, 38, 22, 42.07m },
                    { 597, 38, 21, 72.51m },
                    { 596, 38, 20, 52.82m },
                    { 595, 38, 19, 71.28m },
                    { 594, 38, 18, 101.27m },
                    { 593, 38, 17, 28.87m },
                    { 561, 36, 17, 26.98m },
                    { 592, 37, 32, 35.35m },
                    { 590, 37, 30, 35.06m },
                    { 589, 37, 29, 33.56m },
                    { 588, 37, 28, 30.85m },
                    { 587, 37, 27, 28.61m },
                    { 586, 37, 26, 29.77m },
                    { 585, 37, 25, 27.89m },
                    { 584, 37, 24, 26.47m },
                    { 583, 37, 23, 29.24m },
                    { 591, 37, 31, 32.92m },
                    { 601, 38, 25, 49.75m },
                    { 560, 35, 32, 0m },
                    { 558, 35, 30, 0m },
                    { 535, 34, 23, 463m },
                    { 534, 34, 22, 283m },
                    { 533, 34, 21, 430m },
                    { 532, 34, 20, 346m },
                    { 531, 34, 19, 425m },
                    { 530, 34, 18, 374m },
                    { 529, 34, 17, 469m },
                    { 528, 33, 32, 78.62m },
                    { 527, 33, 31, 79.31m },
                    { 526, 33, 30, 79.43m },
                    { 525, 33, 29, 80.19m },
                    { 524, 33, 28, 77.68m },
                    { 523, 33, 27, 73.4m },
                    { 522, 33, 26, 69.96m },
                    { 521, 33, 25, 69.53m },
                    { 520, 33, 24, 69.97m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 519, 33, 23, 70.57m },
                    { 536, 34, 24, 528m },
                    { 537, 34, 25, 230m },
                    { 538, 34, 26, 207m },
                    { 539, 34, 27, 493m },
                    { 557, 35, 29, 0m },
                    { 556, 35, 28, 0m },
                    { 555, 35, 27, 0m },
                    { 554, 35, 26, 0m },
                    { 553, 35, 25, 0m },
                    { 552, 35, 24, 0m },
                    { 551, 35, 23, 0m },
                    { 550, 35, 22, 0m },
                    { 559, 35, 31, 0m },
                    { 549, 35, 21, 0m },
                    { 547, 35, 19, 0m },
                    { 546, 35, 18, 0m },
                    { 545, 35, 17, 0m },
                    { 544, 34, 32, 371m },
                    { 543, 34, 31, 429m },
                    { 542, 34, 30, 416m },
                    { 541, 34, 29, 442m },
                    { 540, 34, 28, 424m },
                    { 548, 35, 20, 0m },
                    { 518, 33, 22, 75.55m },
                    { 602, 38, 26, 94.29m },
                    { 604, 38, 28, 49.46m },
                    { 664, 42, 24, 81.8m },
                    { 663, 42, 23, 14.6m },
                    { 662, 42, 22, 41m },
                    { 661, 42, 21, 11.9m },
                    { 660, 42, 20, 32.9m },
                    { 659, 42, 19, 34m },
                    { 658, 42, 18, 81.2m },
                    { 657, 42, 17, 56.3m },
                    { 656, 41, 32, 97.8m },
                    { 655, 41, 31, 10.2m },
                    { 654, 41, 30, 22.17m },
                    { 653, 41, 29, 53.6m },
                    { 652, 41, 28, 101.1m },
                    { 651, 41, 27, 88m },
                    { 650, 41, 26, 54.5m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 649, 41, 25, 58.1m },
                    { 648, 41, 24, 86.8m },
                    { 665, 42, 25, 46.6m },
                    { 666, 42, 26, 71.5m },
                    { 667, 42, 27, 80m },
                    { 668, 42, 28, 44.9m },
                    { 686, 43, 30, 800.2m },
                    { 685, 43, 29, 1070.9m },
                    { 684, 43, 28, 1021.1m },
                    { 683, 43, 27, 1028.7m },
                    { 682, 43, 26, 1072.7m },
                    { 681, 43, 25, 1090.9m },
                    { 680, 43, 24, 1064.4m },
                    { 679, 43, 23, 1065.1m },
                    { 647, 41, 23, 64m },
                    { 678, 43, 22, 1018m },
                    { 676, 43, 20, 1025.3m },
                    { 675, 43, 19, 1005.7m },
                    { 674, 43, 18, 1069.6m },
                    { 673, 43, 17, 1010.7m },
                    { 672, 42, 32, 29.5m },
                    { 671, 42, 31, 8.2m },
                    { 670, 42, 30, 10.3m },
                    { 669, 42, 29, 80.2m },
                    { 677, 43, 21, 1024.7m },
                    { 603, 38, 27, 21.22m },
                    { 646, 41, 22, 84.6m },
                    { 644, 41, 20, 99.9m },
                    { 621, 39, 29, 97.33m },
                    { 620, 39, 28, 96.41m },
                    { 619, 39, 27, 94.92m },
                    { 618, 39, 26, 88.25m },
                    { 617, 39, 25, 94.98m },
                    { 616, 39, 24, 91.67m },
                    { 615, 39, 23, 97.94m },
                    { 614, 39, 22, 94.88m },
                    { 613, 39, 21, 96.72m },
                    { 612, 39, 20, 96.91m },
                    { 611, 39, 19, 93.17m },
                    { 610, 39, 18, 96.25m },
                    { 609, 39, 17, 94.72m },
                    { 608, 38, 32, 68m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 607, 38, 31, 95.78m },
                    { 606, 38, 30, 32.1m },
                    { 605, 38, 29, 29.35m },
                    { 622, 39, 30, 97.18m },
                    { 623, 39, 31, 93.18m },
                    { 624, 39, 32, 91.57m },
                    { 625, 40, 17, 263961m },
                    { 643, 41, 19, 101.8m },
                    { 642, 41, 18, 87.3m },
                    { 641, 41, 17, 60.6m },
                    { 640, 40, 32, 382037m },
                    { 639, 40, 31, 3695m },
                    { 638, 40, 30, 246887m },
                    { 637, 40, 29, 365879m },
                    { 636, 40, 28, 378775m },
                    { 645, 41, 21, 60.8m },
                    { 635, 40, 27, 390161m },
                    { 633, 40, 25, 458613m },
                    { 632, 40, 24, 444536m },
                    { 631, 40, 23, 403632m },
                    { 630, 40, 22, 435999m },
                    { 629, 40, 21, 419627m },
                    { 628, 40, 20, 354507m },
                    { 627, 40, 19, 302096m },
                    { 626, 40, 18, 287035m },
                    { 634, 40, 26, 413401m },
                    { 517, 33, 21, 70.98m },
                    { 516, 33, 20, 71.89m },
                    { 515, 33, 19, 68.07m },
                    { 405, 26, 21, 193618m },
                    { 404, 26, 20, 215709m },
                    { 403, 26, 19, 189304m },
                    { 402, 26, 18, 217759m },
                    { 401, 26, 17, 253014m },
                    { 400, 25, 32, 96.26m },
                    { 399, 25, 31, 93.82m },
                    { 398, 25, 30, 96.06m },
                    { 397, 25, 29, 91.54m },
                    { 396, 25, 28, 97.07m },
                    { 395, 25, 27, 94.53m },
                    { 394, 25, 26, 90.78m },
                    { 393, 25, 25, 96.5m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 392, 25, 24, 92.58m },
                    { 391, 25, 23, 93.43m },
                    { 390, 25, 22, 95.27m },
                    { 389, 25, 21, 93.35m },
                    { 406, 26, 22, 212220m },
                    { 407, 26, 23, 245695m },
                    { 408, 26, 24, 230979m },
                    { 409, 26, 25, 217957m },
                    { 427, 27, 27, 102.9m },
                    { 426, 27, 26, 47.8m },
                    { 425, 27, 25, 64.5m },
                    { 424, 27, 24, 73.8m },
                    { 423, 27, 23, 70.1m },
                    { 422, 27, 22, 91.4m },
                    { 421, 27, 21, 66.7m },
                    { 420, 27, 20, 56.5m },
                    { 388, 25, 20, 91.48m },
                    { 419, 27, 19, 99.2m },
                    { 417, 27, 17, 66.2m },
                    { 416, 26, 32, 136332m },
                    { 415, 26, 31, 120550m },
                    { 414, 26, 30, 145635m },
                    { 413, 26, 29, 156679m },
                    { 412, 26, 28, 146562m },
                    { 411, 26, 27, 174784m },
                    { 410, 26, 26, 178598m },
                    { 418, 27, 18, 79.6m },
                    { 428, 27, 28, 94.4m },
                    { 387, 25, 19, 89.05m },
                    { 385, 25, 17, 95.87m },
                    { 362, 23, 26, 5.24m },
                    { 361, 23, 25, 7.98m },
                    { 360, 23, 24, 5.58m },
                    { 359, 23, 23, 6.68m },
                    { 358, 23, 22, 9.2m },
                    { 357, 23, 21, 7.66m },
                    { 356, 23, 20, 10.21m },
                    { 355, 23, 19, 8.53m },
                    { 354, 23, 18, 10.63m },
                    { 353, 23, 17, 12.58m },
                    { 352, 22, 32, 68.74m },
                    { 351, 22, 31, 24.18m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 350, 22, 30, 61.86m },
                    { 349, 22, 29, 60.18m },
                    { 348, 22, 28, 62.04m },
                    { 347, 22, 27, 36.42m },
                    { 346, 22, 26, 55.42m },
                    { 363, 23, 27, 3.16m },
                    { 364, 23, 28, 6.02m },
                    { 365, 23, 29, 5.87m },
                    { 366, 23, 30, 7.38m },
                    { 384, 24, 32, 88.31m },
                    { 383, 24, 31, 89.22m },
                    { 382, 24, 30, 58.56m },
                    { 381, 24, 29, 92.61m },
                    { 380, 24, 28, 94.07m },
                    { 379, 24, 27, 75.47m },
                    { 378, 24, 26, 75.45m },
                    { 377, 24, 25, 81.2m },
                    { 386, 25, 18, 90.61m },
                    { 376, 24, 24, 35.21m },
                    { 374, 24, 22, 70.24m },
                    { 373, 24, 21, 77.78m },
                    { 372, 24, 20, 59.49m },
                    { 371, 24, 19, 50.38m },
                    { 370, 24, 18, 68.95m },
                    { 369, 24, 17, 56.62m },
                    { 368, 23, 32, 7.01m },
                    { 367, 23, 31, 8.43m },
                    { 375, 24, 23, 99.77m },
                    { 429, 27, 29, 102.7m },
                    { 430, 27, 30, 100.6m },
                    { 431, 27, 31, 85.2m },
                    { 492, 31, 28, 0m },
                    { 491, 31, 27, 0m },
                    { 490, 31, 26, 0m },
                    { 489, 31, 25, 0m },
                    { 488, 31, 24, 0m },
                    { 487, 31, 23, 0m },
                    { 486, 31, 22, 0m },
                    { 485, 31, 21, 0m },
                    { 484, 31, 20, 0m },
                    { 483, 31, 19, 0m },
                    { 482, 31, 18, 0m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 481, 31, 17, 0m },
                    { 480, 30, 32, 924.5m },
                    { 479, 30, 31, 732m },
                    { 478, 30, 30, 829.2m },
                    { 477, 30, 29, 822.9m },
                    { 476, 30, 28, 841.4m },
                    { 493, 31, 29, 0m },
                    { 494, 31, 30, 0m },
                    { 495, 31, 31, 0m },
                    { 496, 31, 32, 0m },
                    { 514, 33, 18, 71.33m },
                    { 513, 33, 17, 67.62m },
                    { 512, 32, 32, 1678m },
                    { 511, 32, 31, 3777m },
                    { 510, 32, 30, 4507m },
                    { 509, 32, 29, 1518m },
                    { 508, 32, 28, 706m },
                    { 507, 32, 27, 2566m },
                    { 475, 30, 27, 658.4m },
                    { 506, 32, 26, 7249m },
                    { 504, 32, 24, 3404m },
                    { 503, 32, 23, 5804m },
                    { 502, 32, 22, 4710m },
                    { 501, 32, 21, 6912m },
                    { 500, 32, 20, 9621m },
                    { 499, 32, 19, 10767m },
                    { 498, 32, 18, 6406m },
                    { 497, 32, 17, 6907m },
                    { 505, 32, 25, 8182m },
                    { 474, 30, 26, 644.6m },
                    { 473, 30, 25, 894.4m },
                    { 472, 30, 24, 820.7m },
                    { 449, 29, 17, 77.1m },
                    { 448, 28, 32, 60.5m },
                    { 447, 28, 31, 29.6m },
                    { 446, 28, 30, 36.6m },
                    { 445, 28, 29, 32.5m },
                    { 444, 28, 28, 39.2m },
                    { 443, 28, 27, 20m },
                    { 442, 28, 26, 13.8m },
                    { 450, 29, 18, 61.4m },
                    { 441, 28, 25, 40.6m }
                });

            migrationBuilder.InsertData(
                table: "Mesures",
                columns: new[] { "Id", "EquipementId", "PeriodeId", "Valeur" },
                values: new object[,]
                {
                    { 439, 28, 23, 84.3m },
                    { 438, 28, 22, 50.2m },
                    { 437, 28, 21, 54.3m },
                    { 436, 28, 20, 14.9m },
                    { 435, 28, 19, 79m },
                    { 434, 28, 18, 15.1m },
                    { 433, 28, 17, 63.6m },
                    { 432, 27, 32, 56.8m },
                    { 440, 28, 24, 10.6m },
                    { 1375, 86, 31, 95.83m },
                    { 451, 29, 19, 72.3m },
                    { 453, 29, 21, 78.6m },
                    { 471, 30, 23, 805m },
                    { 470, 30, 22, 826.7m },
                    { 469, 30, 21, 891.7m },
                    { 468, 30, 20, 714.4m },
                    { 467, 30, 19, 664.2m },
                    { 466, 30, 18, 618.6m },
                    { 465, 30, 17, 786.5m },
                    { 464, 29, 32, 75.5m },
                    { 452, 29, 20, 76.6m },
                    { 463, 29, 31, 75.4m },
                    { 461, 29, 29, 83.8m },
                    { 460, 29, 28, 71.6m },
                    { 459, 29, 27, 72.4m },
                    { 458, 29, 26, 65.6m },
                    { 457, 29, 25, 72.6m },
                    { 456, 29, 24, 76m },
                    { 455, 29, 23, 64.7m },
                    { 454, 29, 22, 73m },
                    { 462, 29, 30, 84.5m },
                    { 1376, 86, 32, 90.78m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 587);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 588);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 589);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 590);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 592);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 593);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 594);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 595);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 596);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 597);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 599);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 605);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 606);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 607);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 609);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 610);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 613);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 614);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 616);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 617);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 618);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 619);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 620);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 621);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 622);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 623);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 624);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 625);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 626);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 627);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 628);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 629);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 630);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 631);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 632);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 633);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 634);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 635);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 636);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 637);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 638);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 639);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 640);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 641);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 642);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 643);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 644);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 645);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 646);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 647);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 648);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 649);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 650);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 651);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 652);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 653);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 655);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 656);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 657);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 658);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 659);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 660);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 661);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 662);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 663);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 664);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 665);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 667);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 668);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 669);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 670);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 671);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 672);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 673);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 674);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 675);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 676);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 677);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 678);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 679);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 680);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 681);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 682);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 683);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 684);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 685);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 686);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 687);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 688);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 689);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 690);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 691);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 692);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 693);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 694);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 695);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 696);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 697);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 698);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 699);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 704);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 705);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 706);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 707);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 708);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 709);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 710);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 711);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 712);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 713);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 714);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 715);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 716);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 717);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 718);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 719);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 720);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 721);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 722);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 723);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 724);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 725);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 726);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 727);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 728);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 729);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 730);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 731);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 732);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 733);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 734);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 735);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 736);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 737);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 738);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 739);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 740);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 741);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 742);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 743);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 744);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 745);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 746);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 747);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 748);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 749);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 750);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 751);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 752);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 753);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 754);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 755);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 756);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 757);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 758);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 759);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 763);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 765);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 766);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 767);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 769);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 770);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 771);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 772);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 773);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 774);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 775);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 776);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 777);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 778);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 779);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 780);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 782);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 783);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 784);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 785);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 786);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 787);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 788);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 789);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 790);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 791);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 793);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 794);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 795);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 796);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 797);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 799);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 805);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 806);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 808);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 809);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 810);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 811);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 812);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 813);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 814);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 815);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 816);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 817);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 818);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 819);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 820);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 821);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 822);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 823);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 824);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 825);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 826);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 827);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 828);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 829);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 830);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 831);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 832);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 833);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 834);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 835);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 836);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 837);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 838);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 839);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 840);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 841);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 842);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 843);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 844);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 845);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 846);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 847);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 848);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 849);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 850);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 851);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 852);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 853);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 854);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 855);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 856);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 857);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 858);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 859);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 860);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 861);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 862);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 863);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 864);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 865);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 866);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 867);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 868);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 869);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 870);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 871);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 872);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 873);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 874);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 875);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 876);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 877);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 878);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 879);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 880);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 881);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 882);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 883);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 884);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 885);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 886);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 887);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 888);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 889);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 890);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 891);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 892);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 893);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 894);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 895);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 896);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 897);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 898);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 899);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 901);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 902);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 903);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 904);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 905);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 906);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 907);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 908);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 909);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 910);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 911);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 912);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 913);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 914);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 915);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 916);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 917);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 918);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 919);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 920);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 921);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 922);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 923);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 924);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 925);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 926);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 927);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 928);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 929);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 930);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 931);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 932);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 933);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 934);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 935);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 936);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 937);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 938);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 939);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 940);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 941);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 942);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 943);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 944);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 945);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 946);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 947);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 948);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 949);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 950);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 951);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 952);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 953);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 954);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 955);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 956);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 957);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 958);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 959);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 960);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 961);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 962);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 963);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 964);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 965);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 966);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 967);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 968);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 969);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 970);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 971);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 972);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 973);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 974);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 975);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 976);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 977);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 978);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 979);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 980);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 981);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 982);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 983);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 984);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 985);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 986);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 987);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 988);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 989);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 990);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 991);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 992);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 993);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 994);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 995);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 996);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 997);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 998);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1028);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1029);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1034);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1036);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1037);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1038);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1039);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1040);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1042);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1043);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1044);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1046);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1047);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1048);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1049);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1051);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1052);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1053);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1054);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1055);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1056);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1057);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1058);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1059);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1060);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1062);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1063);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1064);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1065);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1066);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1067);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1068);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1069);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1070);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1071);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1072);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1073);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1074);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1075);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1076);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1077);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1078);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1079);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1080);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1081);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1082);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1083);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1084);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1085);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1086);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1087);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1088);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1089);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1090);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1091);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1092);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1093);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1094);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1095);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1096);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1097);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1098);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1099);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1104);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1105);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1106);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1107);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1108);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1109);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1111);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1112);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1113);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1114);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1115);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1116);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1117);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1118);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1119);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1120);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1121);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1122);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1123);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1124);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1125);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1126);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1127);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1128);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1129);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1130);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1131);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1132);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1133);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1134);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1135);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1136);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1137);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1138);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1139);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1140);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1141);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1142);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1143);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1144);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1145);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1146);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1147);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1148);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1149);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1150);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1151);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1152);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1153);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1154);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1155);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1156);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1157);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1158);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1159);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1160);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1161);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1162);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1163);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1164);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1165);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1166);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1167);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1168);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1169);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1170);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1171);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1172);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1173);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1174);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1175);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1176);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1177);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1178);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1179);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1180);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1181);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1182);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1183);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1184);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1185);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1186);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1187);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1188);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1189);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1190);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1191);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1192);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1193);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1194);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1195);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1196);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1197);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1198);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1199);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1202);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1203);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1204);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1205);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1206);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1207);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1208);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1209);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1210);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1211);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1212);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1213);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1214);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1215);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1216);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1217);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1218);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1219);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1220);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1221);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1222);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1223);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1224);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1225);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1226);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1227);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1228);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1229);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1230);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1231);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1232);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1233);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1235);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1236);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1237);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1238);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1239);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1240);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1241);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1242);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1243);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1244);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1245);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1246);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1247);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1248);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1249);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1250);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1251);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1252);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1253);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1254);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1255);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1256);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1257);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1258);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1259);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1260);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1261);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1262);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1263);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1264);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1265);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1266);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1267);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1268);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1269);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1270);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1271);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1272);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1273);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1274);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1275);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1276);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1277);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1278);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1279);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1280);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1281);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1282);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1283);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1284);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1285);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1286);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1287);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1288);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1289);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1290);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1291);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1292);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1293);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1294);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1295);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1296);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1297);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1298);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1299);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1301);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1302);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1303);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1304);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1305);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1306);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1307);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1308);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1309);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1310);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1311);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1312);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1313);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1314);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1315);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1316);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1317);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1318);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1319);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1320);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1321);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1322);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1323);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1324);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1325);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1326);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1327);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1328);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1329);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1330);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1331);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1332);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1333);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1334);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1335);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1336);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1337);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1338);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1339);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1340);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1341);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1342);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1343);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1344);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1345);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1346);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1347);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1348);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1349);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1350);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1351);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1352);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1353);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1354);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1355);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1356);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1357);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1358);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1359);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1360);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1361);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1362);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1363);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1364);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1365);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1366);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1367);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1368);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1369);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1370);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1371);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1372);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1373);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1374);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1375);

            migrationBuilder.DeleteData(
                table: "Mesures",
                keyColumn: "Id",
                keyValue: 1376);
        }
    }
}
