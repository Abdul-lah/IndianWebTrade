using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mst_Catogery",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatogeryName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_Catogery", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "mstRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstRole", x => x.Id);
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
                    RoleId = table.Column<int>(nullable: true),
                    MobileNo = table.Column<string>(maxLength: 50, nullable: true),
                    IsSeller = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<string>(maxLength: 20, nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Quantity = table.Column<string>(maxLength: 20, nullable: true),
                    Price = table.Column<string>(maxLength: 20, nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    Discription = table.Column<string>(maxLength: 220, nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    SellerId = table.Column<int>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK__tbl_Item__Catego__4BAC3F29",
                        column: x => x.CategoryId,
                        principalTable: "mst_Catogery",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__tbl_Item__Seller__4CA06362",
                        column: x => x.SellerId,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    PricePerItem = table.Column<string>(maxLength: 50, nullable: false),
                    TotalPrice = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCart_tbl_Item",
                        column: x => x.ItemId,
                        principalTable: "tbl_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblCart_tbl_User",
                        column: x => x.UserId,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    PricePerItem = table.Column<int>(nullable: false),
                    PriceTotal = table.Column<int>(nullable: false),
                    IsCanceled = table.Column<bool>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrder_tbl_Item",
                        column: x => x.ItemID,
                        principalTable: "tbl_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOrder_tbl_User",
                        column: x => x.UserId,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Item_CategoryId",
                table: "tbl_Item",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Item_SellerId",
                table: "tbl_Item",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCart_ItemId",
                table: "tblCart",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCart_UserId",
                table: "tblCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_ItemID",
                table: "tblOrder",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_UserId",
                table: "tblOrder",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mstRole");

            migrationBuilder.DropTable(
                name: "tbl_ItemImage");

            migrationBuilder.DropTable(
                name: "tblCart");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tbl_Item");

            migrationBuilder.DropTable(
                name: "mst_Catogery");

            migrationBuilder.DropTable(
                name: "tbl_User");
        }
    }
}
