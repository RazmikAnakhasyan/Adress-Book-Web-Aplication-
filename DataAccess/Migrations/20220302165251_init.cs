using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users_Contacts",
                columns: table => new
                {
                    Contact_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email_Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Physical_Addres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Contacts_1", x => x.Contact_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_Contacts");
        }
    }
}
