using Microsoft.EntityFrameworkCore.Migrations;

namespace Adress_Book_Web_Aplication_.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users_Contacts",
                columns: table => new
                {
                    Phone_Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email_Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Physical_Addres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Contacts", x => x.Phone_Number);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_Contacts");
        }
    }
}
