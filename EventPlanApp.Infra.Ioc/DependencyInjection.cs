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

            services.AddScoped<IIngressoRepository, IngressoRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IIngressoService, IngressoService>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            //services.AddScoped<IFirebaseService, FirebaseService>();

            return services;
        }
    }
}
