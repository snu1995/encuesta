using Microsoft.EntityFrameworkCore;

namespace encuesta.Models;

public class DbUsuarioContext : DbContext
{
    public DbUsuarioContext()
    {
    }

    public DbUsuarioContext(DbContextOptions<DbUsuarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.idUsuario)
                  .HasName("PK__USUARIO__5B65BF97D1F49851");

            entity.ToTable("Usuario");

            entity.Property(e => e.ClaveUsuario)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CorreoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

    }
}
