using EventPlanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Interfaces
{
    public interface IUsuarioAdmRepository
    {
        Task<UsuarioAdm> GetById(int id);
    }
}
