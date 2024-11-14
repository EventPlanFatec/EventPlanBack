﻿using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Infra.Data.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly EventPlanContext _context;

        public VolunteerRepository(EventPlanContext context)
        {
            _context = context;
        }

        // Adiciona um novo voluntário ao banco de dados
        public async Task<Volunteer> AddAsync(Volunteer volunteer)
        {
            await _context.Volunteers.AddAsync(volunteer);
            await _context.SaveChangesAsync();
            return volunteer;
        }

        // Recupera um voluntário pelo ID
        public async Task<Volunteer> GetByIdAsync(int id)
        {
            return await _context.Volunteers
                                 .FirstOrDefaultAsync(v => v.Id == id);
        }

        // Recupera todos os voluntários
        public async Task<IEnumerable<Volunteer>> GetAllAsync()
        {
            return await _context.Volunteers.ToListAsync();
        }

        // Atualiza as informações do voluntário
        public async Task<Volunteer> UpdateAsync(Volunteer volunteer)
        {
            _context.Volunteers.Update(volunteer);
            await _context.SaveChangesAsync();
            return volunteer;
        }


        // Implementação do método DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            var volunteer = await _context.Volunteers
                .FirstOrDefaultAsync(v => v.Id == id);

            if (volunteer == null)
            {
                return false; // Voluntário não encontrado
            }

            _context.Volunteers.Remove(volunteer);
            await _context.SaveChangesAsync();
            return true; // Remoção bem-sucedida
        }

    }
}