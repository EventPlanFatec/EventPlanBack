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
    public Categoria? Categoria { get; set; }
    public string? CategoriaId { get; set; }

    public Endereco? Endereco { get; set; }
    public string? EnderecoId { get; set; }
    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public ICollection<Ingresso> Ingressos { get; set; } = new List<Ingresso>();
}