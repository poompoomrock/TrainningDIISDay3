using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PersonApp.Shared.Entities;

public partial class DbModelContext : DbContext
{
    public DbModelContext(DbContextOptions<DbModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Person { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("person_pkey");

            entity.ToTable("person");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
