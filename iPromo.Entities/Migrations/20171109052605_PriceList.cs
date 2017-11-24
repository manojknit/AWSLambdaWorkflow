using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace iPromo.Entities.Migrations
{
    public partial class PriceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mtListPrice",
                columns: table => new
                {
                    Material = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Price_List = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Price_Grp = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Bic_ZConType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Currency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Prc_Lst_Su = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ValidFrom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ValidTo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtListPrice", x => new { x.Material, x.Price_List, x.Price_Grp });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mtListPrice");
        }
    }
}
