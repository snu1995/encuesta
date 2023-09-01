using Microsoft.EntityFrameworkCore;
using encuesta.Models;

namespace encuesta.Models
{
    public class DbEncuestaContext : DbContext
    {
        public DbEncuestaContext()
        {
        }

        public DbEncuestaContext(DbContextOptions<DbEncuestaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Encuesta> EncuestaEntity { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Encuesta>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Encuesta");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Enlace)
                   .HasMaxLength(200)
                   .IsUnicode(false);
            });

        }
    }
}
