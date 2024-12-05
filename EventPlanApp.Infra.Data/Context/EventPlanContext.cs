using Microsoft.EntityFrameworkCore;
using EventPlanApp.Domain.Entities;
using System.Data;

namespace EventPlanApp.Infra.Data
{
    public class EventPlanContext : DbContext
    {
        public EventPlanContext(DbContextOptions<EventPlanContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EventPlanContext).Assembly);


        }
    }
}
