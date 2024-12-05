using System;
using System.Collections.Generic;

namespace EventPlanApp.Application.DTOs;
public class EventoDTO
{
    public string Id { get; set; }
    public string Data { get; set; }
    public string Descricao { get; set; }
    public string Img { get; set; }
    public string ImgBanner { get; set; }
    public string Local { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string ValorMin { get; set; }
    public List<string> IngressosIds { get; set; }
    public List<string> UsuariosIds { get; set; }
}