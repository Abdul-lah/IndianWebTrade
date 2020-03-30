using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitaialCatlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mst_Catogery",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatogeryId = table.Column<int>(nullable: false),
                    CatogeryName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_Catogery", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "mst_UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    RoleName = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(maxLength: 20, nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    SellerId = table.Column<string>(maxLength: 20, nullable: true),
                    Quantity = table.Column<string>(maxLength: 20, nullable: true),
                    Price = table.Column<string>(maxLength: 20, nullable: true),
                    CatogeryId = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    Discription = table.Column<string>(maxLength: 220, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ItemImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ItemImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    Email = table.Column<string>(maxLength: 40, nullable: true),
                    Password = table.Column<string>(maxLength: 40, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 140, nullable: true),
                    Address = table.Column<string>(maxLength: 140, nullable: true),
                    Role = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mst_Catogery");

            migrationBuilder.DropTable(
                name: "mst_UserRole");

            migrationBuilder.DropTable(
                name: "tbl_Item");

            migrationBuilder.DropTable(
                name: "tbl_ItemImage");

            migrationBuilder.DropTable(
                name: "tbl_User");
        }
    }
}
