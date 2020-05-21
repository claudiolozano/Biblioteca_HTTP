using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Biblioteca_HTTP.Models
{
    public partial class EditorialContext : DbContext
    {
        public EditorialContext()
        {
        }

        public EditorialContext(DbContextOptions<EditorialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<Bibliografias> Bibliografias { get; set; }
        public virtual DbSet<Editoriales> Editoriales { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LENOVO\\SQL2019;Initial Catalog=Editorial;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autores>(entity =>
            {
                entity.HasKey(e => e.Dni);

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8);

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            modelBuilder.Entity<Bibliografias>(entity =>
            {
                entity.HasKey(e => e.IdBlibliografia);

                entity.Property(e => e.Comentarios).HasMaxLength(500);

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.HasOne(d => d.EditorialNavigation)
                    .WithMany(p => p.Bibliografias)
                    .HasForeignKey(d => d.Editorial)
                    .HasConstraintName("FK_Bibliografias_Editoriales");

                entity.HasOne(d => d.LibroNavigation)
                    .WithMany(p => p.Bibliografias)
                    .HasForeignKey(d => d.Libro)
                    .HasConstraintName("FK_Bibliografias_Libros");
            });

            modelBuilder.Entity<Editoriales>(entity =>
            {
                entity.HasKey(e => e.IdEditorial);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            modelBuilder.Entity<Libros>(entity =>
            {
                entity.HasKey(e => e.IdLibro);

                entity.Property(e => e.Autor).HasMaxLength(8);

                entity.Property(e => e.Comentarios).HasMaxLength(500);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.AutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.Autor)
                    .HasConstraintName("FK_Libros_Autores");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.IdPais);

                entity.Property(e => e.Comentarios).HasMaxLength(500);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
