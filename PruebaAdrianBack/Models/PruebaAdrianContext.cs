using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaAdrianBack.Models;

public partial class PruebaAdrianContext : DbContext
{
    public PruebaAdrianContext()
    {
    }

    public PruebaAdrianContext(DbContextOptions<PruebaAdrianContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=RH;Database=PruebaAdrian;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCursos).HasName("PK__cursos__0F645A9ED9BA8368");

            entity.ToTable("cursos");

            entity.Property(e => e.NombreCursos)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiantes).HasName("PK__estudian__6430B0387E182666");

            entity.ToTable("estudiantes");

            entity.Property(e => e.ApellidoEstudiante)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CedulaEstudiante)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreEstudiante)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__registro__FFA45A99ADB95BE4");

            entity.ToTable("registro");

            entity.HasOne(d => d.IdCursosNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdCursos)
                .HasConstraintName("Fk_IdCursos");

            entity.HasOne(d => d.IdPersonasNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdPersonas)
                .HasConstraintName("Fk_IdEstudiante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
