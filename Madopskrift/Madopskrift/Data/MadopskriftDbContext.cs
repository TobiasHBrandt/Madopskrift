using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Madopskrift.Models;
using System.Linq;

#nullable disable

namespace Madopskrift.Data
{
    public partial class MadopskriftDbContext : DbContext
    {
        public MadopskriftDbContext()
        {
        }

        public MadopskriftDbContext(DbContextOptions<MadopskriftDbContext> options)
            : base(options)
        {
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                //entity.HasIndex(e => e.Email, "UQ__Admin__A9D1053446F0894A")
                //    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Efternavn)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Fornavn)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Bruger>(entity =>
            {
                entity.ToTable("Bruger");

                //entity.HasIndex(e => e.Brugernavn, "UQ__Bruger__6BE4ADA0E104ECEB")
                //    .IsUnique();

                //entity.HasIndex(e => e.Email, "UQ__Bruger__A9D1053491E8F716")
                //    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Brugernavn)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Opskrift>(entity =>
            {
                entity.ToTable("Opskrift");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Beskrivelse).IsRequired();

                entity.Property(e => e.BrugerId).HasColumnName("BrugerID");

                entity.Property(e => e.Fremgangsmoede).IsRequired();

                entity.Property(e => e.Ingredienser).IsRequired();

                entity.Property(e => e.Titel)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Bruger)
                    .WithMany(p => p.Opskrifts)
                    .HasForeignKey(d => d.BrugerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OpskriftBruger_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Bruger> Brugers { get; set; }
        public virtual DbSet<Opskrift> Opskrift { get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
