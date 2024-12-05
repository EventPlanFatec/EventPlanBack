using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EventPlanApp.Domain.Entities;

public class Evento
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Data { get; set; }
    public string Descricao { get; set; }
    public string Img { get; set; }
    public string ImgBanner { get; set; }
    public string Local { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string ValorMin { get; set; }

    // Relacionamentos
    public List<string> IngressosIds { get; set; } = new List<string>();
    public List<string> UsuariosIds { get; set; } = new List<string>();
}