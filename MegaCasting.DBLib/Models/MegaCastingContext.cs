using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MegaCasting.DBLib.Models;

public partial class MegaCastingContext : DbContext
{
    public MegaCastingContext()
    {
    }

    public MegaCastingContext(DbContextOptions<MegaCastingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DomaineMetier> DomaineMetiers { get; set; }

    public virtual DbSet<Metier> Metiers { get; set; }

    public virtual DbSet<OffreCasting> OffreCastings { get; set; }

    public virtual DbSet<TypeContrat> TypeContrats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MegaCasting;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DomaineMetier>(entity =>
        {
            entity.ToTable("domaine_metier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Metier>(entity =>
        {
            entity.ToTable("metier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<OffreCasting>(entity =>
        {
            entity.ToTable("offre_casting");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateDebutContrat)
                .HasColumnType("date")
                .HasColumnName("date_debut_contrat");
            entity.Property(e => e.DatePublication)
                .HasColumnType("date")
                .HasColumnName("date_publication");
            entity.Property(e => e.DescriptionProfil)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description_profil");
            entity.Property(e => e.DomaineId).HasColumnName("domaine_id");
            entity.Property(e => e.DureeDiffusion).HasColumnName("duree_diffusion");
            entity.Property(e => e.Intitule)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("intitule");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.MetierId).HasColumnName("metier_id");
            entity.Property(e => e.NombrePoste).HasColumnName("nombre_poste");
            entity.Property(e => e.Reference).HasColumnName("reference");
            entity.Property(e => e.Telephone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telephone");
            entity.Property(e => e.TypeContratId).HasColumnName("type_contrat_id");

            entity.HasOne(d => d.Domaine).WithMany(p => p.OffreCastings)
                .HasForeignKey(d => d.DomaineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_offre_casting_domaine_metier");

            entity.HasOne(d => d.Metier).WithMany(p => p.OffreCastings)
                .HasForeignKey(d => d.MetierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_offre_casting_metier");

            entity.HasOne(d => d.TypeContrat).WithMany(p => p.OffreCastings)
                .HasForeignKey(d => d.TypeContratId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_offre_casting_type_contrat");
        });

        modelBuilder.Entity<TypeContrat>(entity =>
        {
            entity.ToTable("type_contrat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
