using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contacts.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 255, nullable: true),
                    JobTitle = table.Column<string>(maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "BirthDate", "JobTitle", "MobilePhone", "Name" },
                values: new object[,]
                {
                    { new Guid("d1dbd8dc-0446-4236-aafa-c02e33a02819"), new DateTime(2003, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student", "+375 29 873 17 77", "Dasha" },
                    { new Guid("6a7c694c-3193-4185-bae5-dfe5128fc046"), new DateTime(2002, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programmer", "+375296658376", "Ilya" },
                    { new Guid("df17d593-11bc-4b33-bfb5-381f817591e6"), new DateTime(2003, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher", "+375(29) 463-76-13", "Dima" },
                    { new Guid("d06e3790-0b96-444d-9b2c-1664320a77e6"), new DateTime(2003, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dancer", "+375(29)3178954", "Ksusha" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MobilePhone",
                table: "Contacts",
                column: "MobilePhone",
                unique: true,
                filter: "[MobilePhone] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
