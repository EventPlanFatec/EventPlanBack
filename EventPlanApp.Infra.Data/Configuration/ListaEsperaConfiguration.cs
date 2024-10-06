using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventPlanApp.Domain.Entities;

namespace EventPlanApp.Infra.Data.EntityConfiguration
{
    public class ListaEsperaConfiguration : IEntityTypeConfiguration<ListaEspera>
    {
        public void Configure(EntityTypeBuilder<ListaEspera> builder)
        {
            builder.HasKey(l => l.Id); 
        }
    }
}
