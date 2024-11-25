using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class UserService
    {
        private readonly IUsuarioAdmRepository _usuarioAdmRepository;
        private readonly IUsuarioFinalRepository _usuarioFinalRepository;
        private readonly EventPlanContext _context;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;


        public UserService(IUsuarioAdmRepository usuarioAdmRepository, IUsuarioFinalRepository usuarioFinalRepository, EventPlanContext context, IEmailService emailService, IUserRepository userRepository)
        {
            _usuarioAdmRepository = usuarioAdmRepository;
            _usuarioFinalRepository = usuarioFinalRepository;
            _context = context;
            _emailService = emailService;
            _userRepository = userRepository;
        }

        public async Task<bool> UserHasPermission(int userId, string permission)
        {
            var usuarioAdm = await _usuarioAdmRepository.GetById(userId);  // Passando 'int' como ID
            if (usuarioAdm != null && usuarioAdm.Role != null)
            {
                return usuarioAdm.Role.HasPermission(permission);  // Verificando permissão
            }

            var usuarioFinal = await _usuarioFinalRepository.GetById(userId);  // Passando 'int' como ID
            if (usuarioFinal != null && usuarioFinal.Role != null)
            {
                return usuarioFinal.Role.HasPermission(permission);  // Verificando permissão
            }

            return false;
        }

        public async Task<UsuarioAdm> GetById(int id)
        {
            return await _context.UsuariosAdm
                                 .Include(u => u.Role)  // Incluindo o relacionamento com Role
                                 .FirstOrDefaultAsync(u => u.AdmId == id); // Aqui, usando o Guid para buscar o UsuarioAdm
        }

        public async Task<UsuarioFinal> GetByIdAsync(int id)
        {
            return await _usuarioFinalRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UsuarioFinal usuario)
        {
            await _usuarioFinalRepository.UpdateAsync(usuario);
        }

        public async Task CriarUsuarioFinalAsync(UsuarioFinal usuario)
        {
            // Salvar o usuário no banco de dados (supondo que o repositório já esteja implementado)
            await _usuarioFinalRepository.AddAsync(usuario);

            // Gerar o link de acesso para o primeiro login (por exemplo, um link com um token de primeiro acesso)
            string linkAcesso = GerarLinkPrimeiroAcesso(usuario.Email);

            // Enviar o e-mail de boas-vindas
            await EnviarEmailBoasVindasAsync(usuario.Email, usuario.Nome, linkAcesso);
        }

        private string GerarLinkPrimeiroAcesso(string email)
        {
            // Geração do link (um exemplo simples, mas pode incluir um token de segurança)
            return $"https://www.eventplan.com/primeiro-acesso?email={email}";
        }

        // O método que envia o e-mail de boas-vindas, conforme mostrado anteriormente
        public async Task EnviarEmailBoasVindasAsync(string email, string nome, string linkAcesso)
        {
            string assunto = "Bem-vindo ao EventPlan!";
            string corpoEmail = $@"
        <p>Olá {nome},</p>
        <p>Bem-vindo ao EventPlan! Estamos felizes em tê-lo conosco.</p>
        <p>Para começar, por favor, siga as instruções abaixo para acessar sua conta:</p>
        <p><a href='{linkAcesso}'>Clique aqui para acessar sua conta e configurar sua senha.</a></p>
        <p>Se você tiver algum problema, nossa equipe está à disposição para ajudá-lo.</p>
        <p>Atenciosamente,<br>Equipe EventPlan</p>
        ";

            var mensagemEmail = new MensagemEmail
            {
                Destinatario = email,
                Assunto = assunto,
                Conteudo = corpoEmail
            };

            // Envia o e-mail
            await _emailService.SendEmailAsync(mensagemEmail);
        }

        public async Task DeactivateUserAsync(Guid userId)
        {
            // Verificar se o usuário existe
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            // Chama o repositório para desativar o usuário
            await _userRepository.DeactivateUserAsync(user.Id); // Acessando a propriedade 'Id'

            // Aqui, você pode adicionar a lógica de notificação por e-mail, se necessário
        }
    }
}
