using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SelectorAleatorioDefinitivo.Modelos;

public partial class ConcursoDbContext : DbContext
{
    public ConcursoDbContext()
    {
    }

    public ConcursoDbContext(DbContextOptions<ConcursoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatosParticipante> DatosParticipantes { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-9AJGK0OL;Initial Catalog=CONCURSO_DB;Persist Security Info=True;TrustServerCertificate=true;User ID=sa;Password=0611;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatosParticipante>(entity =>
        {
            entity.HasKey(e => e.IdDatosParticipante).HasName("PK__DATOS_PA__558501BFCDFEA497");

            entity.ToTable("DATOS_PARTICIPANTE");

            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Matricula)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PK__PARTICIP__56139242AC426425");

            entity.ToTable("PARTICIPANTES");

            entity.HasOne(d => d.IdDatosParticipanteNavigation).WithMany(p => p.Participantes)
                .HasForeignKey(d => d.IdDatosParticipante)
                .HasConstraintName("fk_IdDatosParticipante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
