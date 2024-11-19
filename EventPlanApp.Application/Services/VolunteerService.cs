using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class VolunteerService : IVolunteerService
    {
        private readonly IVolunteerRepository _repository;

        public VolunteerService(IVolunteerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Volunteer> RegisterVolunteerAsync(VolunteerDto volunteerDto)
        {
            if (string.IsNullOrWhiteSpace(volunteerDto.Name) || string.IsNullOrWhiteSpace(volunteerDto.Email))
                throw new ArgumentException("Name and Email are required");

            var volunteer = new Volunteer
            {
                Name = volunteerDto.Name,
                Email = volunteerDto.Email,
                Phone = volunteerDto.Phone,
                DateOfBirth = volunteerDto.DateOfBirth,
                Address = volunteerDto.Address
            };

            return await _repository.AddAsync(volunteer);
        }
        public async Task<Volunteer> UpdateVolunteerAsync(int id, VolunteerDto volunteerDto)
        {
            // Valida os dados recebidos
            if (string.IsNullOrWhiteSpace(volunteerDto.Name) || string.IsNullOrWhiteSpace(volunteerDto.Email))
                throw new ArgumentException("Name and Email are required.");

            // Obtém o voluntário existente pelo ID
            var volunteer = await _repository.GetByIdAsync(id);
            if (volunteer == null)
            {
                throw new ArgumentException("Volunteer not found.");
            }

            // Atualiza os dados do voluntário
            volunteer.Name = volunteerDto.Name;
            volunteer.Email = volunteerDto.Email;
            volunteer.Phone = volunteerDto.Phone;
            volunteer.DateOfBirth = volunteerDto.DateOfBirth;
            volunteer.Address = volunteerDto.Address;

            // Chama o repositório para salvar as alterações
            await _repository.UpdateAsync(volunteer);

            return volunteer;
        }
        public async Task<bool> DeleteVolunteerAsync(int id)
        {
            // Chama o repositório para excluir o voluntário
            return await _repository.DeleteAsync(id);
        }
    }
}
