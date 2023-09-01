using Microsoft.EntityFrameworkCore;


namespace encuesta.Models
{
    public class DbCampoContext : DbContext
    {
        public DbCampoContext()
        {
        }

        public DbCampoContext(DbContextOptions<DbCampoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campo> CampoEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Campo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.EsRequerido)
                  .HasMaxLength(100)
                  .IsUnicode(false);
                entity.Property(e => e.TipoCampoId)
                  .HasMaxLength(100)
                  .IsUnicode(false);
                entity.Property(e => e.EncuestaId)
                  .HasMaxLength(100)
                  .IsUnicode(false);

            });

        }

    }
}
