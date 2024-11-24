using System;
using System.Collections.Generic;

namespace EventPlanApp.Application.DTOs
{
    public class EventoDto
    {
        public int EventoId { get; set; }
        public string NomeEvento { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; } 
        public DateTime? DataFim { get; set; }    
        public TimeSpan? HorarioInicio { get; set; } 
        public TimeSpan? HorarioFim { get; set; }    
        public int? LotacaoMaxima { get; set; }    
        public EnderecoDto? Endereco { get; set; } 
        public List<string>? Imagens { get; set; }
        public int CategoriaId { get; set; }
        public List<string> Tags { get; set; }
        public string? Video { get; set; }        
        public decimal? NotaMedia { get; set; }    
        public string? Genero { get; set; }      
        public ICollection<UsuarioFinalDto>? UsuariosFinais { get; set; } 
        public ICollection<IngressoDto>? Ingressos { get; set; }     
        public int OrganizacaoId { get; set; }
        public bool IsPrivate { get; set; }
        public string? Senha { get; set; }
        public List<string>? EmailsConvidados { get; set; }
    }
}
