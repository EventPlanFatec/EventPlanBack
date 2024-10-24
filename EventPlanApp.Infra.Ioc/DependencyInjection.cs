﻿using EventPlanApp.Application.Interfaces;
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
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IUsuarioFinalRepository, UsuarioFinalRepository>();
            services.AddScoped<IIngressoRepository, IngressoRepository>();
            services.AddScoped<IIngressoService, IngressoService>();

            var sendGridApiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            services.AddScoped<IEmailService>(provider => new EmailService(sendGridApiKey));

            return services;
        }
    }
}
