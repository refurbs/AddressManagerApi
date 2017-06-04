using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Demo.AddressManager.Data;

namespace Demo.AddressManager.Data.Migrations
{
    [DbContext(typeof(AddressManagerDbContext))]
    partial class AddressManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Demo.AddressManager.Data.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<int>("Number");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .HasMaxLength(50);

                    b.Property<string>("Town")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Demo.AddressManager.Data.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .HasMaxLength(30);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Demo.AddressManager.Data.ContactAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ContactId");

                    b.Property<long>("AddressId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id", "ContactId", "AddressId");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactAddress");
                });

            modelBuilder.Entity("Demo.AddressManager.Data.ContactAddress", b =>
                {
                    b.HasOne("Demo.AddressManager.Data.Address", "Address")
                        .WithMany("ContactAddress")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Demo.AddressManager.Data.Contact", "Contact")
                        .WithMany("ContactAddress")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
