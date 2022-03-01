using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Adress_Book_Web_Aplication_
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
                entity.HasKey(e => e.PhoneNumber);

                entity.ToTable("Users_Contacts");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.EmailAdress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Email_Adress");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Full_Name");

                entity.Property(e => e.PhysicalAddres)
                    .HasMaxLength(50)
                    .HasColumnName("Physical_Addres");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
