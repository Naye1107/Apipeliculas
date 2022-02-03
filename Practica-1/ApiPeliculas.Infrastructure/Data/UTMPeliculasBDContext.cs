//cSpell:disable

using ApiPeliculas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ApiPeliculas.Infrastructure.Data
{
    public partial class UTMPeliculasBDContext : DbContext
    {
        public UTMPeliculasBDContext()
        {
        }

        public UTMPeliculasBDContext(DbContextOptions<UTMPeliculasBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pelicula> Peliculas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_IDPELICULAS");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();


                entity.Property(e => e.Director)
                    .HasMaxLength(300)
                    .IsUnicode(false);


                entity.Property(e => e.FechaPublicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fecha_Publicacion");

                entity.Property(e => e.Genero)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Rating).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
