using Microsoft.EntityFrameworkCore;


namespace encuesta.Models
{
    public class DbRespuestaContext : DbContext
    {
        public DbRespuestaContext()
        {
        }

        public DbRespuestaContext(DbContextOptions<DbRespuestaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ResponseEncuesta> RespuestaEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResponseEncuesta>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Respuestas");

                entity.Property(e => e.NombrePersona)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Valor)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.EncuestaId)
                  .HasMaxLength(100)
                  .IsUnicode(false);
                entity.Property(e => e.CampoId)
                  .HasMaxLength(100)
                  .IsUnicode(false);
             
            });
          
        }

    }
}
