using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.DTOs;

public class UsuarioDTO
{ 
    public string Id { get; set; }
    public string EnderecoId { get; set; }
    public string RoleId { get; set; }
    public string Cpf { get; set; }
    public DateTime CreatedAt { get; set; }
    public string DataNascimento { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public List<string> IngressosIds { get; set; }
    public List<string> EventosIds { get; set; }
}