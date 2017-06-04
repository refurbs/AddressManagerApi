using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace Demo.AddressManager.Data
{
    public class AddressManagerDbContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public AddressManagerDbContext(DbContextOptions<AddressManagerDbContext> options,
            IConfigurationRoot config) : base(options)
        {
            _config = config;
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // use entity name, not dbset for table name
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            // create primary keys on relationships
            modelBuilder.Entity<ContactAddress>()
                .HasKey(k => new { k.Id, k.ContactId, k.AddressId });

            // set column widths
            modelBuilder.Entity<Contact>()
                .Property(p => p.FirstName).HasMaxLength(30);
            modelBuilder.Entity<Contact>()
                .Property(p => p.LastName).HasMaxLength(30);

            modelBuilder.Entity<ContactAddress>()
                .Property(p => p.Id).UseSqlServerIdentityColumn();
            modelBuilder.Entity<Address>()
                .Property(p => p.PostCode).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Address>()
                .Property(p => p.Street).HasMaxLength(50);
            modelBuilder.Entity<Address>()
                .Property(p => p.Town).HasMaxLength(50);
            modelBuilder.Entity<Address>()
                .Property(p => p.City).HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}
