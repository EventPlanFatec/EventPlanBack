using Microsoft.EntityFrameworkCore;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Infra.Data
{
    public class EventPlanContext : DbContext
    {
        public EventPlanContext(DbContextOptions<EventPlanContext> options) : base(options) { }

        public DbSet<UsuarioFinal> UsuariosFinais { get; set; }
        public DbSet<UsuarioAdm> UsuariosAdm { get; set; }
        public DbSet<Organizacao> Organizacoes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<ListaEspera> ListasEspera { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EventPlanContext).Assembly);
        }
    }
}
