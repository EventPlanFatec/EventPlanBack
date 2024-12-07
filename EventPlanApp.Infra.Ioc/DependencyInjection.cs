using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Mappings;
using EventPlanApp.Application.Services;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EventPlanApp.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<DomainToDTOMappingProfile>();

            // Registrando os repositórios
            services.AddScoped<IIngressoRepository, IngressoRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            // Registrando os serviços
            services.AddScoped<IIngressoService, IngressoService>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            // Registrando o serviço Firebase
            services.AddScoped<IFirebaseService, FirebaseService>();

            // Registrando o repositório Firebase
            services.AddScoped<IFirebaseRepository, FirebaseRepository>();

            // Registrando o serviço de sincronização
            services.AddScoped<EventoSyncService>();

            return services;
        }
    }
}
