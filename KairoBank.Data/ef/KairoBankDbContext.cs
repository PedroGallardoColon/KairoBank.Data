using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KairoBank.Data.entities;

namespace KairoBank.Data.ef
{
    public partial class KairoBankDbContext : DbContext
    {
        public KairoBankDbContext()
        {
        }

        public KairoBankDbContext(DbContextOptions<KairoBankDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anuncio> Anuncios { get; set; }
        public virtual DbSet<Solicitude> Solicitudes { get; set; }
        public virtual DbSet<Transaccione> Transacciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Anuncios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Anuncios_ToAnuncios");
            });

            modelBuilder.Entity<Solicitude>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioAnuncianteNavigation)
                    .WithMany(p => p.SolicitudeIdUsuarioAnuncianteNavigations)
                    .HasForeignKey(d => d.IdUsuarioAnunciante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_ToUsuarioAnunciante");

                entity.HasOne(d => d.IdUsuarioSolicitanteNavigation)
                    .WithMany(p => p.SolicitudeIdUsuarioSolicitanteNavigations)
                    .HasForeignKey(d => d.IdUsuarioSolicitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_ToUsuarioSolicitante");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.HasOne(d => d.IdSolicitudNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdSolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transacciones_Solicitudes");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transacciones_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
