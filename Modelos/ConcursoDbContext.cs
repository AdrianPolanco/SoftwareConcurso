using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

    public virtual DbSet<Resultado> Resultados { get; set; }

    public virtual DbSet<Seleccionado> Seleccionados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured){
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("CadenaConexion");

           optionsBuilder.UseSqlServer(connectionString); 
        }
        
    }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

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

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.IdSeleccionado).HasName("PK__RESULTAD__2C3C0DB92D81EB0C");

            entity.ToTable("RESULTADOS");

            entity.Property(e => e.IdSeleccionado).ValueGeneratedNever();

            entity.HasOne(d => d.IdSeleccionadoNavigation).WithOne(p => p.Resultado)
                .HasForeignKey<Resultado>(d => d.IdSeleccionado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdSeleccionado_R");
        });

        modelBuilder.Entity<Seleccionado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SELECCIO__3214EC2750B3D4D9");

            entity.ToTable("SELECCIONADOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Matricula)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
