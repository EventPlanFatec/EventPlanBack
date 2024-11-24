﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int UsuarioAdmId { get; set; }  // Administrador que executou a ação
        public string TipoAcao { get; set; }  // "Criação", "Edição", etc.
        public string Descricao { get; set; }  // Detalhes sobre a ação executada
        public DateTime DataHora { get; set; }  // Data e hora da ação
        public string ConteudoAlteradoAntes { get; set; }  // Conteúdo antes da edição (caso seja uma edição)
        public string ConteudoAlteradoDepois { get; set; }  // Conteúdo depois da edição (caso seja uma edição)
        public string IpEndereco { get; set; }  // Endereço IP do usuário que fez a ação
        public string UserId { get; set; }  // ID do usuário que realizou a ação
        public string ActionType { get; set; }  // Tipo da ação (criação, edição, etc.)
        public string EntityName { get; set; }  // Nome da entidade afetada
        public DateTime Date { get; set; }  // Data e hora da ação
        public string Details { get; set; }
        public bool IsSuspicious { get; set; }
    }
}
