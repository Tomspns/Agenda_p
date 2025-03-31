using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Agenda_p.DAO;

public partial class AgendaTomContext : DbContext
{
    public AgendaTomContext()
    {
    }

    public AgendaTomContext(DbContextOptions<AgendaTomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Afaire> Afaires { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Réseaux> Réseauxes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda_tom", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Afaire>(entity =>
        {
            entity.HasKey(e => e.IdAfaire).HasName("PRIMARY");

            entity.ToTable("afaire");

            entity.Property(e => e.IdAfaire).HasColumnName("idAfaire");
            entity.Property(e => e.FaitNonFait)
                .HasMaxLength(65)
                .HasColumnName("Fait / Non fait");
            entity.Property(e => e.Titre).HasMaxLength(65);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.IdContacts).HasName("PRIMARY");

            entity.ToTable("contacts");

            entity.Property(e => e.IdContacts).HasColumnName("idContacts");
            entity.Property(e => e.Email).HasMaxLength(65);
            entity.Property(e => e.Nom).HasMaxLength(65);
            entity.Property(e => e.Numéro).HasMaxLength(45);
            entity.Property(e => e.Prénom).HasMaxLength(65);
        });

        modelBuilder.Entity<Réseaux>(entity =>
        {
            entity.HasKey(e => e.IdRéseaux).HasName("PRIMARY");

            entity.ToTable("réseaux");

            entity.HasIndex(e => e.ContactsIdContacts, "fk_Réseaux_Contacts_idx");

            entity.Property(e => e.IdRéseaux).HasColumnName("idRéseaux");
            entity.Property(e => e.ContactsIdContacts).HasColumnName("Contacts_idContacts");
            entity.Property(e => e.Facebook).HasMaxLength(65);
            entity.Property(e => e.Instagram).HasMaxLength(65);
            entity.Property(e => e.Snapchat).HasMaxLength(65);
            entity.Property(e => e.TikTok).HasMaxLength(65);

            entity.HasOne(d => d.ContactsIdContactsNavigation).WithMany(p => p.Réseauxes)
                .HasForeignKey(d => d.ContactsIdContacts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Réseaux_Contacts");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
