using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiBDClinica.Models
{
    public partial class BDCLINICA_WEBAPI_REACTContext : DbContext
    {
        public BDCLINICA_WEBAPI_REACTContext()
        {
        }

        public BDCLINICA_WEBAPI_REACTContext(DbContextOptions<BDCLINICA_WEBAPI_REACTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; }
        public virtual DbSet<Distrito> Distritos { get; set; }
        public virtual DbSet<Especialidad> Especialidads { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }

        //
        public virtual DbSet<PA_CITAS_ANIO> PA_CITAS_ANIO { get; set; }
        public virtual DbSet<PA_MEDICOS_ESPECIALIDAD> PA_MEDICOS_ESPECIALIDAD { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=BDCLINICA_WEBAPI_REACT;integrated security=true;");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AI");

            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.Nrocita)
                    .HasName("pkCitas_nrocita");

                entity.Property(e => e.Nrocita)
                    .ValueGeneratedNever()
                    .HasColumnName("nrocita");

                entity.Property(e => e.Codmed)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codmed")
                    .IsFixedLength(true);

                entity.Property(e => e.Codpac)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codpac")
                    .IsFixedLength(true);

                entity.Property(e => e.Descrip)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("descrip");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("(getdate()+(1))");

                entity.Property(e => e.Pago)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("pago");

                entity.HasOne(d => d.CodmedNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.Codmed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCitas_codmed");

                entity.HasOne(d => d.CodpacNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.Codpac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkCitas_codpac");
            });

            modelBuilder.Entity<Distrito>(entity =>
            {
                entity.HasKey(e => e.Coddis)
                    .HasName("pkDistritos_coddis");

                entity.Property(e => e.Coddis)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("coddis")
                    .IsFixedLength(true);

                entity.Property(e => e.Eliminado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("eliminado")
                    .HasDefaultValueSql("('No')")
                    .IsFixedLength(true);

                entity.Property(e => e.Nomdis)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nomdis");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.HasKey(e => e.Codesp)
                    .HasName("pkEspecialidad_codesp");

                entity.ToTable("Especialidad");

                entity.Property(e => e.Codesp)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("codesp")
                    .IsFixedLength(true);

                entity.Property(e => e.Costo)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("costo");

                entity.Property(e => e.Eliminado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("eliminado")
                    .HasDefaultValueSql("('No')")
                    .IsFixedLength(true);

                entity.Property(e => e.Nomesp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomesp");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.Codmed)
                    .HasName("pkMedicos_codmed");

                entity.Property(e => e.Codmed)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codmed")
                    .IsFixedLength(true);

                entity.Property(e => e.AnioColegio).HasColumnName("anio_colegio");

                entity.Property(e => e.Coddis)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("coddis")
                    .IsFixedLength(true);

                entity.Property(e => e.Codesp)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("codesp")
                    .IsFixedLength(true);

                entity.Property(e => e.Eliminado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("eliminado")
                    .HasDefaultValueSql("('No')")
                    .IsFixedLength(true);

                entity.Property(e => e.Nommed)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nommed");

                entity.HasOne(d => d.CoddisNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Coddis)
                    .HasConstraintName("fkMedicos_coddis");

                entity.HasOne(d => d.CodespNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Codesp)
                    .HasConstraintName("fk_Medicos_codesp");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Codpac)
                    .HasName("pkPacientes_codpac");

                entity.Property(e => e.Codpac)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codpac")
                    .IsFixedLength(true);

                entity.Property(e => e.Coddis)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("coddis")
                    .IsFixedLength(true);

                entity.Property(e => e.Dirpac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dirpac");

                entity.Property(e => e.Dnipac)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("dnipac")
                    .IsFixedLength(true);

                entity.Property(e => e.Eliminado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("eliminado")
                    .HasDefaultValueSql("('No')")
                    .IsFixedLength(true);

                entity.Property(e => e.Nompac)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nompac");

                entity.Property(e => e.TelCel)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tel_cel");

                entity.HasOne(d => d.CoddisNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.Coddis)
                    .HasConstraintName("fkPacientes_coddis");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
