using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.DTOs;

public class RoleDTO
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string> Permissoes { get; set; }
}