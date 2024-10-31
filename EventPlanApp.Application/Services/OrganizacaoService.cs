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
            RegistracaoResultadoDto resultado = new RegistracaoResultadoDto();
            // Configurar o resultado conforme necessário

            return resultado; // Certifique-se de retornar o tipo correto
        }

        public async Task<bool> UpdateAsync(int id, OrganizacaoDto organizacaoDto)
        {
            // Validações
            if (organizacaoDto == null)
            {
                throw new ArgumentNullException(nameof(organizacaoDto));
            }

            // Recupera a organização existente
            var organizacao = await _organizacaoRepository.GetByIdAsync(id);
            if (organizacao == null)
            {
                return false; // Registro não encontrado
            }

            // Converte EnderecoDto para Endereco usando o construtor
            var endereco = new Endereco(
                organizacaoDto.Endereco.TipoLogradouro,
                organizacaoDto.Endereco.Logradouro,
                organizacaoDto.Endereco.NumeroCasa,
                organizacaoDto.Endereco.Bairro,
                organizacaoDto.Endereco.Cidade,
                organizacaoDto.Endereco.Estado,
                organizacaoDto.Endereco.CEP
            );

            // Atualiza as propriedades da organização
            organizacao.Update(organizacaoDto.CNPJ, endereco, organizacaoDto.NotaMedia);

            // Salva as alterações
            await _organizacaoRepository.UpdateAsync(organizacao);
            return true;
        }
    }
}
