using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class OrganizacaoService : IOrganizacaoService
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;

        public OrganizacaoService(IOrganizacaoRepository organizacaoRepository)
        {
            _organizacaoRepository = organizacaoRepository;
        }


        
        public async Task<RegistracaoResultadoDto> RegisterAsync(OrganizacaoDto organizacaoDto)
        {
            // Sua lógica de registro aqui
            // Por exemplo:
            RegistracaoResultadoDto resultado = new RegistracaoResultadoDto();
            // Configurar o resultado conforme necessário

            return resultado; // Certifique-se de retornar o tipo correto
        }


    }
}
