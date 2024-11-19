using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IVolunteerService
    {
        Task<bool> DeleteVolunteerAsync(int id);
        Task<Volunteer> UpdateVolunteerAsync(int id, VolunteerDto volunteerDto);
        Task<Volunteer> RegisterVolunteerAsync(VolunteerDto volunteerDto);
    }
}
