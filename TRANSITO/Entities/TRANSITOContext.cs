using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TRANSITO.Entities
{
    public partial class TRANSITOContext : DbContext
    {
        public TRANSITOContext()
        {
        }

        public TRANSITOContext(DbContextOptions<TRANSITOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conductor> Conductors { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<Sancione> Sanciones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.ToTable("Conductor");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.Conductors)
                    .HasForeignKey(d => d.MatriculaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Conductor__Matri__29572725");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.ToTable("Matricula");

                entity.Property(e => e.FechaExpedicion).HasColumnType("date");

                entity.Property(e => e.FechaExpiracion).HasColumnType("date");

                entity.Property(e => e.Numero)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sancione>(entity =>
            {
                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Conductor)
                    .WithMany(p => p.Sanciones)
                    .HasForeignKey(d => d.ConductorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sanciones__Condu__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
