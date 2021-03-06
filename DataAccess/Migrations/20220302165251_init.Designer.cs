// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(AdressBookContext))]
    [Migration("20220302165251_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("DataAccess.UsersContact", b =>
                {
                    b.Property<long>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Contact_Id")
                        .UseIdentityColumn();

                    b.Property<string>("EmailAdress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email_Adress");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Full_Name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Phone_Number");

                    b.Property<string>("PhysicalAddres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Physical_Addres");

                    b.HasKey("ContactId")
                        .HasName("PK_Users_Contacts_1");

                    b.ToTable("Users_Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
