using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AllasPortal.Models
{
    public partial class Adatbazis : DbContext
    {
        public Adatbazis()
        {
        }

        public Adatbazis(DbContextOptions<Adatbazis> options)
            : base(options)
        {
        }

        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\totti\\temp\\AB\\adatb.mdf;Integrated Security=True;Connect Timeout=30");
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.BiztAzon)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FeladasiDatum).HasColumnType("datetime");

                entity.Property(e => e.Idopont).HasColumnType("datetime");

                entity.Property(e => e.Kategoria)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Kulcsszavak)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Leiras).IsRequired();

                entity.Property(e => e.Megnevezes)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.RegDatum).HasColumnType("datetime");

                entity.HasOne(d => d.HirdetesAzonNavigation)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.HirdetesAzon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Hirde__276EDEB3");

                entity.HasOne(d => d.PalyazoAzonNavigation)
                    .WithMany(p => p.Registrations)
                    .HasForeignKey(d => d.PalyazoAzon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Palya__286302EC");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.Kernev)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Munkahelyek)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SzakmaiTapasztalatok)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TelSzam)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Vegzettseg)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VezNev)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
