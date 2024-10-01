using EventPlanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class EventPlanContext : DbContext
{
    public EventPlanContext(DbContextOptions<EventPlanContext> options)
        : base(options)
    {
    }

    public DbSet<UsuarioFinal> UsuariosFinais { get; set; }
    public DbSet<UsuarioAdm> UsuariosAdm { get; set; }
    public DbSet<Organizacao> Organizacoes { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Ingresso> Ingressos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mapeamento UsuarioFinal
        modelBuilder.Entity<UsuarioFinal>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<UsuarioFinal>()
            .HasMany(u => u.Ingressos)
            .WithOne(i => i.UsuarioFinal)
            .HasForeignKey(i => i.UsuarioFinalId)
            .OnDelete(DeleteBehavior.Cascade);

        // Mapeamento UsuarioAdm
        modelBuilder.Entity<UsuarioAdm>()
            .HasKey(a => a.AdmId);

        modelBuilder.Entity<UsuarioAdm>()
            .HasMany(a => a.Organizacoes)
            .WithMany(o => o.UsuariosAdm);

        // Mapeamento Organizacao
        modelBuilder.Entity<Organizacao>()
            .HasKey(o => o.OrganizacaoId);

        modelBuilder.Entity<Organizacao>()
            .HasMany(o => o.Eventos)
            .WithOne(e => e.Organizacao)
            .HasForeignKey(e => e.OrganizacaoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Mapeamento Evento
        modelBuilder.Entity<Evento>()
            .HasKey(e => e.EventoId);

        modelBuilder.Entity<Evento>()
            .HasMany(e => e.Ingressos)
            .WithOne(i => i.Evento)
            .HasForeignKey(i => i.EventoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Mapeamento Ingresso
        modelBuilder.Entity<Ingresso>()
            .HasKey(i => i.IngressoId);

        modelBuilder.Entity<Ingresso>()
            .Property(i => i.Valor)
            .HasColumnType("decimal(18,2)");

        // Propriedades adicionais
        modelBuilder.Entity<Evento>()
            .Property(e => e.NotaMedia)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Organizacao>()
            .Property(o => o.NotaMedia)
            .HasColumnType("decimal(18,2)");
    }
}
