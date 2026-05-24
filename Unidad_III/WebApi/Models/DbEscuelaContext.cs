using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public partial class DbEscuelaContext : DbContext
{
    public DbEscuelaContext()
    {
    }

    public DbEscuelaContext(DbContextOptions<DbEscuelaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=localhost;database=db_escuela;username=postgres;password=qwe123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.NumeroControl).HasName("Alumnos_pkey");

            entity.Property(e => e.NumeroControl)
                .HasMaxLength(10)
                .HasColumnName("numero_control");
            entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Semestre).HasColumnName("semestre");
            entity.Property(e => e.Imagen)
                .HasColumnName("imagen");
            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("fk_id_carrera");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Carreras_pkey");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
