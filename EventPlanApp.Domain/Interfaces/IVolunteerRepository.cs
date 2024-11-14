using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IVolunteerRepository
    {
        Task<Volunteer> AddAsync(Volunteer volunteer);
        Task<Volunteer> GetByIdAsync(int id);
        Task<IEnumerable<Volunteer>> GetAllAsync();
        Task<Volunteer> UpdateAsync(Volunteer volunteer);
        Task<bool> DeleteAsync(int id);
    }
}
