using Microsoft.EntityFrameworkCore;
using EventPlanApp.Domain.Entities;
using System.Data;

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
        public DbSet<Role> Roles { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<UserPreferences> UserPreferences { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EventPlanContext).Assembly);
        }
    }
}
