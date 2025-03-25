using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Agenda_p.FilmsDB;

public partial class FilmsContext : DbContext
{
    public FilmsContext()
    {
    }

    public FilmsContext(DbContextOptions<FilmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acteur> Acteurs { get; set; }

    public virtual DbSet<ActeursFilm> ActeursFilms { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<GenreFilm> GenreFilms { get; set; }

    public virtual DbSet<Réalisateur> Réalisateurs { get; set; }

    public virtual DbSet<RéalisateursFilm> RéalisateursFilms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=films", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Acteur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("acteurs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom).HasMaxLength(45);
            entity.Property(e => e.Prénom).HasMaxLength(45);
        });

        modelBuilder.Entity<ActeursFilm>(entity =>
        {
            entity.HasKey(e => new { e.FilmsId, e.ActeursId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("acteurs_films");

            entity.Property(e => e.FilmsId)
                .ValueGeneratedOnAdd()
                .HasColumnName("films_id");
            entity.Property(e => e.ActeursId).HasColumnName("acteurs_id");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("films");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Durée).HasMaxLength(20);
            entity.Property(e => e.LienDescription).HasMaxLength(255);
            entity.Property(e => e.Titre).HasMaxLength(100);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("genre");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom).HasMaxLength(45);
        });

        modelBuilder.Entity<GenreFilm>(entity =>
        {
            entity.HasKey(e => new { e.FilmsId, e.GenreId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("genre_films");

            entity.Property(e => e.FilmsId)
                .ValueGeneratedOnAdd()
                .HasColumnName("films_id");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
        });

        modelBuilder.Entity<Réalisateur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("réalisateurs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreDeFilmsRéalisés)
                .HasMaxLength(15)
                .HasColumnName("Nombre de films réalisés");
            entity.Property(e => e.Noms).HasMaxLength(45);
            entity.Property(e => e.Prénoms).HasMaxLength(45);
        });

        modelBuilder.Entity<RéalisateursFilm>(entity =>
        {
            entity.HasKey(e => new { e.FilmsId, e.RéalisateursId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("réalisateurs_films");

            entity.Property(e => e.FilmsId)
                .ValueGeneratedOnAdd()
                .HasColumnName("films_id");
            entity.Property(e => e.RéalisateursId).HasColumnName("réalisateurs_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
