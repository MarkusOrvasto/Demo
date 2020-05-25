using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspNetWebDemo.Tietokanta
{
    public partial class VarastoContext : DbContext
    {
        public VarastoContext()
        {
        }

        public VarastoContext(DbContextOptions<VarastoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginDb> LoginDb { get; set; }
        public virtual DbSet<VarastoTilanne> VarastoTilanne { get; set; }
        public virtual DbSet<Varaukset> Varaukset { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-97FTUUUV\\SQLEXPRESS;Database=Varasto; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginDb>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LoginName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LoginPassword)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VarastoTilanne>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Varaukset>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Palautuspäivämäärä).HasColumnType("date");

                entity.Property(e => e.Varaajannimi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Varaukset1)
                    .IsRequired()
                    .HasColumnName("Varaukset")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Varauspäivämäärä).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
