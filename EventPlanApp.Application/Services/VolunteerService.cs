using EventPlanApp.Application.DTOs;
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
    public class VolunteerService
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
    }
}
