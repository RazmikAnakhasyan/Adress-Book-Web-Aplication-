using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DataAccess
{
    public partial class AdressBookContext : DbContext
    {
        public AdressBookContext()
        {
        }

        public AdressBookContext(DbContextOptions<AdressBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UsersContact> UsersContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                                  .SetBasePath(Directory.GetCurrentDirectory())
                                                  .AddJsonFile("appsettings.json")
                                                  .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersContact>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK_Users_Contacts_1");

                entity.ToTable("Users_Contacts");

                entity.Property(e => e.ContactId).HasColumnName("Contact_Id");

                entity.Property(e => e.EmailAdress)
                    .HasMaxLength(100)
                    .HasColumnName("Email_Adress");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("Full_Name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.PhysicalAddres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Physical_Addres");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
